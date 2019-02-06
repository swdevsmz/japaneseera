using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JapaneseEraClassLibrary
{
    class main
    {
        [STAThread]
        public static void Main()
        {
            Console.WriteLine(JapaneseEra.GetYMD(new DateTime(2019, 04, 01)));

            //var a = new JapaneseEra();

            Console.WriteLine(DateTime.Parse("1868-01-25"));
        }
    }
}
