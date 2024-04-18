using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EredmenyekCLI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());*/
            EredmenyRepository.Path = "eredmenyek.txt";
            Eredmeny silvana = EredmenyRepository.FindById(128);
            Console.WriteLine(silvana);
            Console.WriteLine();
            List<Eredmeny> eredmeny = EredmenyRepository.FindAll();
            
            foreach (Eredmeny eredmenyek in eredmeny)
            {
                Console.WriteLine(eredmeny);
            }
            Console.ReadKey();
        }
    }
}
