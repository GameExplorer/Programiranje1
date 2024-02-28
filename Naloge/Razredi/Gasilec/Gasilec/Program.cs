
namespace Gasilec
{
    class Gasilci
    {
        public string ImePriimek;
        public int leto;
        public string zadolzitev;


        public Gasilci(string imePriimek, int leto, string zadolzitev)
        {
            this.ImePriimek = imePriimek;
            this.leto = leto;
            this.zadolzitev = zadolzitev;

        }

        public string toString()
        {
            string izpis = "Ime Priimek: " + ImePriimek + "\nLeto pridružitve: " + leto + "\nZadolžitev: " + zadolzitev;
            return izpis;
        }
    }
    
    class Program
    {
        public static void Main(String[] args)
        {
            Gasilci g1 = new Gasilci("Timotej Kovač", 2012, "Prostovoljec");
            Gasilci g2 = new Gasilci("Miha Kovač", 1980, "Pomočnik vodje");
            Gasilci g3 = new Gasilci("Matija Štern", 1960, "Vodja");

            Console.WriteLine("Izpis gasilcev, ki so člani pred letom 1980 (vključno s tem letom): ");
            if (g1.leto <= 1980)
            {
                Console.WriteLine(string.Concat(Enumerable.Repeat("-", 32)));
                Console.WriteLine(g1.toString());
            }
            if (g2.leto <= 1980)
            {
                Console.WriteLine(string.Concat(Enumerable.Repeat("-", 32)));
                Console.WriteLine(g2.toString());

            }

            if (g3.leto <= 1980)
            {
                Console.WriteLine(string.Concat(Enumerable.Repeat("-", 32)));
                Console.WriteLine(g3.toString());
            }
        }
    }
}