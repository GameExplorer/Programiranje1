// See https://aka.ms/new-console-template for more information

namespace Kolokvij1
{
    class Program
    {
        public static void Main(String[] args)
        {
            
            // 2013

            //Kolokvij_2013();
            
            // 2014
            //Kolokvij_2014();
            
            
            // 2015
            
            //Kolokvij_2015();
            
            // 2016

            //Kolokvij_2016();
            
            // 2017

            //Kolokvij_2017();
            
            // 2018

            //Kolokvij_2018();
            
            // 2019

            //Kolokvij_2019();
            
            // 2021
            
            //Kolokvij_2021();
            
            // 2022

            //Kolokvij_2022();
            
            // 2022 - 2
            Kolokvij_2022_2();

        }
        
        // ***** 2013 *****
        public static void Kolokvij_2013()
        {
            string st = "Programiranje 1";
            Console.WriteLine("Znaki: " + st[2]);
            Console.WriteLine("Besede: " + st[1] + st[2] + st[3]);

            double a;
            int b = 2;
            a = Izracunaj9(1, b);
            Console.WriteLine(a);
            
            Console.Write("Vnesi besedo: ");
            string vnos1 = Console.ReadLine();

            Console.Write("Vnesi besedo: ");
            string vnos2 = Console.ReadLine();
            
            Console.WriteLine("{0}.{1}.", vnos1[0], vnos2[0]);
            
            if(vnos1.Length > vnos2.Length) Console.WriteLine(vnos1);
            else Console.WriteLine(vnos2);
            
            Console.WriteLine(vnos1);

            string novStavek = "";

            for(int i = 0; i < vnos2.Length; i++) {
                novStavek = vnos2[i] + novStavek;
            }

            Console.WriteLine(novStavek);
            
            int[] tabela = new int[100];
            Random rnd = new Random();
            int stevec  = 0;

            //Polnimo tabelo
            for(int i = 0; i < tabela.Length; i++) {
                tabela[i] = rnd.Next(-5,5);
            }

            //Preverjamo pogoj
            for(int i = 0; i < tabela.Length; i++) {
                if(tabela[i] > 0) stevec++;
            }
            
            Console.WriteLine("{0} števil je večjih od 0", stevec);

            int izpis = PikeInVejice("Ta metoda, vrne število vejic (,) in pik (.) v stavku.");
            Console.WriteLine("Število pik in vejic v stavku je {0}", izpis);
        }

        public static double Izracunaj9(int x, int b)
        {
            double c = 1 + Math.Pow(b, 3);
            c = c - x;
            return c;
        }
        
        public static int PikeInVejice(string stavek) {
            int stevec = 0;

            for(int i = 0; i < stavek.Length; i++) {
                if(stavek[i] == '.' || stavek[i] == ',') stevec++;
            }

            return stevec;
        }
        
        // ******************************
        
        // ***** 2014 *****
        public static void Kolokvij_2014()
        {
            string st = "RAČUNALNIŠTVO";
            Console.WriteLine(st.Length);
            Console.WriteLine("Znaki: " + st[2] + st[2] + st[0]);

            double x = (Math.Pow(3, 3) + Math.Sqrt(1) / Math.Round(0.9876));
            Console.WriteLine(x);
            
            bool logicna1 = !('2' < '9' || 5 != 3);
            Console.WriteLine(logicna1);
            
            //Console.WriteLine("Razlika" + 8 -3); //NAPAKA: Cannot apply operator '-' to operands of type 'string' and 'int'
            
            double a;
            int b = 5;
            a = Obdelaj(2, b);
            Console.WriteLine(a);
            //Console.ReadKey();
            
            int rezultati = Vaja("Malica", 5);
            Console.WriteLine("Rezultati: {0} ", rezultati);
            
            Branje();

            int rez = Izračun(-3);
            Console.WriteLine("Rezultat je {0}", rez);

            Tabela();
        }
        
