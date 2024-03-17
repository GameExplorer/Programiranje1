namespace Kolokvij2016;

class Program
{
    class Ulomek
    {
        public static int st = 1;
        private int stevec, imenovalec;

        public double Pretvorba()
        {
            return 0;
        }

        public static string OpisUlomka()
        {
            return "";
        }

        private void Krajsaj()
        {
        }
    }

    class Tajnica
    {
        public string naziv;
        public string opis;
        private double cena;

        public Tajnica(string naziv, string opis, double cena)
        {
            this.naziv = naziv;
            this.opis = opis;

            if (cena < 0) cena = 0;
            this.cena = cena;
        }
    }

    class MotoGP
    {
        public string motor;
        public string drzava;
        private int tocke;

        public MotoGP(string motor, string drzava)
        {
            this.motor = motor;
            this.drzava = drzava;
            this.tocke = 0;
        }

        public void SpremeniTocke(int noveTocke)
        {
            if (tocke > 0)
            {
                tocke = noveTocke;
            }

            Console.WriteLine("Točke ne smejo biti negativne");
        }
    }
    static void Main(string[] args)
    {
        Ulomek U1 = new Ulomek();

        Ulomek.st++;

        StreamWriter sw = File.CreateText("Stevila.txt");
        Random rnd = new Random();
        int stevec = 0;

        do
        {
            int n = rnd.Next(100, 201);
            if (n % 2 == 0)
            {
                sw.WriteLine(n);
                stevec++;
            }
        } while (stevec < 1000);
        
        sw.Close();

        Tajnica t1 = new Tajnica("COO", "Tajnica", 124);
        Tajnica t2 = new Tajnica("AA", "sda", 152);

        StreamReader beri = File.OpenText("MotoGP.txt");
        string vrstica = beri.ReadLine();

        double vsota = 0;
        double povp = 0;
        int stVrstic = 0;
        while (vrstica != null)
        {
            string[] podatki = vrstica.Split(";");

            vsota += Double.Parse(podatki[1]);
            stVrstic++;
            vrstica = beri.ReadLine();
        }

        povp = vsota / stVrstic;
        Console.WriteLine("Povprečni čas je " + povp);

        MotoGP[] tabMoto = new MotoGP[20];

        /*for (int i = 0; i < tabMoto.Length; i++)
        {
            
            Console.Write("Vnesi ime motorja: ");
            string vnos = Console.ReadLine();
            tabMoto[i].motor = vnos;
            string motor = tabMoto[i].motor;
            
            Console.Write("Vnesi drzavo: ");
            tabMoto[i].drzava = Console.ReadLine();
            string drzava = tabMoto[i].drzava;
            
            tabMoto[i] = new MotoGP(motor, drzava);
        }*/


        Datoteka("Test1.txt");

    }
    public static int zapStevka = 1;

    public static void Datoteka(string imeDatoteke)
    {
        if (File.Exists(imeDatoteke))
        {
            File.Create(imeDatoteke + zapStevka);
            zapStevka++;
        }
        else
        {
            StreamWriter pisi = File.CreateText(imeDatoteke);
            pisi.WriteLine("Povprecne cene izdelkov:");

            for (int i = 0; i < 80; i++)
            {
                pisi.Write("*");
            }
            pisi.WriteLine();
            for (int i = 0; i < 10; i++)
            {
                Console.Write("Vnesi stevilo: ");
                pisi.Write(Console.ReadLine() + " ");
            }
            
            pisi.Close();
        }
    }
}