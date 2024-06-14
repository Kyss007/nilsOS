using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine;

public class PhoneNumberValidator : MonoBehaviour
{
    bool numberValid = false; 
    private const string apiKey = "4d83516aa4bd46159bb269afa10ae4cc"; // Ersetze dies durch deinen AbstractAPI API-Schlüssel
    private const string apiUrl = "https://phonevalidation.abstractapi.com/v1/";
    
    public bool ValidatePhoneNumber(string phoneNumber)
    {
        numberValid = false; 
        StartCoroutine(ValidatePhoneNumberCoroutine(phoneNumber));
        return numberValid;
    }

    private IEnumerator ValidatePhoneNumberCoroutine(string phoneNumber)
    {
        string url = $"{apiUrl}?api_key={apiKey}&phone={phoneNumber}&country=DE";
        UnityWebRequest request = UnityWebRequest.Get(url);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError(request.error);
        }
        else
        {
            // Verarbeite die Antwort
            var response = JsonUtility.FromJson<PhoneValidationResponse>(request.downloadHandler.text);
            if (response.valid)
            {
                numberValid = true;
                Debug.Log("Number is valid"); 
            }
            else
            {
                Debug.Log("Number is not valid");
            }
        }
    }

    [System.Serializable]
    public class PhoneValidationResponse
    {
        public bool valid;
        public string format_international;
        public string format_local;
        public string country;
        public string location;
        public string type;
    }
}
