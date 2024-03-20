namespace Kolokvij2020C;

class Program
{
    class Izpit {
        public string Izpis()
        {
            return "f";
        }
    }

    class Oddaja
    {
        private string ime;
        private int gledalci;

        public Oddaja(string ime, int gledalci)
        {
            if(ime.Length > 1) this.ime = ime;
            else Console.WriteLine("Ime mora vsebovati vsaj 1 znak!");
            
            if(this.gledalci >= 0) this.gledalci = gledalci;
            else Console.WriteLine("Št. gledalcev mora biti pozitvno število");
        }

        public double Povprecje(Oddaja[] tabOddaj)
        {
            int stOddaj = 0;
            int skupnoStGledalcev = 0;
            for (int i = 0; i < tabOddaj.Length; i++)
            {
                skupnoStGledalcev += tabOddaj[i].gledalci;
                stOddaj++;
            }

            return skupnoStGledalcev / stOddaj;
        }
    }

    class Telefon
    {
        private int dolzina, sirina;
        private string proizvajalec;

        public Telefon(int dolzina, int sirina, string proizvajalec)
        {
            this.dolzina = dolzina;
            this.sirina = sirina;
            this.proizvajalec = proizvajalec;
        }
    }
    static void Main(string[] args)
    {
        Telefon T1 = new Telefon(7, 11, "Samsung");
        Izpit I1 = new Izpit();
        
        I1.Izpis();

        Oddaja O1 = new Oddaja("Tednik", 30000);

        StreamReader beri = File.OpenText("Padavine.txt");
        string vrstica = beri.ReadLine();

        int najvecji = 0;
        string datum = "";

        while (vrstica != null)
        {
            string[] podatki = vrstica.Split(";");
            
            Console.WriteLine("Datum " + podatki[0] + " Padavine: " + podatki[1]);

            if (najvecji < Int32.Parse(podatki[1]))
            {
                najvecji = Int32.Parse(podatki[1]);
                datum = podatki[0];
            }

            vrstica = beri.ReadLine();
        }

        Console.WriteLine("Največ padavin je bilo " + datum + " padlo je " + najvecji);
        beri.Close();

        StreamWriter pisi = File.AppendText("Padavine.txt");
        
        pisi.WriteLine(Dodaj("5.3.2024", 15));

        pisi.Close();
    }

    public static string Dodaj(string datum, int kolicina)
    {
        return datum + ";" + kolicina;
    }
}