
namespace Podatek
{
    public class Tekac
    {
        private string ime;
        private string priimek;
        private int letnicaRojstva;
        public int startnaStevilka;

        public Tekac(string ime, string priimek, int letnicaRojstva)
        {
            this.ime = ime;
            this.priimek = priimek;
            this.letnicaRojstva = letnicaRojstva;

            Random rnd = new Random();

            startnaStevilka = rnd.Next(1, 10000);
        }

        public void Izpis()
        {
            Console.WriteLine(String.Concat(Enumerable.Repeat("-", 24)));
            Console.WriteLine("Ime: " + ime);
            Console.WriteLine("Priimek: " + priimek);
            Console.WriteLine("Letnica rojstva: " + letnicaRojstva);
            Console.WriteLine("Štartna številka: " + startnaStevilka);
            Console.WriteLine(String.Concat(Enumerable.Repeat("-", 24)));

        }
    }

    public class Tek
    {
        private string proga;

        public Tek(string proga)
        {
            IzbiraProge(proga);
        }

        public void IzbiraProge(string proga)
        {
            switch (proga)
            {
                case "deset":
                    Console.Write("Vnesi pretečeni čas (min; 45,32): ");
                    double cas = Double.Parse(Console.ReadLine());
                    Izracun10K(cas);
                    break;
            }
        }

        public double Izracun10K(double cas)
        {
            double tempo = 10_000 / (cas * 60);

            return tempo;
        }
    }
}