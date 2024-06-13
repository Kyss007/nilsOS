using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private string _clearPassword;
    [SerializeField]
    private int _key; 
    // Start is called before the first frame update
    void Start()
    {
        HandleInput(); 

    }

    public bool IsNumberValid() 
    {
        int counter = 0; 
        foreach(char l in _clearPassword) 
        {
            if(IsValidChar(l, counter) == false) 
            {
                return false; 
            }
            counter++; 
        }
        return true; 
    }

    void HandleInput() 
    {
        bool valid = IsNumberValid();
        if (valid) 
        {
            string theNumber = Encrypter.EncryptString(_key, _clearPassword);
            for (int i = 0; i < Utillitys.allowedChars.Length; ++i)
            {
                string PossibleDecryptedTxt = Decrypter.DecryptString(i, theNumber);
                if (PossibleDecryptedTxt != "this is not a number!")
                {
                    Debug.Log(PossibleDecryptedTxt);
                    break;
                }


            }
        }
    }
    public bool IsValidChar(char charToCheck, int charCounter) 
    {
        if (charCounter != 0 && charToCheck == '+')
        {
            return false; 
        }

        if (Utillitys.allowedChars.Contains<char>(charToCheck)) 
        {
            return true; 
        }
        return false;
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
