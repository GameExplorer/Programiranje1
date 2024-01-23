
namespace Nizi;

class Program
{
    public static void Main(String[] args)
    {
        //PRAVILEN IZPIS IMENA
        /*Console.Write("Vnesi ime: ");
        string vnos = Console.ReadLine();
        
        Console.WriteLine("Vaše ime je " + VelikaZacetnica(vnos));*/
        
        /* ---------------------------------------------------------- */
         
        // PODOBNI IMENI
        /*Console.Write("Vnesi prvo ime: ");
        string ime1 = Console.ReadLine();

        Console.Write("Vnesi drugo ime: ");
        string ime2 = Console.ReadLine();
        
        string izpis = PodobniImeni(ime1, ime2);
        Console.WriteLine(izpis);*/
        
        /* ---------------------------------------------------------- *
         */
        // VSOTA CIFER V NIZU
        
        /*Console.Write("Vnesi stavek: ");
        string stavek = Console.ReadLine();
        int stevke = StevilaVNizu(stavek);
        Console.WriteLine("V stavku je vsota števk {0}", stevke);*/
        
        /* ---------------------------------------------------------- */
        // ŠUMNIKI
        
        Console.Write("Vnesi besedilo: ");
        string besedilo = Console.ReadLine();
        Console.WriteLine(besedilo);
        string izpisBesedila = BesediloBrezSumnikov(besedilo);
        Console.WriteLine("Besedilo brez šumnikov: {0}", izpisBesedila);

    }

    public static string VelikaZacetnica(String ime)
    {
        string popravljenIme = char.ToUpper(ime[0]) + ime.Substring(1, ime.Length - 1).ToLower();
        
        return popravljenIme;
    }

    public static string PodobniImeni(string ime1, string ime2)
    {
        char prvaCrkaImena = ime1[0];
        char drugaCrkaImena = ime2[0];

        char zadnjaCrkaPrvoIme = ime1[ime1.Length - 1];
        char zadnjaCrkaDrugoIme = ime2[ime1.Length - 1];
        
        if (ime1 != ime2 && prvaCrkaImena.Equals(drugaCrkaImena) && zadnjaCrkaPrvoIme.Equals(zadnjaCrkaDrugoIme))
        {
            return "Imeni se ujemata";
        }
        return "Imeni nista enaki";
    }

    public static int StevilaVNizu(string stavek)
    {
        double vsota = 0;
        for (int i = 0; i < stavek.Length; i++)
        {
            if (stavek[i] >= '0' && stavek[i] <= '9')
            {
                vsota += Char.GetNumericValue(stavek[i]);
            }
        }

        return Convert.ToInt32(vsota);
    }

    public static string BesediloBrezSumnikov(string besedilo)
    {
        string pomoznoBesedilo = "";
        for (int i = 0; i < besedilo.Length; i++)
        {
            char trenutniZnak = besedilo[i];

            switch (trenutniZnak)
            {
                case 'č':
                case 'ć':
                    pomoznoBesedilo += 'c';
                    break;
                case 'ž':
                    pomoznoBesedilo += 'z';
                    break;
                case 'š':
                    pomoznoBesedilo += 's';
                    break;
                default:
                    pomoznoBesedilo += trenutniZnak;
                    break;
            }
        }

        Console.WriteLine(pomoznoBesedilo);
        return pomoznoBesedilo;
    }
}