        public static double Obdelaj(int x, int b)
        {
            double c = b - x + 6;
            c = 2 + Math.Sqrt(c);
            return c;
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
        
        // ******************************

        // ***** 2015 *****
        public static void Kolokvij_2015()
        {
            bool logicna = !("X" != "y" || 5 % 3 < 9);
            Console.WriteLine(logicna);

            //string izraz = 10 - 2 + " >" + 2 - 10; //Napaka
            //Console.WriteLine(izraz);
            
            Console.WriteLine("K" + 1 + 2);
            
            double a=2;
            int b = 3;
            a = Obdelaj2(a , b);
            Console.WriteLine(a);
            Console.ReadKey();

            string vnos = Vaja2("Nova Gorica", 'a');
            Console.WriteLine("Rezultat je {0}", vnos);
            Besedilna();
            Tabela2();
            double rez = Računanje(8);
            Console.WriteLine("Rezultat je {0}", rez);

        }
        
        public static double Obdelaj2(double x, int k)
        {
            double zacasna=0;
            for (int i=1;i<3;i++)
                zacasna=zacasna + x * k;    
            double c = 2 + Math.Pow(zacasna,2);                          
            return c;
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
        
        public static void Tabela2()
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

        
        // ******************************

        
        // ***** 2016 *****
        public static void Kolokvij_2016()
        {
            string primer2 = 10 - 2 + "=" + 3 + 5; //prvega izračuna drugi del skupaj da
            Console.WriteLine(primer2);
            string primer = 80 / 8 + " = 7 + 3"; //izračuna + string
            Console.WriteLine(primer);

            string primer3 = 10 - 2 + "<" + 2 + 10; //minus ne moremo uporabiti pri drugem delu
            Console.WriteLine(primer3);
            
            int a3 = 2;
            int b3 = 3;
            a3 = Obdelaj3(a3, b3);
            Console.WriteLine(a3);
            Console.ReadKey();

            Console.WriteLine("Dolžina niza je " + Vaja3("Dr. France Prešern", 4));
            
            Console.Write("Vnesi kraj: ");
            string kraj = Console.ReadLine();

            while (kraj.Length < 1)
            {
                Console.Write("Vnesi kraj z vsaj 1 znakom: ");
                kraj = Console.ReadLine();
            }

            if (kraj[0] == kraj[kraj.Length - 1])
            {
                Console.WriteLine("Znaka sta enaka!");
            }

            int stevecZnakov = 0;
            for (int i = 0; i < kraj.Length; i++)
            {
                stevecZnakov++;
            }

            Console.WriteLine("Število znakov v nizu je: {0}", stevecZnakov);

            int[,] tabela = new int[5, 3];
            int stevec = 0;

            Random rnd = new Random();

            for (int i = 0; i < tabela.GetLength(0); i++)
            {
                for (int j = 0; j < tabela.GetLength(1); j++)
                {
                    if (i == 0 && j == 0)
                    {
                        tabela[i, j] = rnd.Next(10, 21);
                    }
                    else if (j == 0)
                    {
                        tabela[i, j] = tabela[i - 1, tabela.GetLength(1) - 1] - 2;
                    }
                    else
                    {
                        tabela[i, j] = tabela[i, j - 1] - 2;
                    }

                    if (tabela[i, j] % 3 == 0) stevec++;
                }
            }
            
            Console.WriteLine("Število števil, ki so deljiva s 3 je {0}", stevec);
        }
        
        public static int Obdelaj3(int n, int k)
        {
            int zacasna=20;
            for (int i = 3; i >= 0; i--)
                zacasna = zacasna - (n + k);
            int m = 2 + zacasna*zacasna;                  
            return m;
        }
        
        public static int Vaja3(string beseda, int st)
        {
            string zacasna = "";
            for (int i = st; i < beseda.Length; i++)
            {
                if (beseda[i] >= 'A' && beseda[i] <= 'Z')    
                    zacasna = zacasna + beseda[i];
            }
            return zacasna.Length;
        }
        
        public static double Izračunaj3(int m)
        {
            int produkt = 1;

            if (m % 2 == 0)
            {
                for (int i = 1; i < m; i++)
                {
                    produkt *= i; //začnem z 1 drugače vse 0
                }

                return produkt;
            }

            return Math.Pow(m, 2) - Math.Sqrt(m);
        }
        
        // ******************************

        // ***** 2017 *****
        public static void Kolokvij_2017()
        {
            string racun = 10 % 8 + " = -(4+4)";
            Console.WriteLine(racun);

            //Console.WriteLine(7 - 3 = " = Razlika " +4); //Napaka

            bool logicna = (5 != (3 + 2) || 'A' == 'a');
            Console.WriteLine(logicna);

            string izraz = 10 + 2 + " = " + 1 + 2;
            Console.WriteLine(izraz);

            int a = 7;
            int b = 2;
            a = Obdelaj4(a, b);
            Console.WriteLine("Rezultat je: " + a + " " + b);

            string rez = Obdelava4("Kolokvij", 4);
            Console.WriteLine("Rezultat je {0}", rez);

            Console.Write("Vnesi ime: ");
            string vnos = Console.ReadLine();

            while (vnos.Length < 2)
            {
                Console.Write("Vnesi ime z vsaj dvema znakoma: ");
                vnos = Console.ReadLine();
            }

            vnos = vnos[0].ToString().ToUpper() + vnos.Substring(1); //prva velika črka + ostali del
            Console.WriteLine(vnos);

            int stevec = 0;
            for (int i = 0; i < vnos.Length; i++)
            {
                if (vnos[i] != 'a') stevec++;
            }

            Console.WriteLine("Število znakov različnih od a je {0}", stevec);

            string novoIme = "";

            for (int i = 0; i < vnos.Length; i++)
            {
                novoIme = vnos[i] + novoIme;
            }

            Console.WriteLine("Ime v obratni smeri: {0}", novoIme);

            int[,] tabela = new int[2, 10];
            Random rnd = new Random();

            for (int i = 0; i < tabela.GetLength(0); i++)
            {
                for (int j = 0; j < tabela.GetLength(1); j++)
                {
                    if (i == 0 && j == 0)
                    {
                        tabela[i, j] = rnd.Next(1, 7);
                    }
                    
                    else if (j == 0)
                    {
                        tabela[i, j] = tabela[i - 1, tabela.GetLength(1) - 1] * 2;
                    }

                    else
                    {
                        tabela[i, j] = tabela[i, j - 1] * 2;
                    }

                    //Console.WriteLine(tabela[i,j]);
                }
            }

            Console.Write("Elementi v prvem stolpcu: ");
            for (int i = 0; i < tabela.GetLength(0); i++)
            {
                for (int j = 0; j < tabela.GetLength(1); j++)
                {
                    if (j == 0)
                    {
                        Console.Write(tabela[i,j] + " ");

                    }
                }
            }

            Console.WriteLine();
            
            double rez2 = Izračunaj4(-15);
            Console.WriteLine("Metoda vrne {0}", rez2);
            
        }

        public static int Obdelaj4(int n, int k)
        {
            int zacasna = 1;
            for (int i = 0; i <= 3; i++)
            {
                zacasna = n - (zacasna + k);
            }

            int m = 2 + zacasna * zacasna;
            return m;
        }
        
        public static string Obdelava4(string beseda, int st)
        {
            string zacasna = "";
            for (int i = 0; i < st; i++)
            {
                if (beseda[i] == 'K' || beseda[i]=='o')
                    zacasna = zacasna + beseda[i];
            }
            return zacasna;
        }

        public static double Izračunaj4(int m)
        {
            if (m % 2 == 0 && m != 0)
            {
                return Math.Sqrt(m);
            }
            if (m <= 0) return 0;
            
            return Math.Pow(m, 5);

        }

        
        // ******************************


        // ***** 2018 *****
        public static void Kolokvij_2018()
        {
            double rezultat = 11 % 3 - 10 / 3;
            Console.WriteLine(rezultat);

            string racun = 12 - 3 * 2 + " = 3 + 3";
            Console.WriteLine(racun);

            Console.WriteLine("Vsota " + 7 + 3 + " = " + (7+3));

            bool logicna = (15 > 3 + 4 * 2);
            Console.WriteLine(logicna);

            //string izraz = 10 - 2 + " = " + 1 + 1 - 2;

            int a = 2;
            int b = 3;
            a = Izracunaj5(a, b);
            b++;
            Console.WriteLine(a + " " + b);

            string vnos = Obdelava5(4, "To je to");
            Console.WriteLine(vnos);
            
            Console.Write("Vnesi besedilo: ");
            string besedilo = Console.ReadLine();

            while (besedilo.Length <= 5 || besedilo.Contains(' '))
            {
                Console.Write("Vnesi niz z več kot 5 znaki in brez presledkov: ");
                besedilo = Console.ReadLine();
            }

            int stevec = 0;

            for (int i = 0; i < besedilo.Length; i++)
            {
                if (besedilo[i] >= 'A' && besedilo[i] <= 'Z') stevec++;
            }
            
            Console.WriteLine("Število velikih črk angleške abecede je {0}", stevec);

            for (int i = 0; i < 10; i++)
            {
                Console.Write(besedilo + " ");
            }

            int[] tabela = new int[25];
            Random rnd = new Random();

            for (int i = 0; i < tabela.Length; i++)
            {
                if (i == 0)
                {
                    tabela[i] = rnd.Next(1, 11);
                }
                else
                {
                    tabela[i] = -1;
                }
                
                tabela[tabela.Length - 1] = rnd.Next(1, 11);

                Console.WriteLine(tabela[i]);
                
                Izpis5(7);
            }

        }
        
        public static int Izracunaj5(int n, int k)
        {
            int zacasna = 0;
            while (zacasna<=10)
                zacasna = n + (zacasna + k);
            int m = 2 * zacasna;
            return m;
        }
        
        public static string Obdelava5(int stevilo, string stavek)
        {
            string zacasna = "";
            for (int i = 0; i < stevilo; i++)
            {
                zacasna = zacasna + stavek[i];
                if (stavek[i] != ' ')         //POZOR: ' ' je PRESLEDEK!!!
                    zacasna = zacasna + '.';  //POZOR: '.' je ZNAK pika!
            }
            return zacasna;
        }

        public static void Izpis5(int m)
        {
            for (int i = 1; i <= 10 * m; i++)
            {
                if (i % m == 0)
                {
                    Console.Write("BUM ");
                }
                else
                {
                    Console.Write(i + " ");
                }
            }
        }


        // ******************************
        
        
        // ***** 2019 *****

        public static void Kolokvij_2019()
        {
            string racun = 1 + 4 * 2 + " != 1" + 0;
            Console.WriteLine(racun);

            //Console.WriteLine("Razlika" + 5 - 3 + " = " + 2);

            bool logicna = (2 + 4 != 2 * 3);
            Console.WriteLine(logicna);

            string izraz = 10 - 2 * 4 + " == " + 8;
            Console.WriteLine(izraz);

            int a = 3;
            int b = 10;
            a = Izracunaj6(a, b);
            b++;
            Console.WriteLine(a + " " + b);

            string rez = Obdelava6("Very easy");
            Console.WriteLine(rez);
            
            string niz;
            bool vsebujeCifro = false;

            do
            {
                Console.Write("Vnesite poljuben niz: ");
                niz = Console.ReadLine();

                foreach (char znak in niz)
                {
                    if (Char.IsDigit(znak))
                    {
                        vsebujeCifro = true;
                        break;
                    }
                }

                if (!vsebujeCifro)
                {
                    Console.WriteLine("Niz mora vsebovati vsaj eno cifro (znake med '0' in '9'). Poskusite znova.");
                }

            } while (!vsebujeCifro);

            int stevec = 0;
            niz = niz.ToLower();

            for (int i = 0; i < niz.Length; i++)
            {
                if (niz[i] == 'a' || niz[i] == 'u' || niz[i] == 'e' || niz[i] == 'i' || niz[i] == 'o') stevec++;
            }

            Console.WriteLine("Število samoglasnikov v nizu je {0}", stevec);

            for (int i = 0; i < niz.Length; i++)
            {
                Console.WriteLine(niz);
            }

            int[] tabela = new int[50];
            Random rnd = new Random();

            int stevec2 = 0;

            for (int i = 0; i < tabela.Length; i++)
            {
                tabela[i] = rnd.Next(-100, 101);
                //Console.WriteLine(tabela[i]);
            }
            
            for (int i = 0; i < tabela.Length; i++)
            {
                if (tabela[i] == 0) stevec2++;
            }

            Console.WriteLine("Število števil, ki so enaka 0 je {0}", stevec2);

            Izis6("Sobota", 'o');
        }

        public static int Izracunaj6(int n, int k)
        {
            while (n <= k)
            {
                n = n + k % n;
                n++;
            }

            int m = 2 * n;
            return m;
        }
        
        public static string Obdelava6(string stavek)
        {
            int stevilo = stavek.Length;
            for (int i = 0; i < stevilo; i=i+2)
            {
                if (stavek[i]==' ')   //POZOR: ' ' je PRESLEDEK!!!
                    stavek = '*' + stavek;
                else if (stavek[i] != '.')        
                    stavek = stavek + 'X'; 
            }
            return stavek;
        }

        public static void Izis6(string stavek, char znak)
        {
            int stevec = 0;

            for (int i = 0; i < stavek.Length; i++)
            {
                if (stavek[i] != znak) stevec++;
            }

            Console.WriteLine("{0} znakov je različnih od {1}", stevec, znak);
        }
        
        // ******************************


        // ***** 2021 *****

        public static void Kolokvij_2021()
        {
            double rezultat = 10 + 10 % 7 - 4 / 3;
            Console.WriteLine(rezultat);

            //string racun = 10 + " != " + 1 - 1;

            string vsota = "Vsota : " + 5 + (3 - 2);
            Console.WriteLine(vsota);

            bool logicna = (4 * 4 != 8 * 2);
            Console.WriteLine(logicna);

            int a = 2;
            int b = 6;
            a = Izracunaj7(a, b);
            b++;
            Console.WriteLine(a + " " + b);

            Naloga("Datum: 1.2.2021", 1);
            
            Console.Write("Vnesi negativno število: ");
            double znesek = Double.Parse(Console.ReadLine());
            
            while(znesek > 0) {
                Console.Write("Vnesti morate negativno število: ");
                znesek = Double.Parse(Console.ReadLine());
            }
            
            int stevec = 0;
            string tmp = znesek.ToString();

            for(int i = 0; i < tmp.Length; i++) {
                if(tmp[i] == '0') stevec++;
            }
            Console.WriteLine("V znesku je {0} ničel", stevec);
            
            znesek = (Math.Sqrt(Math.Pow(znesek,3) - Math.Pow(2.5,4)) + (1/3)) / (3 * Math.Pow(znesek,2));
            Console.WriteLine(znesek);
            
            double[,] tabela = new double[10,10];
            Random rnd = new Random();
            int stevec2 = 0; 

            for(int i = 0; i < tabela.GetLength(0); i++) {
                for(int j = 0; j < tabela.GetLength(1); j++) {
                    tabela[i,j] = -rnd.NextDouble() * 100 - 5;
                    Console.WriteLine(tabela[i,j]);
                }
            }


            for(int i = 0; i < tabela.GetLength(0); i++) {
                for(int j = 0; j < tabela.GetLength(1); j++) {
                    if(tabela[i,j] < 12 && i == j) stevec2++;
                }
            }

            Console.WriteLine("V tej tabeli je {0} števil, ki so manjša od 12 in ležijo na diagonali", stevec);

            string rez = Podvoji("Kolovrat", 'o');
            Console.WriteLine(rez);
            
            int x = 33;
            if (x > 0 && x <=50)
                Console.WriteLine("nezadostno");
            else
            {
                if (x == 33)
                {
                    Console.WriteLine("Točno 33");
                }
                else
                {
                    if (x < 70)
                    {
                        Console.WriteLine("dobro");
                    }
                    else
                    {
                        if (x < 80)
                        {
                            Console.WriteLine("prav dobro");
                        }
                        else

                            Console.WriteLine("odlicno");
                    }
                }
            }

        }
        
        public static string Podvoji(string stavek, char znak)
        {
            string novStavek = "";
            for(int i = 0; i < stavek.Length; i++) {

                if(stavek[i] == znak)
                {
                    novStavek += stavek[i].ToString() + znak;
                }
                else
                {
                    novStavek += stavek[i];
                }
            }
            return novStavek;
        }

        public static int Izracunaj7(int n, int k)
        {
            do
            {
                n = n + n / k;
                n++;
                Console.Write(n + " ");
            } while (n <= k);

            int m = 2 - n;
            return m;
        }

        public static void Naloga(string stavek, int cifra)
        {
            int števec = 0;

            for (int i = 0; i < stavek.Length; i++)
            {
                if(stavek[i] > '0' && stavek[i] < '9') števec++;
                
                else Console.Write(stavek[i]);
            }
            
            Console.WriteLine("Število cifer je {0} ", števec);
        }

        
        // ******************************
        
        // ***** 2022 *****
        
        public static void Kolokvij_2022()
        {
            double rezultat = 10 % 6 + 10 / 4 - 1.5;
            Console.WriteLine(rezultat);
            //string vsota = " Vsota: " + 5 - (3-2));
            
            int a = 3, b = 7;
            a = Izracunaj8(a, b);
            a--;
            Console.WriteLine(a + " " + b);

            string rez = Naloga2("Datum: 18.2.2022", 0);
            Console.WriteLine(rez);
            
            Console.Write("Vnesi ime: ");
            string vnos = Console.ReadLine();

            while(vnos.Length <= 2) {
                Console.Write("Vnesi ime z več kot 2 znakoma: ");
                vnos = Console.ReadLine();
            }
            
            int stevec = 0;

            for(int i = 0; i < vnos.Length; i++) {
                if(vnos[i] == 'A' || vnos[i] == 'O') stevec++;
            }

            Console.WriteLine("Število samoglasnikov A in O v spremenljivki ime je {0}", stevec);
            
            double[,] tabela = new double[10,10];

            Random rnd = new Random();

            int stevec3 = 0;

            for(int i = 0; i < tabela.GetLength(0); i++) {
                for(int j = 0; j < tabela.GetLength(1); j++) {
                    tabela[i, j] = Math.Round(-rnd.NextDouble() * 11, 2);
                    Console.WriteLine(tabela[i,j]);
                }
            }

            for(int i = 0; i < tabela.GetLength(0); i++) {
                for(int j = 0; j < tabela.GetLength(1); j++) {
                    if(tabela[i,j]% 2 == 0 && i != j) stevec3++;
                }
            }

            Console.WriteLine("Števil, ki so soda in ne ležijo na diagonali je {0}", stevec);

            string izpis = UstvariNiz("Kranj", 4);
            Console.WriteLine(izpis);
            
            int x = 33;
            if (x / 3 > 0 && x % 2 != 0)
                Console.WriteLine(x);
            else Console.WriteLine("A");

            if (x > 33 || x < 50)
                Console.WriteLine(x-10);
            else Console.WriteLine("B");

            if (x - 33 != 0 )
                Console.WriteLine(x + 10);
            else Console.WriteLine("C");
      
            if (x + x != 2 * x)
                Console.WriteLine("D");
            else Console.WriteLine(x % 5);

        }

        public static int Izracunaj8(int n, int k)
        {
            while (n <= k)
            {
                n = n + n % k;
                n++;
                Console.Write(n + " ");
            }

            int m = 2 - n;
            return m;
        }
        
        public static string Naloga2(string stavek, int cifra)
        {
            int števec = 0;
            for (int i = 0; i < stavek.Length; i++)
            {
                if (stavek[i] >= '0' && stavek[i] <= '9')
                    števec++;
                else
                    cifra++;
            }
            return števec.ToString()+", "+ cifra;
        }

        public static string UstvariNiz(string stavek, int stevilo)
        {
            string novStavek = "";

            for (int i = 0; i < stavek.Length; i++)
            {
                novStavek += string.Concat(Enumerable.Repeat(stavek[i], stevilo));
            }

            return novStavek;

        }
        
        // ******************************
        
        // 
        public static void Kolokvij_2022_2()
        {
            int stv = 5;
            for (int i=0;i<stv;i++)
            {
                Console.Write("{0}:", i+1);
                for (int j = 0; j <= i; j++)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
            }
            
            int[] originalnaTabela = new int[50];
            Random rnd = new Random();

            Console.WriteLine("Števila v tabeli: ");
            for(int i = 0; i < originalnaTabela.Length; i++) {
                originalnaTabela[i] = rnd.Next(0,11);
                Console.Write(originalnaTabela[i] + " ");
            }

            int[] sodaTabela = new int[originalnaTabela.Length];
            int[] lihaTabela = new int[originalnaTabela.Length];

            for(int i = 0; i < originalnaTabela.Length; i++) {
                if(originalnaTabela[i] % 2 == 0) sodaTabela[i] = originalnaTabela[i];
                else lihaTabela[i] = originalnaTabela[i];
            }
            
            int[,] tabela = new int[10,5];

            for(int i = 0; i < tabela.GetLength(0); i++) {
                for(int j = 0; j < tabela.GetLength(1); j++) {
                    tabela[i,j] = i+1;
                }
            }

            double rez = Povprecje(tabela);
            Console.WriteLine();
            Console.WriteLine("Rezultat je {0}", rez);
            
            
            do
            {
                Console.WriteLine("Vpišite prvo število:");
                double prvoStevilo = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Vpišite operand (+, -, * ali /):");
                char operand = Convert.ToChar(Console.ReadLine());

                Console.WriteLine("Vpišite drugo število:");
                double drugoStevilo = Convert.ToDouble(Console.ReadLine());

                double rezultat = 0;

                switch (operand)
                {
                    case '+':
                        rezultat = prvoStevilo + drugoStevilo;
                        break;
                    case '-':
                        rezultat = prvoStevilo - drugoStevilo;
                        break;
                    case '*':
                        rezultat = prvoStevilo * drugoStevilo;
                        break;
                    case '/':
                        if (drugoStevilo != 0)
                        {
                            rezultat = prvoStevilo / drugoStevilo;
                        }
                        else
                        {
                            Console.WriteLine("Deljenje z 0 ni dovoljeno.");
                            continue;
                        }
                        break;
                    default:
                        Console.WriteLine("Napačen operand. Prosimo, vnesite +, -, * ali /.");
                        continue;
                }

                Console.WriteLine("Rezultat: " + rezultat);

                Console.WriteLine("Ali želite nadaljevati? (d/n)");
            } while (Console.ReadLine().ToLower() == "d");

            Console.WriteLine("Hvala, da ste uporabljali kalkulator. Nasvidenje!");

        }
        
        public static double Povprecje(int[,] tabela) {
            int vsota = 0;
            for(int i = 0; i < tabela.GetLength(0); i++) {
                for(int j = 0; j < tabela.GetLength(1); j++) {
                    vsota += tabela[i,j];
                }
            }
            double povprecje = (double) vsota / (tabela.GetLength(0) + tabela.GetLength(1));
            return povprecje;
        }
        
        
    }
}