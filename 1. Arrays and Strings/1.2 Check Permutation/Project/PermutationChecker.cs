using System;
using System.Collections.Generic;
using System.Linq;

namespace Project;

public class PermutationChecker : IPermutationChecker
{
    public bool IsPermutation(string text1, string text2)
    {
        if (String.IsNullOrEmpty(text1) || String.IsNullOrEmpty(text2))
            throw new ArgumentNullException();

        if (text1.Length != text2.Length)
            return false;

        IList<char> text1List = text1.ToList();
        IList<char> text2List = text2.ToList();

        foreach (var @char in text1.ToCharArray())
        {
            if (!text2List.Contains(@char))
                return false;

            if (text2List.Contains(@char))
            {
                text1List.Remove(@char);
                text2List.Remove(@char);
            }
        }

        return true;
    }
}

