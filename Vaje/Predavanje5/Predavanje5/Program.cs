﻿
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
            
            
            /********************************************************** */
            
            // PREDAVANJE 5
            
            /********************************************************** */
            
            //Napiši metodo, ki prejme 1-dimenzionalno tabelo
            //vrne pa seštevek vseh elementov v njej
            int[] tabelica = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int izpisVsote = VsotaStevilVTabeli(tabelica);
            Console.WriteLine("Vsota števil v tabeli je: {0}", izpisVsote);
            
            //Napiši metodo, ki prejme 1D tabelo, ki prejme nize
            // in število nizov, ki jih iz te tabele izpiše. Metoda
            //izpiše toliko nizov iz tabele kot določa paramereter

            string[] tabelaNizov = new string[] { "Prvi", "Drugi", "Tretji", "Četrti", "Peti" };
            IzpisNizov(tabelaNizov, 8);

            Stanovanje s1 = new Stanovanje();

            Stanovanje[] stanovanja = new Stanovanje[5];
            vnosVseh(stanovanja);

            for (int i = 0; i < stanovanja.Length; i++)
            {
                stanovanja[i].izpis();
            }
            
            s1.UporabniskiVnos();
            s1.izpis();
            Stanovanje najugodnejse = NajUgodnejsi(stanovanja);
            Console.WriteLine("Najugodnejše stanovanje: ");
            najugodnejse.izpis();
        }

        static Stanovanje NajUgodnejsi(Stanovanje[] stanovanja)
        {
            Stanovanje najugodneje = stanovanja[0];
            for (int i = 1; i < stanovanja.Length; i++)
            {
                if (stanovanja[i].CenaNaM2() < najugodneje.CenaNaM2())
                {
                    najugodneje = stanovanja[i];
                }
            }

            return najugodneje;
        }
        
        static void vnosVseh(Stanovanje[] tabela)
        {
            for (int i = 0; i < tabela.Length; i++)
            {
                tabela[i] = new Stanovanje(); //rezerviramo mesto
                tabela[i].UporabniskiVnos();
            }
        }
        
        public static int VsotaStevilVTabeli(int[] tabela)
        {
            int vsota = 0;

            for (int i = 0; i < tabela.Length; i++)
            {
                vsota += tabela[i];
            }

            return vsota;
        }

        public static void IzpisNizov(string[] tabela, int stevilo)
        {
            string niz = "";
            for (int i = 0; i < stevilo; i++)
            {
                niz += tabela[i % tabela.Length] + " "; //vrne Prvi Drugi Tretji Četrti Peti Prvi Drugi Tretji 
            }
            Console.WriteLine(niz);
        }
    }
    
    class Stanovanje
    {
        public int steviloSob;
        public string Lokacija;
        public double kvadratura;
        public decimal cena;

        public double CenaNaM2()
        {
            return (double)this.cena / this.kvadratura;
        }

        public void UporabniskiVnos()
        {
            Console.Write("Vnesi stevilo sob: ");
            this.steviloSob = Int32.Parse(Console.ReadLine());

            Console.Write("Vnesi lokacijo: ");
            this.Lokacija = Console.ReadLine();
            
            Console.Write("Vnesi ceno: ");
            this.cena = decimal.Parse(Console.ReadLine());
            
            Console.Write("Vnesi kvadraturo: ");
            this.kvadratura = Int32.Parse(Console.ReadLine());
        }
        public void izpis()
        {
            Console.WriteLine("Stevilo sob: {0}, \nLokacija:{1}, " +
                              "\nKvadratura: {2} \nCena:{3}",
                steviloSob, Lokacija, kvadratura, cena);
        }
    }
}