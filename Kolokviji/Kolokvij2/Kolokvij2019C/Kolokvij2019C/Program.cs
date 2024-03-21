namespace Kolokvij2019C;

class Program
{
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

    class Oddaja
    {
        private string ime;
        private int gledalci;

        public Oddaja(string ime, int gledalci)
        {
            if (ime.Length < 0) this.ime = ime;
            else ime = "Nedoločeno";

            if (gledalci >= 0) this.gledalci = gledalci;
            else gledalci = 0;
        }

        public double Povprecje(Oddaja[] tabOddaj)
        {
            double vsota = 0;
            for (int i = 0; i < tabOddaj.Length; i++)
            {
                vsota++;
            }

            return gledalci / vsota;
        }
    }
    static void Main(string[] args)
    {
        Telefon T1 = new Telefon(7, 11, "Samsung");

        Oddaja O1 = new Oddaja("Tednik", 30110);

        StreamReader beri = File.OpenText("Padavine.txt");

        string vrstica = beri.ReadLine();

        string datum = "";
        int max = 0;

        while (vrstica != null)
        {
            string[] podatki = vrstica.Split(";");
            Console.WriteLine("Datum: " + podatki[0] + " Padavine: " + podatki[1]);

            if (max < Int32.Parse(podatki[1]))
            {
                max = Int32.Parse(podatki[1]);
                datum = podatki[0];
            }

            vrstica = beri.ReadLine();
        }
        
        Console.WriteLine("Največ padavin je bilo " + datum + " in sicer " + max);
        beri.Close();
        
        Dodaj("15.2.2024", 64);
    }

    public static void Dodaj(string datum, int kolicina)
    {
        StreamWriter sw = File.AppendText("Padavine.txt");
        
        sw.WriteLine(datum + ";" + kolicina);
        sw.Close();
    }
}