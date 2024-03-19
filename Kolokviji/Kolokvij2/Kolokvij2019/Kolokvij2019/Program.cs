using System.Threading.Channels;

namespace Kolokvij2019;

class Telefon
{
    public string proizvajalec, model;
    private int letoIzdelave;
    double cena;

    public string Karakteristike()
    {
        return "a";
    }

    public double Ekran()
    {
        return 0;
    }
        
}

class Ocala
{
    public string proizvajalec;
    private double cena;
    public int kolicina;

    public Ocala(string p, double c, int k)
    {
        proizvajalec = "Nedoločeno";
        cena = -1;
        kolicina = -1;
    }
}

class Knjiga
{
    private int steviloZnakov;
    private int strani;
    private int leto;

    public Knjiga(int steviloZnak, int strani)
    {
        steviloZnakov = steviloZnak;
        this.strani = strani;
        leto = 2024;
    }

    public double ZnakovNaStran()
    {
        return (double)steviloZnakov / strani;
    }
    
    public void IzpisPodatkov(Knjiga[] tabKnjig)
    {
        for (int i = 0; i < tabKnjig.Length; i++)
        {
            Console.WriteLine("St. strani: " + tabKnjig[i].strani + "\nSt. Znakov: " + tabKnjig[i].steviloZnakov);
        }
    }
}


class Program
{
    
    
    static void Main(string[] args)
    {
        Telefon T1 = new Telefon();

        T1.proizvajalec = "Apple";
        Console.WriteLine(T1.Karakteristike());
        T1.Karakteristike();

        Console.Write("Vnesi kolicino: ");
        int k = Int32.Parse(Console.ReadLine());
        Ocala O1 = new Ocala("BOSS", 120,k);

        Knjiga K1 = new Knjiga(125123, 321);
        Knjiga K2 = new Knjiga(61414, 421);

        Console.WriteLine(K1.ZnakovNaStran());
        Console.WriteLine(K2.ZnakovNaStran());

        Knjiga[] knjige = new Knjiga[100];

        for (int i = 0; i < knjige.Length; i++)
        {
            Random rnd = new Random();
            int znaki = rnd.Next(100, 10000);
            
            int strani = rnd.Next(101, 1101);

            knjige[i] = new Knjiga(znaki,strani);
        }
        K1.IzpisPodatkov(knjige);

        
        try
        {
            StreamWriter pisi = File.CreateText("Podatki.txt");

            pisi.WriteLine("Rad imam lubenico");

            pisi.WriteLine(Console.ReadLine());

            pisi.WriteLine();
            pisi.WriteLine();

            for (int i = 1; i <= 20; i++)
            {
                pisi.Write(5 * i + " ");
            }

            pisi.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Napaka pri zapisovanju v datoteko " + e);
        }

        try
        {
            StreamReader beri = File.OpenText("Rezultati.txt");
            string vrstica = beri.ReadLine();

            double vsota = 0;
            double povp = 0;

            int stVrstic = 0;

            double najboljsiCas = 9999;
            string zmagovalec = "";

            while (vrstica != null)
            {
                string[] podatki = vrstica.Split(";");

                vsota += Double.Parse(podatki[1]);

                if (najboljsiCas > Double.Parse(podatki[1]))
                {
                    najboljsiCas = Double.Parse(podatki[1]);
                    zmagovalec = podatki[0];
                }

                stVrstic++;
                vrstica = beri.ReadLine();
            }

            povp = vsota / stVrstic;
            Console.WriteLine("Povprečni čas je " + povp);
            Console.WriteLine("Zmagovalec je " + zmagovalec + " s časom " + najboljsiCas);

            beri.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Napaka pri branju datoteke " + e);
        }
    }
    
    
    
}