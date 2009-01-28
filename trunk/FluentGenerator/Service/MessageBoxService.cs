using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FluentGenerator.Service
{
    public class MessageBoxService : IMessageBoxService
    {
        public DialogResult Show(string message, string title)
        {
            return MessageBox.Show(message, title);
        }
    }
}
