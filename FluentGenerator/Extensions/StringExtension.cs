using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FluentGenerator.Extensions
{
    public static class StringExtension
    {
        public static string[] ToLinesArray(this string s)
        {
            return Regex.Split(s, "\r\n");
        }

        public static string After(this string s, string after)
        {
            if (s == null)
                throw new ArgumentNullException("s");
            if (after == null)
                throw new ArgumentNullException("after");

            int index = s.IndexOf(after);
            if (index == -1)
                throw new InvalidOperationException("String not found.");
            return s.Substring(index + after.Length);
        }

        public static string ToCamelCaseUnderscore(this string s)
        {
            if (s == null)
                return null;

            if (s.StartsWith("_") || s == "")
                return s;

            string result = "_" + s.Substring(0, 1).ToLower();
            if (s.Length > 1)
                result += s.Substring(1);
            return result;
        }
    }
}
