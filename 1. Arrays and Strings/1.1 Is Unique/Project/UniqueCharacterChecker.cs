using System;

namespace Project;

public class UniqueCharacterChecker : IUniqueCharacterChecker
{
    public bool HasAllUniqueCharacter(string text)
    {
        if(String.IsNullOrEmpty(text))
            throw new ArgumentNullException();

        for (int i = 0; i < text.Length; i++)
        {
            int numberOfCurrentCharOccurrences = 0;

            for (int j = 0; j < text.Length; j++)
            {
                if (text.Substring(j, 1) == text.Substring(i, 1) && numberOfCurrentCharOccurrences > 0)
                    return false;

                if (text.Substring(j, 1) == text.Substring(i, 1))
                    numberOfCurrentCharOccurrences++;
            }
        }

        return true;
    }
}

