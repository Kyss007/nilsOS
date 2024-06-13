using System.Collections;
using System.Collections.Generic;
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
        Encrypter.EncryptString(_key, _clearPassword);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
