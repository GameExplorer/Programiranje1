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
            /*long ts1 = Stopwatch.GetTimestamp();
            for (int i = 0; i < 1000_000_000; i++)
            {
                //Console.WriteLine(i);
                //System.Threading.Thread.Sleep(1000);
            }

            long ts2 = Stopwatch.GetTimestamp();
            
            Console.WriteLine("Time: " + (ts2 - ts1) / 1000000000 + " s");*/
            
            #endregion
            
            #region Nizi in PadLeft

            //Obrni niz
            /*String besedilo = "Danes je ponedeljek.";
            String obrniNiz = "";

            for (int i = 0; i < besedilo.Length; i++)
            {
                obrniNiz = besedilo[i] + obrniNiz;
            }
            
            Console.WriteLine(obrniNiz);*/

            /*char a = 'a';
            Console.WriteLine((int)a);*/ //če ga castam dobim ASCII cifro, sicer črko
            
            //ASCII TABELA
            /*for (int i = 0; i < 255; i++)
            {
                Console.WriteLine(i + ": " + (char)i);
            }
            */

            char znak = 'a';
            char znak2 = 'b';
            Console.WriteLine(znak + znak2); //pretvori se v int 195 ju sešteje
            Console.WriteLine(znak.ToString() + znak2); // ali "" + znak + znak2

            //STEVILO STEVK V BESEDILU
            /*String besedilo2 = "Danes 15.1.2024 je bilo -4 stopinje Celzija zjutraj!";
            int k = 0;
            int steviloStevk = 0;

            while (k < besedilo2.Length)
            {
                char znaki = besedilo2[k]; //tekoči znak niza
                if ('0' <= znaki && znaki <= '9') steviloStevk++;
                k++;
            }
            Console.WriteLine("V staku je " + steviloStevk + " stevil");*/

            /*string besedilo3 = "Programiranje 1";
            string noviNiz2 = besedilo3.Insert(0, "C# ");
            Console.WriteLine(noviNiz2);
            noviNiz2 = besedilo3.Remove(3, 6);
            Console.WriteLine(noviNiz2);*/

            /*string kaj = "" + znak + znak2; // ... ab
            Console.WriteLine(kaj[0]); // ... a*/

            /*kaj = 'x' + kaj.Substring(1);
            Console.WriteLine(kaj);*/

            //kaj = kaj.Replace('a', 'x'); //nov string, ker je a zamenjan z x-om, stari string smo izgubili
            //GC.Collect(); //Garbage collector
            //Console.WriteLine(kaj);

            /*kaj = kaj.Remove(0, 1).Insert(0, "X");
            
            Console.WriteLine("abcdef".Substring(3,2)); //izpiše de
            Console.WriteLine(kaj);
            Console.WriteLine("abcdefg".Remove(3,2)); //de izbrisana
            Console.WriteLine("abcdefg".Remove(3,2).ToUpper());

            string niz = "abcdefg";*/

            /*for (int i = 0; i < niz.Length; i++)
            {
                Console.WriteLine(niz[i]);
            }*/
            
            /*Console.WriteLine(niz.PadLeft(20, '*')); //lepa poravnava pri izpisu
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
            Console.WriteLine("Ime: ".PadLeft(10, ' ') + "Miha");
            Console.WriteLine("Priimek: ".PadLeft(10, ' ') + "Rupnik");
            Console.WriteLine("Ocena: ".PadLeft(10, ' ') + "8");

            string test = "asda5123c";

            string rez = "";

            // ODSTRANIMO ŠTEVILKE IZ NIZA
            for (int i = 0; i < test.Length; i++)
            {
                if (!char.IsDigit(test[i]))
                {
                    rez = rez + test[i];
                }
            }

            Console.WriteLine(rez);*/
            
            //ŠTEVILO SAMOGLASNIKOV V BESEDILU
            /*Console.Write("Vnesi poljuben stavek: ");
            string stavek = Console.ReadLine();
    
            string samogl = "AaEeIiOoUu";
            int stSam = 0, stStevk = 0;//začetno število samoglasnikov in števk
            for (int i = 0; i < stavek.Length; i++)
            {
                char znakec = stavek[i];
                if (samogl.IndexOf(znakec) != -1)  //  znak je samoglasnik
                    stSam = stSam + 1;
                if ('0' <= znakec && znakec <= '9')  //znak je števka
                    stStevk = stStevk + 1;
            }
            Console.WriteLine("\nŠtevilo znakov v staku: " + stavek.Length);
            Console.WriteLine("Število samoglasnikov   : " + stSam);
            Console.WriteLine("Število cifer           : " + stStevk);
            Console.WriteLine("Število ostalih znakov  : " + (stavek.Length - stSam - stStevk));*/


            #endregion
            
            #region Tabele

            int[] tabela = new int[] { 20, 21, 22 };

            for (int i = 0; i < tabela.Length; i++)
            {
                Console.WriteLine(tabela[i]);
            }

            //Izpis števil v obratnem vrstnem redu
            string beri;
            int[] tab2 = new int[5]; //ustvarimo tabelo, je prazna so 0 notri
            for (int i = 0; i <= 4; i++) //Vnesemo vrednosti v tabelo
            {
                Console.Write("Vnesi število: ");
                beri = Console.ReadLine();
                tab2[i] = Int32.Parse(beri);
            }

            Console.WriteLine();

            for (int j = 0; j <= 4; j++) //Izpis vrednosti iz tabele
            {
                Console.Write(tab2[j] + " "); //izpiše števila
            }

            //  Vnos niza
            Console.Write("Vnesi niz: ");
            string niz = Console.ReadLine();
            //  Pretvorba niza v tabelo nizov
            string[] tab3 = niz.Split(' ');
            //  Iskanje najdaljše besede
            string pomozni = "";  //  Najdaljša beseda (oz. podniz)
            for (int i = 0; i < tab3.Length; i++)
            {
                if (pomozni.Length < tab3[i].Length)
                {
                    pomozni = tab3[i];
                }
            }
            //  Izpis najdaljše besede
            Console.WriteLine("Najdaljša beseda: " + pomozni);


            Array.Resize(ref tabela, tabela.Length+1); //dobita dva parametra, referenco na tabelo in drug parameter je za koliko jo želimo razširiti

            tabela[tabela.Length - 1] = 23; //vstavimo vrednost v tabelo 1 ... 4 gre mi pa odštejemo - 1 in ga vstavimo na 3 indexu zadnje mesto v tabeli
            
            Console.WriteLine(tabela[3]);
            
            Console.WriteLine();
            Console.WriteLine("Element shifting: ");
            
            //shift elementov v levo.. lahko pride prav pri seminarski ... 20 se izgubi.. 21 gre na 20.. 22 gre na 21.. 23 na 22. mesto
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