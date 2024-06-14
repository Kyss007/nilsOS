using System;
using System.Text;
using System.Linq;
using UnityEngine;
using TMPro;


public class InputManager : MonoBehaviour
{
    [SerializeField]
    private string _clearPassword;
    [SerializeField]
    private int _key;
    [SerializeField]
    private TMP_InputField _inputField;
    int userToDumpForInputCounter = 0;
    private bool programCrash = false;
    private int deneyCounterr = 0;
    public charachterController cc; 
    public PhoneNumberValidator phoneNumberValidator;
    private void Update()
    {
        if (programCrash) 
        {
            Application.Quit(); 
        }
    }

    public bool IsNumberValid()
    {
        for (int i = 0; i < _clearPassword.Length; i++)
        {
            if (!IsValidChar(_clearPassword[i], i))
            {
                Debug.LogError($"Number is not valid: Invalid character '{_clearPassword[i]}' at position {i}");
                return false;
            }
        }
        return true;
    }

    bool HandleInput()
    {
        if (IsNumberValid())
        {
            string theNumber = Encrypter.EncryptString(_key, _clearPassword);

            for (int i = 0; i < Utillitys.allowedChars.Length; i++)
            {
                string possibleDecryptedTxt = Decrypter.DecryptString(i, theNumber);
                Debug.Log($"Decrypted string: {possibleDecryptedTxt}");
                Debug.Log($"Trying key {i}: Decrypted string: {possibleDecryptedTxt}");

                if (possibleDecryptedTxt != "this is not a number!")
                {
                    if (phoneNumberValidator.ValidatePhoneNumber(possibleDecryptedTxt)) 
                    {
                        Debug.Log($"Successful decryption with key {i}: {possibleDecryptedTxt}");
                        return true;
                    }
                    return false;
                }
            }
        }
        return false;
    }

    public void OnAccept()
    {
        _clearPassword = _inputField.text;
        Debug.Log($"Input received: {_clearPassword}");

        if (!HandleInput())
        {
            _inputField.text = String.Empty;
            userToDumpForInputCounter++;
            if (userToDumpForInputCounter >= 3)
            {
                programCrash = true;
                throw new System.ArgumentException("Didn't expect you to be this dumb...:(");
            }
            Debug.LogError("Wrong Input, try again!");
            return;
        }
         Debug.Log("Thanks for the input.");
        _inputField.text = String.Empty;
        _clearPassword = String.Empty;
        // Restart game from position
        Destroy(cc.Spike); 
        Time.timeScale = 1;
        cc.IsDead = false;
        cc._deathUi.SetActive(false);
    }
    public bool IsValidChar(char charToCheck, int charCounter)
    {
        if (charCounter != 0 && charToCheck == '+')
        {
            return false;
        }

        return Utillitys.allowedChars.Contains(charToCheck);
    }

    public void OnDeney() 
    {
        deneyCounterr++;
        _inputField.text = "You have " + (3- deneyCounterr) + " attempts left..."; 
        if(deneyCounterr > 2) 
        {
            cc.BlueScreen(); 
        }
    }
}


