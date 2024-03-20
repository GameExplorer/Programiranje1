using System.Runtime.CompilerServices;

namespace Kolokvij_2013C;

class Program
{
    class Kocka
    {
        public static string Komentar()
        {
            return "";
        }
    }

    class Majica
    {
        private int velikost;
        public string barva;
        public bool rokav;

        public Majica()
        {
            velikost = 0;
            barva = "Nedoločeno";
        }

        public void NastaviVelikost(int velikost)
        {
            this.velikost = velikost;
        }
    }

    class Pravokotnik
    {
        private double a;
        private double b;

        public Pravokotnik(double a, double b)
        {
            this.a = a;
            this.b = b;
        }

        public double Ploscina()
        {
            return a * b;
        }
    }
    
    static void Main(string[] args)
    {
        Kocka K = new Kocka();

        Random rnd = new Random();
        
        Pravokotnik P1 = new Pravokotnik(rnd.Next(1,11), rnd.Next(1,11));
        Pravokotnik P2 = new Pravokotnik(rnd.Next(1,11), rnd.Next(1,11));
        
        if(P1.Ploscina() > P2.Ploscina()) Console.WriteLine("P1 ima večjo ploščino od P2");
        else if(P2.Ploscina() > P1.Ploscina()) Console.WriteLine("P2 ima večjo ploščino od P1");
        else Console.WriteLine("Ploščini sta enaki");

        Console.WriteLine(Kocka.Komentar());

        Majica M1 = new Majica();

        Majica[] majice = new Majica[100];

        /*for (int i = 0; i < majice.Length; i++)
        {
            int velikost = 0;
            string barva = "Nedoločena";

            majice[i].NastaviVelikost(velikost);
            majice[i].barva = barva;

            majice[i] = new Majica();
        }*/
        
        M1.NastaviVelikost(44);
        M1.barva = "rumena";
        M1.rokav = true;

        try
        {
            StreamReader beri = File.OpenText("Studenti.txt");
            string vrstica = beri.ReadLine();
            
            int stStudentov = 0;

            while (vrstica != null)
            {
                stStudentov++;
                vrstica = beri.ReadLine();
            }

            Console.WriteLine("Št. študentov je " + stStudentov);
            beri.Close();

        }
        catch (Exception e)
        {
            Console.WriteLine("Napak pri branju datoteke " + e.Message);
        }


        StreamWriter pisi = File.CreateText("Rezultati.txt");
        int met = 1;

        while (met <= 1000)
        {
            if (met % 3 != 0) pisi.Write(rnd.Next(1,7) + " ");
            else pisi.WriteLine(rnd.Next(1,7) + " ");
            met++;
        }

        pisi.Close();
        
        StreamReader sr = File.OpenText("Rezultati.txt");
        double vsota = 0;
        double povp = 0;

        string vrstica1 = sr.ReadLine();

        while (vrstica1 != null)
        {
            string[] podatki = vrstica1.Split(" ");

            if (podatki.Length == 3)
                vsota += Int32.Parse(podatki[0]) + Int32.Parse(podatki[1]) + Int32.Parse(podatki[2]);
            else vsota += Int32.Parse(podatki[0]);

            vrstica1 = sr.ReadLine();
        }

        Console.WriteLine(vsota);
        povp = vsota / 334;
        Console.WriteLine("Povprečje je " + povp);
        sr.Close();

        Datoteka("Ocene.txt");
    }

    public static void Datoteka(string imeDatoteke)
    {
        if (!File.Exists(imeDatoteke))
        {
            Console.WriteLine("Datoteka ne obstaja!");
        }
        else
        {
            StreamReader beri = File.OpenText(imeDatoteke);
            string vrstica = beri.ReadLine();

            int maxTock = 0;
            List<string> imenaNajvecjih = new List<string>();

            while (vrstica != null)
            {
                string[] podatki = vrstica.Split("|");
                int trenutneTocke = Int32.Parse(podatki[1]);

                if (maxTock < trenutneTocke)
                {
                    maxTock = trenutneTocke;
                    imenaNajvecjih.Clear(); // Počistimo seznam, ker imamo nove najvišje točke
                    imenaNajvecjih.Add(podatki[0]);
                }
                else if (maxTock == trenutneTocke)
                {
                    // Če je trenutno število točk enako maksimalnemu, dodamo ime v seznam
                    imenaNajvecjih.Add(podatki[0]);
                }

                vrstica = beri.ReadLine();
            }

            beri.Close();

            // Izpis imen vseh študentov z največjim številom točk
            foreach (string ime in imenaNajvecjih)
            {
                Console.WriteLine(ime);
            }

        }
    }
}