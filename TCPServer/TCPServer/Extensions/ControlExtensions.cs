using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCPServer.Extensions
{
    public static class ControlExtensions
    {
        public static void Invoke(this Control control, Action action)
        {
            control.Invoke(new MethodInvoker(action));
        }
    }
}
