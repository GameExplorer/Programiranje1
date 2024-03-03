
namespace ZglediOsnovnihRazredov
{
    class Krog
    {
        public double polmer; //polje razreda Krog

        public double Ploscina() //metoda razreda Krog
        {
            return Math.PI * Math.Pow(polmer, 2);
        }
    }

    class Zgradba
    {
        public int kvadratura;
        public int stanovalci;
        
        public double KvadraturaNaPosameznika()
        {
            return 1.0 * kvadratura / stanovalci;
        }

        public void Izpis()
        {
            Console.WriteLine("Zgradba z " + stanovalci + " stanovalci ima kvadraturo " + kvadratura +
                   ". Kvadratura na stanovalca je " +
                   KvadraturaNaPosameznika());
        }
    }

    class Klub
    {
        public string ime;
        public string priimek;
        public int letoVpisa;
        public string pozicija;

        public Klub(string ime, string priimek, int letoVpisa, string pozicija)
        {
            this.ime = ime;
            this.priimek = priimek;
            this.letoVpisa = letoVpisa;
            this.pozicija = pozicija;
        }

        public void Izpis()
        {
            Console.WriteLine("Igralec z imenom {0} {1} se je vpisal leta {2} in igra na poziciji {3}", ime, priimek, letoVpisa, pozicija);
        }
    }

    class Nepremicnine
    {
        public string ulica;
        public int stevilka;
        public string vrstaNepremicnine;

        public Nepremicnine(string ulica, int stevilka, string vrstaNepremicnine)
        {
            this.ulica = ulica;
            this.stevilka = stevilka;
            this.vrstaNepremicnine = vrstaNepremicnine;
        }

        public void Izpis()
        {
            Console.WriteLine("Na naslovu {0} je {1}", ulica, vrstaNepremicnine);
        }
    }

    class Trikotnik
    {
        public int a, b, c;

        public Trikotnik()
        {
            Random rnd = new Random();
            this.a = rnd.Next(1, 11);
            this.b = rnd.Next(1,11);

            while (true)
            {
                this.c = rnd.Next(1, 11);

                if (a + b > c && b + c > a && a + c > b)
                {
                    break;
                }
            }
        }
        
        //PREOBLEŽENA METODA
        public Trikotnik(int a, int b, int c)
        {
            //V tem primeru moramo nujno uporabiti this. Moramo razlikovati med 
            //spremenljivko a, ki označuje parameter metode (konstruktorja) in med poljem a. 
            //Le this ne uporabimo se vedno uporabi najblizja definicija spremenljivke.
            this.a = a;
            this.b = b;
            this.c = c;
        }
    }

    class Denarnica
    {
        private string ime;
        public double stanje;

        public Denarnica(string ime, double znesek)
        {
            this.ime = ime;
            stanje = znesek;
        }

        public void dvig(double znesek)
        {
            stanje -= znesek;
        }

        public void polog(double znesek)
        {
            stanje += znesek;
        }

        public void Izpis()
        {
            Console.WriteLine("Trenutno stanje na računu je {0}", stanje);
        }
    }

    class Prebivalstvo
    {
        public string ime;
        public int stPrebivalcev;
        public int povrsina;

        public Prebivalstvo(string ime, int stPrebivalcev, int povrsina)
        {
            this.ime = ime;
            this.stPrebivalcev = stPrebivalcev;
            this.povrsina = povrsina;
        }

        public double Gostota()
        {
            return 1.0 * stPrebivalcev / povrsina;
        }

        public void Izpis()
        {
            Console.WriteLine("Število prebivalcev na km2 je {0}", Gostota());
        }

    }

    class Prodajalec
    {
        public double[] zneski;

        public Prodajalec()
        {
            zneski = new double[12];
        }

        public double SkupnaLetnaProdaja()
        {
            double vsota = 0;

            for (int i = 0; i < zneski.Length; i++)
            {
                vsota += zneski[i];
            }

            return vsota;
        }
        
        public void IzpisLetneProdaje()
        {
            Console.WriteLine("Skupna letna prodaja: " + SkupnaLetnaProdaja() + " EUR");
        }
    }
    
