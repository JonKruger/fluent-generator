using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentGenerator.Extensions;

namespace FluentGenerator
{
    public class CodeWriter : ICodeWriter
    {
        private StringBuilder _stringBuilder = new StringBuilder();
        private int _currentIndent;

        public bool UseSpaces { get; set; }
        public int IndentAmount { get; set; }

        public int Length
        {
            get { return _stringBuilder.Length; }
        }

        public CodeWriter()
        {
            UseSpaces = true;
            IndentAmount = 4;
        }

        public void IncreaseIndent()
        {
            _currentIndent += IndentAmount;    
        }

        public void DecreaseIndent()
        {
            _currentIndent -= IndentAmount;
            if (_currentIndent < 0)
                _currentIndent = 0;
        }

        public ICodeWriter Append(string s)
        {
            if (UseSpaces)
            {
                for (int i = 0; i < _currentIndent; i++)
                    _stringBuilder.Append(" ");
            }
            else
            {
                if (IndentAmount > 0)
                {
                    for (int i = 0; i < _currentIndent / IndentAmount; i++)
                        _stringBuilder.Append("\t");
                }
            }
            _stringBuilder.Append(s);
            return this;
        }

        public ICodeWriter AppendLine()
        {
            return AppendLine(string.Empty);
        }

        public ICodeWriter AppendLine(string s)
        {
            Append(s + Environment.NewLine);
            return this;
        }

        public ICodeWriter AppendLineFormat(string s, params object[] args)
        {
            if (args != null && args.Length > 0)    
                Append(string.Format(s, args));
            else
                Append(s);
            _stringBuilder.AppendLine();
            return this;
        }

        public override string ToString()
        {
            return _stringBuilder.ToString();
        }
    }
}
