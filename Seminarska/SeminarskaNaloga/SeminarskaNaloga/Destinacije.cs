using System.Threading.Channels;

namespace Destinacije;

public class Destinacije
{
    private string Destinacija;
    private string Drzava;

    public Destinacije()
    { }

    public Destinacije(string Destinacija, string Drzava)
    {
        if(Destinacija.Length > 1) this.Destinacija = Destinacija;
        else Console.WriteLine("Ime Destinacije mora vsebovati vsaj 2 znaka!");
        
        if(Drzava.Length > 1) this.Drzava = Drzava;
        else Console.WriteLine("Ime Države mora vsebovati vsaj 2 znaka!");
    }
    
    public Destinacije[] VnosDestinacij(Destinacije[] tabDestinacij)
    {
        for (int i = 0; i < tabDestinacij.Length; i++)
        {
            Console.Write("Vnesi ime destinacije: ");
            string vnosDestinacije = Console.ReadLine();
            
            Console.Write("Vnesi državo destinacije: ");
            string vnosDrzave = Console.ReadLine();
            tabDestinacij[i] = new Destinacije(vnosDestinacije, vnosDrzave);
        }

        return tabDestinacij;
    }

    public void ZapisDestinacij(Destinacije[] tabDestinacij, string imeDatoteke)
    {
        StreamWriter pisi = File.AppendText(imeDatoteke);

        for (int i = 0; i < tabDestinacij.Length; i++)
        {
            pisi.WriteLine(tabDestinacij[i].Destinacija + ";" + tabDestinacij[i].Drzava);
        }

        pisi.Close();
    }

    public static List<string> NajboljPriljubljeneDestinacije(string imeDatoteke)
    {
        //Preberemo vse podatke iz datoteke
        string[] podatki = File.ReadAllLines(imeDatoteke);
        
        //Slovar za shranjevanje vsote potnikov za vsako lokacijo prihoda
        Dictionary<string, int> destinacije = new Dictionary<string, int>();
        
        //Štetje skupnega števila potnikov za vsako lokacijo prihoda
        foreach (string vrstica in podatki)
        {
            string[] deli = vrstica.Split(";");
            string lokacijaPrihoda = deli[1];
            int stPotnikov = Int32.Parse(deli[3]);

            if (destinacije.ContainsKey(lokacijaPrihoda))
            {
                destinacije[lokacijaPrihoda] += stPotnikov;
            }
            else
            {
                destinacije[lokacijaPrihoda] = stPotnikov;
            }
        }
        
        //Razvrstimo po skupnem št potnikov in izberemo top 5
        var top5Destinacije = destinacije.OrderByDescending(pair => pair.Value).Take(5);
        
        //Izpis seznama
        List<string> izpis = new List<string>();
        foreach (var destinacija in top5Destinacije)
        {
            izpis.Add($"{destinacija.Key}".PadLeft(24) + $" - Skupno število potnikov: {destinacija.Value}".PadRight(24));
        }

        return izpis;
    }

}