    class Program
    {
        public static void Main(String[] args)
        {
            char izbira;

            do
            {
                Console.WriteLine("Izberi nalogo (1 - )");
                Console.WriteLine("1. Ploščina kroga");
                Console.WriteLine("2. Zgradba");
                Console.WriteLine("3. Klub");
                Console.WriteLine("4. Nepremicnice");
                Console.WriteLine("5. Trikotnik");
                Console.WriteLine("6. Denarnica");
                Console.WriteLine("7. Gostota prebivalstva");
                Console.WriteLine("8. Prodajalec");
                Console.WriteLine("X. Izhod");

                Console.Write("Izbira: ");
                izbira = Convert.ToChar(Console.ReadLine());
                
                switch (izbira)
                {
                    case '1':
                        Console.Clear();

                        Krog k1 = new Krog(); //ustvarimo objekt

                        Console.Write("Vnesi polmer kroga: ");
                        double vnos = Double.Parse(Console.ReadLine());

                        k1.polmer = vnos; //preberemo polmer

                        Console.WriteLine("Ploščina kroga s polmerom {0} je {1}", vnos, k1.Ploscina()); //izpis ploščine
                        
                        Console.WriteLine("\nPritisni tipko za nadaljevanje...");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case '2':
                        Console.Clear();

                        Zgradba hiša = new Zgradba();
                        hiša.stanovalci = 10;
                        hiša.kvadratura = 450;

                        hiša.Izpis();

                        Zgradba pisarna = new Zgradba();
                        pisarna.stanovalci = 17;
                        pisarna.kvadratura = 2500;
                        
                        pisarna.Izpis();
                        
                        Console.WriteLine("\nPritisni tipko za nadaljevanje...");
                        Console.ReadKey();
                        Console.Clear();

                        break;
                    
                    case '3':
                        Console.Clear();

                        Klub igralec = new Klub("Lionel", "Messi", 2004, "FW");
                        igralec.Izpis();
                        
                        
                        Console.WriteLine("\nPritisni tipko za nadaljevanje...");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case '4':
                        Console.Clear();

                        Nepremicnine zgradba = new Nepremicnine("Bleiwesova ulica 4, Kranj", 4, "Poslovna Stavba");
                        zgradba.Izpis();
                        
                        Console.WriteLine("\nPritisni tipko za nadaljevanje...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    
                    case '5':
                        Console.Clear();

                        Trikotnik trikotnik1 = new Trikotnik();
                        
                        Console.WriteLine("Stranice trikotnika so: {0}, {1}, {2}", trikotnik1.a, trikotnik1.b, trikotnik1.c);

                        Trikotnik trikotnik2 = new Trikotnik(3, 5, 3);
                        Console.WriteLine("Stranice trikotnika so: {0}, {1}, {2}", trikotnik2.a, trikotnik2.b, trikotnik2.c);
                        
                        Console.WriteLine("\nPritisni tipko za nadaljevanje...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    
                    case '6':
                        Console.Clear();

                        Denarnica denar = new Denarnica("Miha", 300);
                        
                        //začetno stanje
                        denar.Izpis();
                        
                        //dvignemo denar
                        denar.dvig(200);
                        denar.Izpis();
                        
                        //položimo denar
                        denar.polog(150);
                        denar.Izpis();
                        
                        Console.WriteLine("\nPritisni tipko za nadaljevanje...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    
                    case '7':
                        Console.Clear();

                        Prebivalstvo gostota = new Prebivalstvo("Slovenija", 2000000, 21000);
                        
                        gostota.Izpis();
                        
                        Console.WriteLine("\nPritisni tipko za nadaljevanje...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    
                    case '8':
                        Console.Clear();

                        Prodajalec prodaja = new Prodajalec();

                        for (int i = 1; i <= 12; i++)
                        {
                            Console.Write("Vnesi znesek prodaje za {0}. mesec: ", i + " ");
                            prodaja.zneski[i - 1] = Convert.ToDouble(Console.ReadLine());
                        }
                        
                        prodaja.IzpisLetneProdaje();
                        
                        Console.WriteLine("\nPritisni tipko za nadaljevanje...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    
                    case 'X':
                    case 'x':
                        Console.WriteLine("Zapiranje...");
                        break;

                    default:
                        Console.WriteLine("Nepravilna izbira! Poskusi ponovno");
                        break;
                }
            } while (izbira != 'x' && izbira != 'X');
        }
    }
}