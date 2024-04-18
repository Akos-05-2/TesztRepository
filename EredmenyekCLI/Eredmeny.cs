using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EredmenyekCLI
{
    class Eredmeny
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Subject { get; set; }
        public int Percent { get; set; }
        public int Mark
        {
            get
            {
                if (Percent < 25)
                {
                    Mark = 1;
                }
                else if (Percent >= 25 && Percent <= 39)
                {
                    Mark = 2;
                }
                else if (Percent >= 40 && Percent <= 59)
                {
                    Mark = 3;
                }
                else if (Percent >= 60 && Percent <= 79)
                {
                    Mark = 4;
                }
                else if (Percent >= 80 && Percent <= 100)
                {
                    Mark = 5;
                }
                return Mark;
            }
            set { }
        }

        public override string ToString()
        {
            return $"Eredmény: <{FirstName} {LastName}: {Subject}, {Percent}, {Mark}>";
        }

        public static Eredmeny CreateFromLine(string line, char seperator = ',')
        {
            string[] values = line.Split(seperator);
            return new Eredmeny
            {
                Id = int.Parse(values[0]),
                FirstName = values[1],
                LastName = values[2],
                Subject = values[3],
                Percent = int.Parse(values[4]),
                Mark = int.Parse(values[5])

            };
        }
    }
}
