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
                Debug.LogError("Number is not valid"); 
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
            for (int i = 0; i < Utillitys.allowedChars.Length; ++i)
            {
                string possibleDecryptedTxt = Decrypter.DecryptString(i, theNumber);
                if (possibleDecryptedTxt != "this is not a number!")
                {
                    Debug.Log(possibleDecryptedTxt);
                    return true;
                }
            }
        }
        return false; 
    }

    public bool IsValidChar(char charToCheck, int charCounter)
    {
        if (charCounter != 0 && charToCheck == '+')
        {
            return false;
        }

        return Utillitys.allowedChars.Contains(charToCheck);
    }

    public void OnAccept() 
    {
        _clearPassword = _inputField.text;
        if (!HandleInput()) 
        {
            _inputField.text = String.Empty;
            userToDumpForInputCounter++; 
            if(userToDumpForInputCounter >= 3) 
            {
                programCrash = true; 
                throw new System.ArgumentException("Didn't expected you to be this dump...:("); 
            }
            Debug.LogError("Wrong Input, try again!"); 

        }
        Debug.Log("thanks for the nudes"); 
        //restarte game from position
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


