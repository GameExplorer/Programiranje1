

using System.Runtime.Intrinsics;

namespace Kolokvij2020
{
    class Vreme
    {
        public string kraj;
        private string datum;
        private int kolicinaPadavin;
        private double temperatura;
        public void Napoved() {}
    }

    class Zoga
    {
        public string proizvajalec;
        private double cena;
        private int kolicina;

        public Zoga()
        {
            proizvajalec = "";
            cena = -1;
            kolicina = -1;
        }

        public Zoga(string proizvajalec, double cena, int kolicina)
        {
            this.proizvajalec = proizvajalec;
            this.cena = cena;
            this.kolicina = kolicina;
        }
    }

    class Izlet
    {
        private string destinacija;
        private int dni;
        private double razdalja;

        public Izlet(string destinacija, double razdalja, int dni)
        {
            this.destinacija = destinacija;
            this.razdalja = razdalja;

            if (dni <= 0) Console.WriteLine("Število dni mora biti večje kot 0");
            else
            {
                this.dni = dni;
            }

        }

        public double RazdaljaNaDan()
        {
            return razdalja / dni;
        }

        public void IzpisPodatkov(Izlet[] tab)
        {
            for (int i = 0; i < tab.Length; i++)
            {
                Console.WriteLine(tab[i].destinacija + " " + tab[i].razdalja + " " + tab[i].dni);
            }
        }
    }
    
    class Program
    {
        public static void Main(String[] args)
        {
            Vreme V1 = new Vreme();

            Izlet I1 = new Izlet("Gran Canarija", 4000,32);
            Izlet I2 = new Izlet("Norveška", 2000,0);

            Console.WriteLine(I1.RazdaljaNaDan());
            Console.WriteLine(I2.RazdaljaNaDan());

            Izlet[] izleti = new Izlet[100];

            for (int i = 0; i < izleti.Length; i++)
            {
                string dest = "Finska";
                double raz = 2500;
                int dnevi = 36;

                izleti[i] = new Izlet(dest, raz, dnevi);
            }
            
            I1.IzpisPodatkov(izleti);

            StreamWriter pisi = File.CreateText("Podatki.txt");

            Random rnd = new Random();
            pisi.WriteLine(rnd.NextDouble());
            Console.Write("Vnesi stavek: ");
            string vnos = Console.ReadLine();
            pisi.WriteLine(vnos);
            pisi.WriteLine();
            pisi.WriteLine(DateTime.Now);

            int n = rnd.Next(10, 51);
            for (int i = 0; i < n; i++)
            {
                pisi.Write("*");
            }

            pisi.Close();

            Zoga Z1 = new Zoga("Wilson", 3.5, 5);

            StreamReader beri = File.OpenText("Rezultati.txt");
            string vrstica = beri.ReadLine();

            int minTocke = 101;
            string ime = "";

            while (vrstica != null)
            {
                string[] podatki = vrstica.Split(";");

                if (Int32.Parse(podatki[1]) > 50)
                {
                    Console.WriteLine("Ime: " + podatki[0] + " Točke: " + podatki[1] + " Opravil");
                }
                else
                {
                    Console.WriteLine("Ime: " + podatki[0] + " Točke: " + podatki[1] + " Ni Opravil");
                }

                if (minTocke > Int32.Parse(podatki[1]))
                {
                    minTocke = Int32.Parse(podatki[1]);
                    ime = podatki[0];
                }

                vrstica = beri.ReadLine();
            }

            Console.WriteLine("Minimalno število točk " + minTocke + " je dosegel " + ime);

            beri.Close();

        }
    }
}