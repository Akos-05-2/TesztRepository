using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EredmenyekCLI
{
    class EredmenyRepository
    {
        public static string Path { get; set; }
        public static bool SkipHeader { get; set; } = true;
        public static char Separator { get; set; } = ',';
        public static List<Eredmeny> FindAll()
        {
            using (StreamReader reader = new StreamReader(Path))
            {
                if (SkipHeader)
                {
                    reader.ReadLine();
                }
                List<Eredmeny> eredmenyek = new List<Eredmeny>();
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    Eredmeny eredmeny = Eredmeny.CreateFromLine(line, Separator);
                    eredmenyek.Add(eredmeny);
                }
                return eredmenyek;
            }
        }
    }
}
