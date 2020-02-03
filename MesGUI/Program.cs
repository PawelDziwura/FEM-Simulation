using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsMES
{
    static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        
        [STAThread]
        static void Main()
        {
            void Run()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MesForm());
            }
            Thread Start = new Thread(
                new ThreadStart(Run));
            Start.Start();
        }
    }
}
