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
        public static Eredmeny Save(Eredmeny eredmenyek)
        {
            List<Eredmeny> eredmeny = FindAll();
            if (eredmenyek.Id == 0)
            {
                int maxId = 0;
                for (int i = 0; i < eredmeny.Count; i++)
                {
                    if (eredmeny[i] > maxId)
                    {
                        maxId = eredmeny[i];
                    }
                }
                eredmenyek.Id = maxId + 1;
                eredmeny.Add(eredmenyek);
            }
            else
            {
                for (int i = 0; i < eredmeny.Count; i++)
                {
                    if (eredmeny[i].Id == eredmenyek.Id)
                    {
                        eredmeny[i] = eredmenyek;
                        break;
                    }
                }
            }
            return eredmenyek;
        }

        public static Eredmeny FindById(int id)
        {
            foreach (Eredmeny eredmenyek in FindAll())
            {
                if (eredmenyek.Id == id)
                {
                    return eredmenyek;
                }
            }
        }
    }
}
