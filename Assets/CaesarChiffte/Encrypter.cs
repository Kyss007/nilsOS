using System;
using UnityEngine;

public static class Encrypter
{
    private static int maxArraySize = 26;

    private static char[] FillAlphabetArray()
    {
        int arraySize = 'z' - 'a' + 1;
        char[] alphabet = new char[arraySize];

        for (int i = 0; i < arraySize; i++)
        {
            char currentChar = (char)('a' + i);
            alphabet[i] = currentChar;
            Debug.Log(currentChar);
        }
        return alphabet;
    }

    public static void EncryptString(int key, string secret)
    {
        char[] alphabet = FillAlphabetArray();
        string encryptedString = "";

        foreach (char l in secret)
        {
            int curIndex = Array.IndexOf(alphabet, l);
            if (curIndex == -1)
            {
                encryptedString += l;
                continue;
            }
            int newIndex = GetNewIndex(curIndex, key);
            encryptedString += alphabet[newIndex];
        }
        Debug.Log(encryptedString + " " + DecryptString(key, encryptedString) + " " + secret);
    }

    private static string DecryptString(int key, string secret)
    {
        char[] alphabet = FillAlphabetArray();
        string decryptedString = "";

        foreach (char l in secret)
        {
            int curIndex = Array.IndexOf(alphabet, l);
            if (curIndex == -1)
            {
                decryptedString += l;
                continue;
            }
            int realIndex = GetRealIndex(curIndex, key);
            decryptedString += alphabet[realIndex];
        }

        return decryptedString;
    }

    public static int GetNewIndex(int index, int key)
    {
        int newIndex = (index + key) % maxArraySize;
        return newIndex;
    }

    public static int GetRealIndex(int index, int key)
    {
        int newIndex = (index - key) % maxArraySize;
        if (newIndex < 0)
        {
            newIndex += maxArraySize;
        }
        return newIndex;
    }
}

