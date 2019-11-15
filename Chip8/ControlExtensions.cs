using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chip8
{
    public static class ControlExtensions
    {
        public static void InvokeEx (this Control ctrl, Action action)
        {
            if (ctrl.InvokeRequired)
                ctrl.Invoke (action);
            else
                action.Invoke ();
        }
    }
}
