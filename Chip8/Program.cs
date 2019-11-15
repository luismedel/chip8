using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chip8
{
    class Program
    {
        [STAThread]
        static void Main (string[] args)
        {
            Application.EnableVisualStyles ();
            Application.Run (new FMain ());
        }
    }
}
