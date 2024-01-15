// See https://aka.ms/new-console-template for more information

using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace Predavanje3
{
    class Program
    {
        public static void Main(String[] args)
        {
            #region For Zanka
            long ts1 = Stopwatch.GetTimestamp();
            for (int i = 0; i < 1000_000_000; i++)
            {
                //Console.WriteLine(i);
                //System.Threading.Thread.Sleep(1000);
            }

            long ts2 = Stopwatch.GetTimestamp();
            
            Console.WriteLine("Time: " + (ts2 - ts1) / 1000000000 + " s");
            
            #endregion
            
            #region Nizi in PadLeft

            char a = 'a';

            for (int i = 0; i < 255; i++)
            {
                Console.WriteLine(i + ": " + (char)i);
            }

            char znak = 'a';
            char znak2 = 'b';
            Console.WriteLine(znak + znak2); //pretvori se v int 
            Console.WriteLine(znak.ToString() + znak2); // ali "" + znak + znak2

            string kaj = "" + znak + znak2;
            Console.WriteLine(kaj[0]);

            kaj = 'x' + kaj.Substring(1);
            Console.WriteLine(kaj);

            kaj = kaj.Replace('a', 'x'); //nov string, ker je a zamenjan z x-om, stari string smo izgubili
            GC.Collect();
            Console.WriteLine(kaj);

            kaj = kaj.Remove(0, 1).Insert(0, "X");
            
            Console.WriteLine("abcdef".Substring(3,2)); //izpiše de
            Console.WriteLine(kaj);
            Console.WriteLine("abcdefg".Remove(3,2)); //de izbrisana
            Console.WriteLine("abcdefg".Remove(3,2).ToUpper());

            string niz = "abcdefg";

            for (int i = 0; i < niz.Length; i++)
            {
                Console.WriteLine(niz[i]);
            }
            
            Console.WriteLine(niz.PadLeft(20, '*')); //lepa poravnava pri izpisu
            Console.WriteLine("Programiranje 1".PadLeft(20, '*'));
            
            String imeTest = "Ime: ";

            while (imeTest.Length < 10) //namesto PadLeft
            {
                imeTest = " " + imeTest;
            }
            
            Console.WriteLine(imeTest + "Jan");
            Console.WriteLine("Priimek: ".PadLeft(10, ' ') + "Robas");
            Console.WriteLine("Ocena: ".PadLeft(10, ' ') + "10");

            Console.WriteLine();
            Console.WriteLine("Ime: ".PadLeft(10, ' ') + "Jan");
            Console.WriteLine("Priimek: ".PadLeft(10, ' ') + "Robas");
            Console.WriteLine("Ocena: ".PadLeft(10, ' ') + "10");

            string test = "asda5123c";

            string rez = "";

            for (int i = 0; i < test.Length; i++)
            {
                if (!char.IsDigit(test[i]))
                {
                    rez = rez + test[i];
                }
            }

            Console.WriteLine(rez);

            #endregion
            
            #region Tabele

            int[] tabela = new int[] { 20, 21, 22 };

            for (int i = 0; i < tabela.Length; i++)
            {
                Console.WriteLine(tabela[i]);
            }

            Array.Resize(ref tabela, tabela.Length+1); //dobita dva parametra, referenco na tabelo in drug parameter je za koliko jo želimo razširiti

            tabela[tabela.Length - 1] = 23; //vstavimo vrednost v tabelo 1 ... 4 gre mi pa odštejemo - 1 in ga vstavimo na 3 indexu
            
            Console.WriteLine(tabela[3]);
            
            Console.WriteLine();
            Console.WriteLine("Drugi izpis");
            
            //shift elementov v levo.. lahko pride prav pri seminarski
            for (int i = 0; i < tabela.Length - 1; i++)
            {
                Console.WriteLine(tabela[i + 1]); //zadnji element
            }

            Array.Resize(ref tabela, tabela.Length-1); //znebimo se prvega elementa v tabeli
            
            int[] tab = new int[3]; //prazna tabela

            Console.WriteLine();

            #endregion

            #region List
            //Ni potrebno znati za PRO1 bolje uporabiti tabele
            
            List<int> list = new List<int> { 20,21,22};
            
            list.Add(23);
            
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }

            #endregion
        }
    }
}