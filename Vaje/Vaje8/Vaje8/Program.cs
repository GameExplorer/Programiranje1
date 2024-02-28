// "Izjavljam, da sem nalogo opravil samostojno in da sem njen avtor. Zavedam se, da
// v primeru, če izjava prvega stavka ni resnična, kršim disciplinska pravila."


using Knjiznica;

namespace Vaje8
{
    class Program
    {
        public static void Main(String[] args)
        {
            string[] vneseniPredmeti = Vnos();

            Predmet predmet = new Predmet(vneseniPredmeti);

            Console.Clear();
            predmet.IzpisPredmetov();

            Console.Clear();

            Ucenec ucenec = new Ucenec("Janez", "Novak", new DateOnly(2001,07,25), 4, "Ra");
            Console.Clear();
            
            //izpis podatkov o študentu
            Console.WriteLine("Izberi izpis podatkov");
            Console.WriteLine("Y - osnovni podatki, N - vsi podatki ");
            Console.Write("\nIzbira (y/n): ");
            char izbira = Console.ReadLine()[0];
            Console.Clear();
            ucenec.IzpisPodatkov(izbira);
            Console.WriteLine("Pritisni tipko za nadaljevanje...");
            Console.ReadKey();
            
            //Spremenjeni podatki
            Console.Clear();
            ucenec.SpremenjeniIzpis("ŠTEFAN", "a", new DateOnly(2000,12,12));
            Console.WriteLine("Pritisni tipko za nadaljevanje...");
            Console.ReadKey();
            
        }

        public static string[] Vnos()
        {
            string[] predmeti = new string[5];

            for (int i = 0; i < predmeti.Length; i++)
            {
                Console.Write("Vnesi {0} predmet: ", i+1);
                string vnos = Console.ReadLine();

                predmeti[i] = vnos;
            }

            return predmeti;
        }
    }
}
