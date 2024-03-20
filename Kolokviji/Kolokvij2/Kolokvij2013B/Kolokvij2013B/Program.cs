namespace Kolokvij2013B;

class Program
{
    class Krog
    {
        public int polmer;
    }

    class Morje
    {
        private double globina;
        public string ime;

        public Morje(double c, string p)
        {
            globina = c;
            ime = p;
        }
    }

    class Zival
    {
        private int steviloNog;
        private string ime;

        public Zival(int stNog, string ime)
        {
            steviloNog = stNog;
            this.ime = ime;
        }

        public int StNog()
        {
            return steviloNog;
        }
    }
    static void Main(string[] args)
    {
        Datoteka("Znaki.txt");
        Krog K1 = new Krog();
        K1.polmer = K1.polmer + 11;

        Morje M1 = new Morje(7800, "Atlantik");

        Zival Z1 = new Zival(4, "Pes");
        Zival Z2 = new Zival(2, "Orel");

        int skupno = Z1.StNog() + Z2.StNog();
        Console.WriteLine("Skupno število nog " + skupno);

        Zival[] zivali = new Zival[10];

        for (int i = 0; i < zivali.Length; i++)
        {
            Console.Write("Vnesi št. nog: ");
            int noge = Int32.Parse(Console.ReadLine());

            Console.Write("Vnesi ime živali: ");
            string imeVnos = Console.ReadLine();

            zivali[i] = new Zival(noge, imeVnos);
        }
        
        StreamReader beri = File.OpenText("Cenik.txt");
        string vrstica = beri.ReadLine();

        int zapStevilka = 1;

        while (vrstica != null)
        {
            Console.WriteLine(zapStevilka + ". " + vrstica);
            zapStevilka++;

            vrstica = beri.ReadLine();
        }

        beri.Close();

        StreamWriter pisi = File.CreateText("Stavki.txt");

        for (int i = 0; i < 5; i++)
        {
            Console.Write("Vnesi besedo: ");
            string vnos = Console.ReadLine();
            pisi.WriteLine(vnos);
        }
        
        pisi.Close();
    }

    public static void Datoteka(string imeDatoteke)
    {
        if (!File.Exists(imeDatoteke))
        {
            Console.WriteLine("Datoteka s tem imenom ne obstaja!");
        }
        else
        {
            StreamReader beri = File.OpenText("Znaki.txt");
            string vrstica = beri.ReadLine();

            int vsota = 0;

            while (vrstica != null)
            {
                string[] podatki = vrstica.Split("|");

                vsota += Int32.Parse(podatki[1]);

                vrstica = beri.ReadLine();
            }

            Console.WriteLine("Skupno število znakov je " + vsota);
            beri.Close();
        }
    }
}