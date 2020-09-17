using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monotone
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            //var alpha = new TestFile3();

            //alpha.testFunc();

            //Console.WriteLine("\nProgram Complete. Press any key to continue...");
            //Console.ReadKey();
        }
    }
}
