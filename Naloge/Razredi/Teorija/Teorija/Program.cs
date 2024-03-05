

namespace Teorija
{
    class Zajec
    {
        public string serijska;
        public bool spol;
        public double masa;
        
    }

    class Pesem
    {
        public string naslov;
        public int minute;
        public int sekunde;

        public Pesem(string naslov, int minute, int sekunde)
        {
            this.naslov = naslov;
            this.minute = minute;
            this.sekunde = sekunde;
        }
    }
    class Zgoscenka
    {
        public string avtor;
        public string naslov;
        public Pesem[] seznamPesmi; //Napoved tabele pesmi

        //določimo avtorja, naslov in vse pesmi
        public Zgoscenka(string avtor, string naslov, Pesem[] seznamPesmi)
        {
            this.avtor = avtor;
            this.naslov = naslov;
            this.seznamPesmi = new Pesem[seznamPesmi.Length]; //inicializiramo tabelo pesmi

            for (int i = 0; i < seznamPesmi.Length; i++)
            {
                //tabelo pesmi določimo s pomočjo parametra (tabele) seznamPesmi
                this.seznamPesmi[i] = new Pesem(seznamPesmi[i].naslov, seznamPesmi[i].minute, seznamPesmi[i].sekunde);
            }
        }
        
        //metoda za izračun skupne dolzine vseh skladb
        public int Dolzina()
        {
            int skupaj = 0;
            for (int i = 0; i < seznamPesmi.Length; i++)
            {
                skupaj += seznamPesmi[i].minute * 60 + seznamPesmi[i].sekunde;
            }

            return skupaj;
        }
    }

    class Avto
    {
        public string znamka;
        private int letnik;
        public string registrska;

        public Avto(string znamka, int leto, string stevilka)
        {
            this.znamka = znamka;
            letnik = leto;
            registrska = stevilka;
        }

        public bool SpremeniLetnik(int letnik)
        {
            if ((2000 <= letnik) && (letnik <= 2024))
            {
                this.letnik = letnik;
                return true; //leto je smiselno
            }

            return false; //leto ni smiselno
        }

        public override string ToString()
        {
            return "Znamka " + znamka + ", Letnik:" + letnik + ", Registrska številka: " + registrska;
        }
    }

    class Tocka
    {
        private int x, y;

        public Tocka()
        {
            x = 0;
            y = 0;
        }

        public Tocka(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        //metodi za spreminjanje koordinate X in y
        public void SpremeniX(int x)
        {
            this.x = x;
        }

        public void SpremeniY(int y)
        {
            this.y = y;
        }
        
        //metoda za izraun razdalje med dvema točkama
        public double RazdaljaOd(Tocka druga)
        {
            int xRazred = x - druga.x;
            int yRazred = y - druga.y;
            return Math.Sqrt(Math.Pow(xRazred, 2) + Math.Pow(yRazred, 2));
        }
    }
    
    class Program
    {
        public static void Main(String[] args)
        {
            #region ZAJEC

            //Ustvarimo objekt Zajec
            Zajec[] zajci;
            zajci = new Zajec[250]; //ustvarimo tabelo, ki bo velika 250 (250 zajcev)
            int i = 0;
            int kolikoZajcev = 10; //trenutno imamo 10 zajcev

            Random rnd = new Random();

            while (i < kolikoZajcev)
            {
                zajci[i] = new Zajec(); //nov zajec
                zajci[i].serijska = "1254 - " + i;
                zajci[i].spol = false;
                zajci[i].masa = rnd.NextDouble() * 10 + 1;

                i++;
            }

            #endregion

            #region ZGOŠČENKA

            Zgoscenka CD = new Zgoscenka("GNR", "Apetite for Destruction", new Pesem[]{new Pesem("Welcome to The Jungle", 3, 11), 
            new Pesem("Sweet Child o Mine", 4, 30),
            new Pesem("Paradise City", 4, 20)});

            Console.WriteLine("Zgoščenka skupine: " + CD.avtor + " Naslov albuma: " + CD.naslov);

            for (int k = 0; k < CD.seznamPesmi.Length; k++)
            {
                Console.WriteLine("Pesem št. {0} {1}", k+1, CD.seznamPesmi[k].naslov);
            }
            
            Console.WriteLine("Skupna dolzina vseh pesmi je {0} sekund", CD.Dolzina());
            
            Console.ReadKey();

            Console.Clear();
            
            #endregion
            
            #region AVTO

            Avto novAvto = new Avto("Ferrari", 2022, "KR DA-124");
            Console.WriteLine(novAvto.ToString());

            novAvto.SpremeniLetnik(92); //false NI dovoljeno
            Console.WriteLine(novAvto.ToString());

            novAvto.SpremeniLetnik(2018); //true JE dovoljeno
            Console.WriteLine(novAvto.ToString());
            Console.ReadKey();

            Console.Clear();

            #endregion
            
            #region Tocka

            Tocka tA = new Tocka(); //klic konstruktorja brez parametrov
            Tocka tB = new Tocka(6, 8); //klic konstruktorja z dvema parametroma

            double razdalja = tA.RazdaljaOd(tB);
            Console.WriteLine("Razdalja točke A od točke B je enaka {0} enot", razdalja);

            tB.SpremeniX(4);
            tB.SpremeniY(12);

            razdalja = tA.RazdaljaOd(tB);
            Console.WriteLine("Razdalja točke A od točke B je enaka {0} enot", razdalja);

            Console.ReadKey();

            #endregion
        }
    }
}