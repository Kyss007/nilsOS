using System.Linq;
using System.Text;
using System;

public static class Decrypter
{
    public static string DecryptString(int possibleKey, string secret)
    {
        StringBuilder decryptedString = new StringBuilder();
        bool alreadyHadAPlus = false;

        for (int i = 0; i < secret.Length; i++)
        {
            char l = secret[i];
            if (i == 0 && l != '+' && l != '0')
            {
                return "this is not a number!";
            }

            if (!alreadyHadAPlus && l == '+')
            {
                alreadyHadAPlus = true;
            }
            else if (alreadyHadAPlus && l == '+')
            {
                return "this is not a number!";
            }

            if (!Utillitys.allowedChars.Contains(l))
            {
                return "this is not a number!";
            }

            int curIndex = Array.IndexOf(Utillitys.allowedChars, l);
            if (curIndex == -1)
            {
                decryptedString.Append(l);
                continue;
            }
            int realIndex = GetRealIndex(curIndex, possibleKey);
            decryptedString.Append(Utillitys.allowedChars[realIndex]);
        }

        return decryptedString.ToString();
    }

    public static int GetRealIndex(int index, int key)
    {
        int newIndex = (index - key + Utillitys.allowedChars.Length) % Utillitys.allowedChars.Length;
        return newIndex;
    }
}