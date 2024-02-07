// See https://aka.ms/new-console-template for more information

namespace Kolokvij1
{
    class Program
    {
        public static void Main(String[] args)
        {
            double rezz = Računanje(26);
            Console.WriteLine(rezz);
            
            Naloga72();
            Besedilna();
            string klic = Vaja2("Ljubljana", 'j');
            Console.WriteLine(klic);
            KlicObdelaj();
            Tabela();
            int rez = Izračun(-3);
            Console.WriteLine("Rezultat je {0}", rez);

            bool logicna = !("X" != "y" || 5 % 3 < 9);
            Console.WriteLine(logicna);

            string izraz = 10 - 2 + " >";
            Console.WriteLine(izraz);
            
            Console.WriteLine("K" + 1 + 2);
            string st = "RAČUNALNIŠTVO";
            Console.WriteLine(st.Length);
            Console.WriteLine("Znaki: " + st[2] + st[2] + st[0]);

            double x = (Math.Pow(3, 3) + Math.Sqrt(1) / Math.Round(0.9876));
            Console.WriteLine(x);

            double a;
            int b = 5;
            a = Obdelaj(2, b);
            Console.WriteLine(a);
            //Console.ReadKey();

            int rezultati = Vaja("Malica", 5);
            Console.WriteLine("Rezultati: {0} ", rezultati);

            Branje();
        }

        public static void Besedilna()
        {
            
            Console.Write("Vnesi besedo z več kot 3 znaki: ");
            string vnos = Console.ReadLine();
            while (vnos.Length < 4)
            {
                Console.Write("Vnesi besedo z več kot 3 znaki: ");
                vnos = Console.ReadLine();
            }

            for (int i = 0; i < vnos.Length; i++)
            {
                int index = vnos.IndexOf(vnos[i]);

                if (index % 2 == 0)
                {
                    Console.WriteLine(vnos[i]);
                }
            }

            string sredina = vnos.Insert(vnos.Length / 2, "PP");
            Console.WriteLine(sredina);
        }

        public static void Naloga72()
        {
            int[,] tabela = new int[10, 2];
            int stevec = 0;

            for (int i = 0; i < tabela.GetLength(0); i++)
            {
                for (int j = 0; j < tabela.GetLength(1); j++)
                {
                    if (i == 0 && j == 0) tabela[i, j] = 2001;
                    else if (j == 0)
                    {
                        //dobimo prejšno vrednost in jo zmanjšamo za 1 in nastavimo na trenutni stolpec
                        tabela[i, j] = tabela[i - 1, tabela.GetLength(1) - 1] - 1;
                    }
                    else
                    {
                        tabela[i, j] = tabela[i, j - 1] - 1;
                    }
                    
                    Console.WriteLine(tabela[i,j]);
                    
                    if (tabela[i, j] % 3 == 0) stevec++;
                }
            }

            Console.WriteLine("{0} števil je deljivih s 3", stevec);
        }
        
        public static double Računanje(int m) {
            int vsota = 0;

            if(m % 2 == 0) {
                for(int i = 0; i < m; i++) {
                    if(i % 9 == 0) vsota += i;
                }

                return vsota;
            }
    
            return Math.Sqrt(m);
        }
        
        public static string Vaja2(string beseda, char znak)
        {
            string zacasna = "";
            for (int i = 0; i < beseda.Length; i++)
            {
                if (beseda[i] != znak || beseda[i] == ' ')   //' ' je presledek!!!
                    zacasna = zacasna + beseda[i];
                else  zacasna = zacasna + '.';
            }
            return zacasna;
        }


        public static double Obdelaj(double x, int k)
        {
            double zacasna=0;
            for (int i=1;i<3;i++)
                zacasna=zacasna + x * k;    
            double c = 2 + Math.Pow(zacasna,2);                          
            return c;
        }

        public static void KlicObdelaj()
        {
            double a=2;
            int b = 3;
            a = Obdelaj(a , b);
            Console.WriteLine(a);
            Console.ReadKey();
        }


        public static int Izračun(int m)
        {
            int vsota = 0;

            if (m > 0)
            {
                for (int i = 0; i < m; i++)
                {
                    vsota += i;
                }

                return vsota;
            }

            return (int)Math.Pow(m, 3);
        }

        public static void Tabela()
        {
            int[,] tabela = new int[4, 3];
            Random rnd = new Random();
            int stevec = 0;

            for (int i = 0; i < tabela.GetLength(0); i++)
            {
                for (int j = 0; j < tabela.GetLength(1); j++)
                {
                    if (i == 0 && j == 0)
                    {
                        // Za prvi element generiraj naključno celo število med -3 in 3
                        tabela[i, j] = rnd.Next(-3, 4);
                    }
                    else if (j == 0)
                    {
                        // Za prvi stolpec v vsaki vrstici uporabi prejšnji stolpec prve vrstice + 5
                        tabela[i, j] = tabela[i - 1, tabela.GetLength(1) - 1] + 5;
                    }
                    else
                    {
                        // Za vsak naslednji stolpec v vrstici dodaj 5 prejšnji vrednosti v tem stolpcu
                        tabela[i, j] = tabela[i, j - 1] + 5;
                    }

                    Console.WriteLine(tabela[i,j]);
                    
                    if (tabela[i, j] % 2 != 0) stevec++;

                }

            }

            Console.WriteLine("Število lihih števil je {0}", stevec);
        }

        public static void Branje()
        {
            Console.Write("Vnesi besedo: ");
            string beseda = Console.ReadLine();
            Console.Write("Vnesi dolžino: ");
            int n = Convert.ToInt32(Console.ReadLine());

            // Preveri dolžino besede
            if (beseda.Length <= n)
            {
                // Izpiši celotno besedo
                Console.WriteLine("Prvih {0} znakov besede \"{1}\" je: {2}", beseda.Length, beseda, beseda);
            }
            else
            {
                // Izpiši prvih N znakov besede
                Console.WriteLine("Prvih {0} znakov besede \"{1}\" je: {2}", n, beseda, beseda.Substring(0, n));
            }

            Console.WriteLine("Izpis besede večkrat: ");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(beseda);
            }

            Console.WriteLine("Pike za črkami: ");
            for (int i = 0; i < beseda.Length; i++)
            {
                Console.Write(beseda[i] + ".");
            }
        }

        public static int Vaja(string beseda, int n)
        {
            int st = 0;
            for (int i = 0; i < n; i++)
            {
                if (beseda[i] != 'a') st++;
            }

            return st;
        }
        
        public static double Obdelaj(int x, int b)
        {
            double c = b - x + 6;
            c = 2 + Math.Sqrt(c);
            return c;
        }
    }
}