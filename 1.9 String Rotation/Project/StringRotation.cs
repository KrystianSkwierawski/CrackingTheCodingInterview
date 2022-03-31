using System;

namespace Project;

public class StringRotation : IStringRotation
{
    public bool IsRotation(string s1, string s2)
    {
        if (String.IsNullOrEmpty(s1) || String.IsNullOrEmpty(s2))
            throw new ArgumentNullException();

        if (s1.Length != s2.Length)
            return false;


        //erbottlewat => erbottle[waterbottle]wat
        if ((s1 + s1).Contains(s2))
            return true;


        //waterbottle => wat[erbottlewat]erbottle
        if ((s2 + s2).Contains(s1))
            return true;

        return false;
    }
}

