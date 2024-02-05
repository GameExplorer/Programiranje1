// See https://aka.ms/new-console-template for more information

namespace Vaje6
{
    class Program
    {
        public static void Main(String[] args)
        {
            //1. Naloga
            //PregledPodatkovForEach();
            
            //2. Naloga
            //SwitchStavek();
            
            //3. Naloga
            //Pravokotnik();

            //4. Naloga
            //KlicMetodeZnotrajZanke();

            //5. Naloga
            //IskanjeSumljiveBesede();

            //6. Naloga
        }

        public static void PregledPodatkovForEach()
        {
            int[,] tabela = new int[10, 10];
            Random rnd = new Random();
            int vsota = 0;
            double povpVrednost = 0;

            //napolnim tabelo
            for (int i = 0; i < tabela.GetLength(0); i++)
            {
                for (int j = 0; j < tabela.GetLength(1); j++)
                {
                    tabela[i,j] = rnd.Next(1, 1001);
                    Console.WriteLine(tabela[i,j]);
                }
            }

            //sprehod po elementih in izračun povprečne vrednosti
            foreach (int stevilka in tabela)
            {
                vsota += stevilka;
            }

            //delim vsoto z številom vseh elementov in dobim povprečje
            povpVrednost = ((double)vsota / tabela.GetLength(0)) / tabela.GetLength(1);
            Console.WriteLine("Povprečna vrednost v tabeli je {0}", povpVrednost);
            
        }
        
        public static void SwitchStavek()
        {
            Console.Write("Vnesi prvo število: ");
            int st1 = Int32.Parse(Console.ReadLine());

            Console.Write("Vnesi drugo število: ");
            int st2 = Int32.Parse(Console.ReadLine());

            
            
            while (true)
            {
                Console.Clear();
                
                Console.WriteLine("Vnesi prvo število {0}:", st1);
                Console.WriteLine("Vnesi drugo število: {0}",st2);
                
                Console.WriteLine();
                Console.WriteLine("Katero operacijo nad števili želite izvesti");
                Console.WriteLine("A - Seštevanje");
                Console.WriteLine("B - Odštevanje");
                Console.WriteLine("C - Množenje");
                Console.WriteLine("D - Deljenje");
                Console.WriteLine("X - Izhod");

            
                Console.Write("Izberite možnost: ");
                char izbira = Console.ReadLine().ToLower()[0];
                Console.WriteLine();
                
                switch (izbira)
                {
                    case 'a':
                        Console.WriteLine("Vsota števil {0} in {1} je {2}", st1, st2, (st1+st2));
                        break;
                    case 'b':
                        Console.WriteLine("Razlika števil {0} in {1} je {2}", st1, st2, (st1-st2));
                        break;
                    case 'c':
                        Console.WriteLine("Produkt števil {0} in {1} je {2}", st1, st2, (st1*st2));
                        break;
                    case 'd':
                        Console.WriteLine("Rezultat deljenja števil {0} in {1} je {2}", st1, st2, (st1/st2));
                        break;
                    case 'x':
                        Console.WriteLine("Hvala za uporabo programa. \nNasvidenje!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Izbrana možnost ni na voljo \nProsim izberite eno od danih možnosti!");
                        break;
                }

                Console.ReadLine();

            }
        }

        public static void Pravokotnik()
        {
            Console.Write("Vnesi stranico a: ");
            double a = Double.Parse(Console.ReadLine());

            Console.Write("Vnesi stranico b: ");
            double b = Double.Parse(Console.ReadLine());

            double rezultat = Ploscina(a, b);
            Console.WriteLine("Ploščina pravokotnika je {0} e^2", rezultat);
        }
        
        public static double Ploscina(double a, double b)
        {
            return Math.Round(a * b, 2);
        }

        public static void KlicMetodeZnotrajZanke()
        {
            int[,] tabela = new int[10, 10];
            Random rnd = new Random();

            //napolnimo tabelo
            for (int i = 0; i < tabela.GetLength(0); i++)
            {
                for (int j = 0; j < tabela.GetLength(1); j++)
                {
                    tabela[i, j] = rnd.Next(0, 1001);
                }
            }
            
            //Pregledujemo vse elemente
            foreach (int stevilka in tabela)
            {
                string rez = PreveriUstreznost(stevilka);
                Console.WriteLine("{0} - {1}", stevilka, rez);
            }
        }

        public static string PreveriUstreznost(int stevilka)
        {
            if (stevilka % 2 == 0) return "Število je deljivo z 2";
            if (stevilka % 3 == 0) return "Število je deljiva z 3";
            if (stevilka % 5 == 0) return "Število je deljiva z 5";

            return " Ni deljivo z 2, 3 ali 5";
        }

        public static void IskanjeSumljiveBesede()
        {
            string niz = "V mirnem mestu je živel nenavaden besedni tat, ki je ponoči kradel samo črke 'a' in 'u'. " +
                         "Prebivalci so prejemali čudna sporočila, vsa brez teh dveh ključnih črk. Vsak dan " +
                         "so postajali bolj radovedni, kdo je ta skrivnostni tat. Končno so ga odkrili, ko so " +
                         "ga zalotili v trenutku, ko je skušal ukrasti 'u' s krajevnega znaka. Kljub svojemu nenavadnemu " +
                         "hobiju si je pridobil simpatije in postal del mestne folklore.";

            string[] tabelaBesed = niz.Split(new char[] { ' ', ',', '.' }); //razdelimo besede, separatorji so presledki, vejice ali pike

            foreach (string beseda in tabelaBesed)
            {
                bool rez = PreveriBesedo(beseda);
                
                if(rez) Console.WriteLine("Beseda <{0}> je sumljiva", beseda);
            }
            
        }

        public static bool PreveriBesedo(string beseda)
        {
            if (beseda.Contains('a') && beseda.Contains('u'))
            {
                return true;
            }

            return false;
        }
    }
}