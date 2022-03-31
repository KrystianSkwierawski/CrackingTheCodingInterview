using System;
using System.Linq;
using System.Text;

namespace Project;

public class OneAwayChecker : IOneAwayChecker
{
    public bool IsOneAway(string text1, string text2)
    {
        if (String.IsNullOrEmpty(text1) || String.IsNullOrEmpty(text2))
            throw new ArgumentNullException();

        var isCorrectLength = IsCorrectLength(text1, text2);
        if (!isCorrectLength) return false;


        if (text1 == text2) return true;

        var isOneCharInserted = IsOneCharInserted(text1, text2);
        if (isOneCharInserted) return true;

        var isOneCharRemoved = IsOneCharRemoved(text1, text2);
        if (isOneCharRemoved) return true;

        var isOneCharReplaced = IsOneCharReplaced(text1, text2);
        if (isOneCharReplaced) return true;

        return false;
    }

    private bool IsCorrectLength(string text1, string text2)
    {
        if (text1.Length == text2.Length) return true;

        if ((text1.Length - 1) == text2.Length) return true;

        if ((text1.Length + 1) == text2.Length) return true;

        return false;
    }


    private bool IsOneCharInserted(string text1, string text2)
    {
        if (text1.Length < text2.Length)
        {
            StringBuilder temp = new();
            int numberOfInsertedChars = 0;

            for (int i = 0; i < text2.Length; i++)
            {
                char currentChar = text2[i];

                if (text1.ElementAtOrDefault(i - numberOfInsertedChars) != currentChar)
                    numberOfInsertedChars++;

                if (numberOfInsertedChars > 1)
                    return false;

                temp.Append(currentChar);
            }

            return (temp.ToString() == text2) ? true : false;
        }


        if (text1.Length > text2.Length)
        {
            StringBuilder temp = new();
            int numberOfInsertedChars = 0;

            for (int i = 0; i < text1.Length; i++)
            {
                char currentChar = text1[i];

                if (text2.ElementAtOrDefault(i - numberOfInsertedChars) != currentChar)
                    numberOfInsertedChars++;

                if (numberOfInsertedChars > 1)
                    return false;

                temp.Append(currentChar);
            }

            return (temp.ToString() == text1) ? true : false;
        }


        return false;
    }

    private bool IsOneCharRemoved(string text1, string text2)
    {
        if (text1.Length < text2.Length)
        {
            StringBuilder temp = new();
            int numberOfRemovedChars = 0;

            for (int i = 0; i < text2.Length; i++)
            {
                char currentChar = text2[i];

                if (text1.ElementAtOrDefault(i - numberOfRemovedChars) != currentChar)
                    numberOfRemovedChars++;

                if (numberOfRemovedChars > 1)
                    return false;

                temp.Append(currentChar);
            }

            return (temp.ToString() == text2) ? true : false;
        }


        if (text1.Length > text2.Length)
        {
            StringBuilder temp = new();
            int numberOfRemovedChars = 0;

            for (int i = 0; i < text1.Length; i++)
            {
                char currentChar = text1[i];

                if (text2.ElementAtOrDefault(i - numberOfRemovedChars) != currentChar)
                    numberOfRemovedChars++;

                if (numberOfRemovedChars > 1)
                    return false;

                temp.Append(currentChar);
            }

            return (temp.ToString() == text1) ? true : false;
        }

        return false;
    }
    private bool IsOneCharReplaced(string text1, string text2)
    {
        if (text1.Length != text2.Length) return false;

        StringBuilder temp = new();
        int numberOfReplacedChars = 0;


        for (int i = 0; i < text1.Length; i++)
        {
            if (numberOfReplacedChars > 1)
                return false;

            char currentChar = text1[i];

            if (!(text2[i] == currentChar))
                numberOfReplacedChars++;

            temp.Append(currentChar);
        }


        return true;
    }
}

