using System;
using System.Text;

namespace Project;

public class URLify : IURLify
{
    public string ToURL(string text, int trueLength)
    {
        if (String.IsNullOrEmpty(text))
            throw new ArgumentNullException();

        StringBuilder o_url = new(
                text.Substring(0, trueLength)
            );

        o_url.Replace(" ", "%20");

        return o_url.ToString();
    }
}

