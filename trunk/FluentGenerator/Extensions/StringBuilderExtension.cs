using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentGenerator.Extensions
{
    public static class StringBuilderExtension
    {
        public static void AppendLineFormat(this StringBuilder sb, string s, params object[] args)
        {
            sb.AppendLine(string.Format(s, args));
        }
    }
}
