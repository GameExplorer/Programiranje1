// "Izjavljam, da sem nalogo opravil samostojno in da sem njen avtor. Zavedam se, da
// v primeru, če izjava prvega stavka ni resnična, kršim disciplinska pravila."

using Knjiznica;

namespace Vaje8
{
    class Program
    {
        public static void Main(String[] args)
        {
            #region Naloga 2
            //Vnos predmetov
            string[] vneseniPredmeti = Vnos();

            Predmet predmet = new Predmet(vneseniPredmeti);
            Console.WriteLine("Pritisni tipko za nadaljevanje...");
            Console.ReadKey();
            Console.Clear();
            
            //Izpis predmetov
            predmet.IzpisPredmetov();
            Console.WriteLine("Pritisni tipko za nadaljevanje...");
            Console.ReadKey();
            Console.Clear();
            
            #endregion
            
            #region Naloge 3 - 6
            Ucenec ucenec = new Ucenec("Janez", "Novak", new DateTime(2001,07,25), predmet, 4, "Ra");
            Console.Clear();

            //izpiše samo določen podatek o študentu
            //ime, priimek, datumrojstva, letnik, oddelek, osnovni, in default -> vsi podatki
            Console.WriteLine("Podatki o učencu");
            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 56)));
            Console.WriteLine(ucenec.IzpisPodatkov("datumrojstva").ToLower());
            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 56)));
            
            Console.WriteLine("Pritisni tipko za nadaljevanje...");
            Console.ReadKey();
            Console.Clear();
            
            //Spremenjeni podatki
            ucenec.SpremenjeniIzpis("ŠTEFAN", "a", new DateTime(2000,12,12));
            Console.WriteLine("Pritisni tipko za nadaljevanje...");
            Console.ReadKey();
            Console.Clear();
            
            //Vnos ocen
            Console.WriteLine("Vnos ocen: ");
            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 64)));

            Console.WriteLine(ucenec.vnosOcen("Matematika", 5, predmet)); //ocena uspešno dodana
            Console.WriteLine(ucenec.vnosOcen("Matematika", 5, predmet));
            Console.WriteLine(ucenec.vnosOcen("Matematika", 5, predmet));
            Console.WriteLine(ucenec.vnosOcen("Matematika", 5, predmet));
            Console.WriteLine(ucenec.vnosOcen("Matematika", 5, predmet));
            Console.WriteLine(ucenec.vnosOcen("Fizika", 4, predmet));
            Console.WriteLine(ucenec.vnosOcen("Slovenščina", 4, predmet));
            Console.WriteLine(ucenec.vnosOcen("Slovenščina", 4, predmet));
            Console.WriteLine(ucenec.vnosOcen("Slovenščina", 4, predmet));
            Console.WriteLine(ucenec.vnosOcen("Kemija", 3, predmet));
            Console.WriteLine(ucenec.vnosOcen("Kemija", 2, predmet));
            Console.WriteLine(ucenec.vnosOcen("Matematika", 5, predmet)); //dodatne ocene ni mogoče vnesti
            Console.WriteLine(ucenec.vnosOcen("Programiranje", 5, predmet)); //ne obstaja
            Console.WriteLine(ucenec.vnosOcen("Fizika", 10, predmet)); //ocena ni ustrezna
            
            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 64)));
            
            //Izpis redovalnice za študenta
            ucenec.IzpisRedovalnice(predmet);

            Console.WriteLine("Pritisni tipko za nadaljevanje...");
            Console.ReadKey();
            
            #endregion
        }

        //Metoda za vnos predmetov
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
