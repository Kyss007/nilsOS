using System.Text;
using System;
using UnityEngine; 

public static class Encrypter
{
    public static string EncryptString(int key, string secret)
    {
        StringBuilder encryptedString = new StringBuilder();

        foreach (char l in secret)
        {
            int curIndex = Array.IndexOf(Utillitys.allowedChars, l);
            if (curIndex == -1)
            {
                encryptedString.Append(l);
                continue;
            }
            int newIndex = GetNewIndex(curIndex, key);
            encryptedString.Append(Utillitys.allowedChars[newIndex]);
        }
        Debug.Log(encryptedString + " " + secret);
        return encryptedString.ToString();
    }

    public static int GetNewIndex(int index, int key)
    {
        int newIndex = (index + key) % Utillitys.allowedChars.Length;
        return newIndex;
    }
}

public static class Utillitys
{
    public static char[] allowedChars = { '+', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
}
