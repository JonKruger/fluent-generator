using System.Windows.Forms;

namespace FluentGenerator.Service   
{
    public interface IMessageBoxService
    {
        DialogResult Show(string message, string title);
    }
}