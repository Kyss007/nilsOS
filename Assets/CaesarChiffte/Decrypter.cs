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
            Console.WriteLine($"Processing character: {l}");

            // Überprüfung des ersten Zeichens
            if (i == 0 && l != '+' && !Char.IsDigit(l))
            {
                Console.WriteLine("Invalid first character");
                return "this is not a number!";
            }

            // Überprüfung auf mehrere '+'-Zeichen
            if (!alreadyHadAPlus && l == '+')
            {
                alreadyHadAPlus = true;
            }
            else if (alreadyHadAPlus && l == '+')
            {
                Console.WriteLine("Multiple '+' characters detected");
                return "this is not a number!";
            }

            // Überprüfung, ob das Zeichen in den erlaubten Zeichen enthalten ist
            if (!Utillitys.allowedChars.Contains(l))
            {
                Console.WriteLine("Character not in allowedChars");
                return "this is not a number!";
            }

            // Entschlüsselung des Zeichens
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
