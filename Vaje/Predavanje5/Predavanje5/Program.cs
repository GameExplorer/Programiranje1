
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Predavanje5
{
    class Oseba
    {
        public string Ime;
        public string Priimek;
        public int LetnicaRojstva;

        public Oseba(string ime, string priimek, int letnicaRojstva)
        {
            this.Ime = ime;
            this.Priimek = priimek;
            this.LetnicaRojstva = letnicaRojstva;
        } 

        public void izpis() //metoda, ki izpiše podatke 
        {
            Console.WriteLine(this.Ime + " " + this.Priimek + ", rojen leta " + this.LetnicaRojstva);
        }
    }

    class Krog
    {
        public double polmer;

        public double Ploscina()
        {
            return (Math.PI * Math.Pow(polmer, 2));
        }

        /*public Krog(double polmer)
        {
            this.polmer = polmer;
        }*/

        public void Izpis()
        {
            Console.WriteLine("Ploščina kroga je " + this.Ploscina());
        }
    }

    class Clan
    {
        public string ime;
        public string priimek;
        public int letoRojstva;
        public string vpisna_st;

        public Clan(string Ime, string Priimek, int letoRojstva, string vpisnaSt)
        {
            this.ime = Ime;
            this.priimek = Priimek;
            this.letoRojstva = letoRojstva;
            this.vpisna_st = vpisnaSt;
        }
    }

    class Pravokotnik
    {
        public double dolzina;
        public double visina;

        public Pravokotnik(double dolzina, double visina)
        {
            this.dolzina = dolzina;
            this.visina = visina;
        }

        public double Ploscina()
        {
            return dolzina * visina;
        }

        public double Obseg()
        {
            return 2 * (dolzina + visina);
        }
    }
    
    class Program
    {
        public static void Main(String[] args)
        {
            // KREIRANJE OSEB BREZ KONSTRUKTORJA 
            /*Oseba o1 = new Oseba(); //ustvarimo objekt ... deklaracija objekta
            o1.Ime = "Jure";
            o1.Priimek = "Zajc";
            o1.LetnicaRojstva = 1999;*/
             
            //Console.WriteLine("{0} {1} rojen leta {2}", o1.Ime, o1.Priimek, o1.LetnicaRojstva); //izpis podatkov za osebo1
            
            //o1.izpis(); //klic metode za izpis podatkov, iste podatke izpiše kot zgornji izpis
            
            /*Oseba o2 = new Oseba(); //ustvarimo objekt in mu dodelimo vrednosti
            o2.Ime = "Janko";
            o2.Priimek = "Kresnik";
            o2.LetnicaRojstva = 1846;
            
            o2.izpis(); //klic metode za izpis podatkov za osebo2*/

            // KLIC OSEBE S POMOČJO KONSTRUKTORJA
            Oseba o3 = new Oseba("France", "Prešern", 1800); //ustvarimo in inicializiramo objekt
            Oseba o4 = new Oseba("Ivan", "Cankar", 1876);
            
            o3.izpis(); //klic metode iz razreda Oseba
            o4.izpis();

            Krog k = new Krog(); //privzeta vrednost je 0!
            Console.Write("Vnesi polmer kroga: ");
            k.polmer = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Ploščina kroga je {0}", k.Ploscina());
            
            k.Izpis();

            Clan c = new Clan("Max", "Verstappen", 1996, "3301");
            Console.WriteLine("Ime: {0}, Priimek: {1}, Letnica Rojstva: {2}, Vpisna Stevilka: {3}",
                c.ime, c.priimek, c.letoRojstva, c.vpisna_st);

            Console.Write("Vnesi dolzino: ");
            double dolzina = Double.Parse(Console.ReadLine());
            
            Console.Write("Vnesi visino: ");
            double visina = Double.Parse(Console.ReadLine());

            Pravokotnik p1 = new Pravokotnik(dolzina, visina);
            Console.WriteLine("Obseg pravokotnika je {0} ", p1.Obseg());
            Console.WriteLine("Ploscina pravokotnika je {0} ", p1.Ploscina());
        }
    }
}