using System.Windows.Forms;

namespace TCPServer.Extensions
{
    public static class WebBrowserExtensions
    {
        public static void Display(this WebBrowser webBrowser, string message)
        {
            webBrowser.Invoke(() =>
            {
                webBrowser.DocumentText += message+ "<br /><hr />";
            });
        }
    }
}
