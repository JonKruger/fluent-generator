using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FluentGenerator.Extensions
{
    public static class StringExtension
    {
        public static string[] IntoLines(this string s)
        {
            return Regex.Split(s, "\r\n");
        }
    }
}
