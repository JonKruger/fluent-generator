using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentGenerator.Extensions
{
    public static class StringArrayExtension
    {
        public static string[] After(this string[] array, string value)
        {
            return array.Reverse().TakeWhile(s => !s.Contains(value)).Reverse().ToArray();
        }
    }
}
