using System;

namespace Project;

public class UniqueCharacterChecker : IUniqueCharacterChecker
{
    public bool HasAllUniqueCharacter(string text)
    {
        if(String.IsNullOrEmpty(text))
            throw new ArgumentNullException();

        char[] textArr = text.ToCharArray();

        for (int i = 0; i < textArr.Length; i++)
        {
            int numberOfCurrentCharOccurrences = 0;

            foreach (var @char in textArr)
            {
                if (@char == textArr[i] && numberOfCurrentCharOccurrences > 0)
                    return false;

                if (@char == textArr[i] && numberOfCurrentCharOccurrences == 0)
                    numberOfCurrentCharOccurrences++;
            }
        }

        return true;
    }
}

