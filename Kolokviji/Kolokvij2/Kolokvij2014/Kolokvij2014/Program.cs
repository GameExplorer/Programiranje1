
using System.Runtime.InteropServices.JavaScript;
using System.Security.Cryptography;

namespace Kolokvij2014
{
    class Zelva
    {
        public static int stevilo = 10;
        private string ime;

        public int VrniStarost()
        {
            return 124;
        }

        public static string imeObjekta()
        {
            return "imeObjekta";
        }

        private void Nahrani()
        {
            Console.WriteLine("Nahrani");
        }
    }
    
    class Stava
    {
        public string ime_Konja;
        private double znesek;
        public DateTime datum;   
        public Stava()
        {
            ime_Konja="Nedoločeno";
            znesek = 0;
            datum = DateTime.Now;
        }
        public void NastaviZnesek(double znesek)
        {
            this.znesek = znesek;
        }
    }

    class Kolobar
    {
        private double R;
        private double r;

        public Kolobar(double R, double r)
        {
            this.R = R;
            this.r = r;
            
        }

        public double Ploscina()
        {
            return Math.PI * Math.Pow(R, 2) - Math.PI * Math.Pow(r, 2);
        }
        
    }

    class Program
    {
        public static void Main(String[] args)
        {
            Zelva Kira = new Zelva();

            Console.WriteLine(Zelva.imeObjekta());

            string ime = "Jon";
            string priimek = "Snow";
            string datum = DateTime.Now.ToString("dd-MM-yy");

            // Zapišemo ime, priimek in datum v novo vrstico datoteke
            StreamWriter writer = new StreamWriter("Imena.txt", true); // true doda zapis na konec datoteke
            writer.WriteLine($"{ime} {priimek}, {datum}");
            
            writer.Close();

            Console.WriteLine("Ime, priimek in datum so zapisani v datoteko Imena.txt.");

            Stava s1 = new Stava();

            s1.ime_Konja = "Strela";
            s1.NastaviZnesek(100);
            s1.datum = new DateTime(2024, 3,16);

            string vsebinaDatoteke = File.ReadAllText("Imena.txt");

            string[] imena = vsebinaDatoteke.Split(',');

            for (int i = 0; i < imena.Length; i++)
            {
                char prvaCrka = char.ToUpper(imena[i][0]);
                string ostaliDelImena = imena[i].Substring(1);
                imena[i] = prvaCrka + ostaliDelImena;
            }
            
            File.WriteAllLines("imenaOK.txt", imena);
            Console.WriteLine("imenaOK.txt uspešno ustvarjena");

            Random rnd = new Random();

            Kolobar K1 = new Kolobar(rnd.Next(1,11), rnd.Next(1,11));
            Kolobar K2 = new Kolobar(rnd.Next(1,11), rnd.Next(1,11));
            
            if(K1.Ploscina() > K2.Ploscina()) Console.WriteLine("K1 Ploščina večja od K2");
            else if(K2.Ploscina() > K1.Ploscina()) Console.WriteLine("K2 Ploščina večja od K1");
            else Console.WriteLine("Ploščini sta enaki");

            Kolobar[] kolobarji = new Kolobar[100];
            for (int i = 0; i < 100; i++)
            {
                double zunanjiPolmer = 100 - i; // Zunanji polmeri od 100 do 1
                double notranjiPolmer = zunanjiPolmer / 2; // Notranji polmer za polovico manjši od zunanjega
                kolobarji[i] = new Kolobar(zunanjiPolmer, notranjiPolmer);
            }
            
            Datoteka("Test");
        }
        
        public static void Datoteka(string imeDatoteke) {
            if(File.Exists(imeDatoteke)) Console.WriteLine("Ime datoteke s tem imenom že obstaja!");
            else
            {
                StreamWriter sw = new StreamWriter(imeDatoteke, true);

                //od 1 do 10
                for (int i = 1; i < 11; i++)
                {
                    sw.Write(i + " ");
                }
                
                sw.WriteLine("\n" + imeDatoteke + ".dat");
                Random rnd = new Random();
                int stevilo = rnd.Next(1, 10);

                for (int i = 1; i < 11; i++)
                {
                    sw.Write(stevilo * i + " ");
                }
                
                sw.Close();
            }
        }
    }
}