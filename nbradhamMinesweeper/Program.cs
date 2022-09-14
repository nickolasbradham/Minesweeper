using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nbradhamMinesweeper {
    static class Program {
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args) {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 form;
            if(args.Length==3)
                form=new Form1(short.Parse(args[0]),short.Parse(args[1]),short.Parse(args[2]));
            else
                form=new Form1(10,10,10);
            Application.Run(form);
        }
    }
}
