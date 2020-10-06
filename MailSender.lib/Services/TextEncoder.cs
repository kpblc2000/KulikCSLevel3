using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfMailSender.Services
{
    public static class TextEncoder
    {
        public static string Encoder(string SourceString, int Key = 1)
        {
            return new string(SourceString.Select(c => (char)(c + Key)).ToArray());
        }

        public static string Decode(string StringToDecode, int Key = 1)
        {
            return new string(StringToDecode.Select(c => (char)(c - Key)).ToArray());
        }

    }
}
