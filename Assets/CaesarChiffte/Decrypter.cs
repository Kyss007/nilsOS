using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public static class Decrypter 
{
        private static int maxArraySize = 26;
    public static string DecryptString(int possibleKey, string secret)
    {

        string decryptedString = "";
        bool allreadyHadAPlus = false;
        int counter = 0; 
        foreach (char l in secret)
        {
            if(counter == 0 && l != '+' || counter == 0 && l != '0') 
            {
                return "this is not a number!";
            }
            
            if (!allreadyHadAPlus && l == '+') 
            {
                allreadyHadAPlus = true;
            } 
            else if(allreadyHadAPlus && l == '+') 
            {
                return "this is not a number!"; 
            }

            if(Utillitys.allowedChars.Contains<char>(l) == false) 
            {
                return "this is not a number!";
            }
            int curIndex = Array.IndexOf(Utillitys.allowedChars, l);
            if (curIndex == -1)
            {
                decryptedString += l;
                continue;
            }
            int realIndex = GetRealIndex(curIndex, possibleKey);
            decryptedString += Utillitys.allowedChars[realIndex];
            counter++; 
        }

        return decryptedString;
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
