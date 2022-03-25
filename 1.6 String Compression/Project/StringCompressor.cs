using System;
using System.Linq;
using System.Text;

namespace Project;

public class StringCompressor : IStringCompressor
{
    public string Compress(string text)
    {
        if (String.IsNullOrEmpty(text))
            throw new ArgumentNullException();

        StringBuilder o_compressedText = new();

        int numberOfCurrentCharRepetition = 0;

        for (int i = 0; i < text.Length; i++)
        {
            numberOfCurrentCharRepetition++;

            char currentChar = text[i];
            char nextChar = text.ElementAtOrDefault(i + 1);

            if(currentChar != nextChar)
            {
                o_compressedText.Append(currentChar + numberOfCurrentCharRepetition.ToString());
                numberOfCurrentCharRepetition = 0;
            }
        }

        return (o_compressedText.Length < text.Length) ? o_compressedText.ToString() : text;
    }
}

