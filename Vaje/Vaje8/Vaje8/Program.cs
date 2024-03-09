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
            Predmet predmet = new Predmet();
            
            //Izpis predmetov
            predmet.IzpisPredmetov();
            Console.WriteLine("Pritisni tipko za nadaljevanje...");
            Console.ReadKey();
            Console.Clear();
            
            #endregion
            
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
            
            Console.WriteLine(ucenec.vnosOcen("Matematika", 5)); //ocena uspešno dodana
            Console.WriteLine(ucenec.vnosOcen("Matematika", 5));
            Console.WriteLine(ucenec.vnosOcen("Matematika", 5));
            Console.WriteLine(ucenec.vnosOcen("Matematika", 5));
            Console.WriteLine(ucenec.vnosOcen("Matematika", 5));
            Console.WriteLine(ucenec.vnosOcen("Fizika", 4));
            Console.WriteLine(ucenec.vnosOcen("Slovenščina", 4));
            Console.WriteLine(ucenec.vnosOcen("Slovenščina", 4));
            Console.WriteLine(ucenec.vnosOcen("Tuji jezik", 4));
            Console.WriteLine(ucenec.vnosOcen("Kemija", 3));
            Console.WriteLine(ucenec.vnosOcen("Kemija", 2));
            Console.WriteLine(ucenec.vnosOcen("Matematika", 5)); //dodatne ocene ni mogoče vnesti
            Console.WriteLine(ucenec.vnosOcen("Programiranje", 5)); //ne obstaja
            Console.WriteLine(ucenec.vnosOcen("Fizika", 10)); //ocena ni ustrezna
            
            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 64)));
            
            //Izpis redovalnice za študenta
            ucenec.IzpisRedovalnice();
            Console.WriteLine();
            

        }
    }
}
