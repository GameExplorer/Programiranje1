

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.JavaScript;

namespace Knjiznica
{
    class Predmet
    {
        public string[] seznamPredmetov;

        public Predmet(string[] seznamPredmetov)
        {
            this.seznamPredmetov = seznamPredmetov;
        }

        public void IzpisPredmetov()
        {
            Console.WriteLine("Seznam predmetov");
            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 24)));

            for (int i = 0; i < seznamPredmetov.Length; i++)
            {
                Console.WriteLine(seznamPredmetov[i]);
            }
            
            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 24)));
        }
        
        //Destruktor
        ~Predmet()
        {
            seznamPredmetov = null;
        }
    }

    class Ucenec
    {
        private string ime;
        private string priimek;
        private DateOnly datumRojstva;
        public int letnik;
        public string oddelek;

        public Ucenec(string ime, string priimek, DateOnly datumRojstva)
        {
            SpremenjenoIme(ime);
            SpremenjenPriimek(priimek);
            SpremenjenDatumRojstva(datumRojstva);
        }

        public Ucenec(string ime, string priimek, DateOnly datumRojstva, int letnik, string oddelek)
            : this(ime, priimek, datumRojstva) //kjer smo jih v prejšen konstruktorju naredili
        {
            this.letnik = letnik;
            this.oddelek = oddelek;
        }

        public void IzpisPodatkov(char izbira)
        {
            Console.WriteLine("Podatki o učencu");
            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 56)));

            if (izbira == 'y' || izbira == 'Y')
            {
                Console.WriteLine("Ime učenca: " + ime);
                Console.WriteLine("Priimek učenca: " + priimek);
                Console.WriteLine("Letnik: " + letnik);
                Console.WriteLine("Oddelek: " + oddelek);
            }
            else
            {
                Console.WriteLine("Ime učenca: " + ime);
                Console.WriteLine("Priimek učenca: " + priimek);
                Console.WriteLine("Letnik: " + letnik);
                Console.WriteLine("Oddelek: " + oddelek);
                Console.WriteLine("Osnovni podatki: {0}, {1}, roj. {2}", ime, priimek, datumRojstva);
                Console.WriteLine("Vsi podatki: {0}, {1} roj. {2}, odd. {3}.{4} ", ime, priimek, datumRojstva, letnik, oddelek);
            }
            
            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 56)));
        }
        
        //Metode za spreminjanje podatkov
        public void SpremenjenoIme(string novoIme)
        {
            if (novoIme.Length > 1 && novoIme != "")
            {
                ime = novoIme;
                Console.WriteLine("Ime učenca spremenjeno v " + ime);
                ime = novoIme.Substring(0, 1).ToUpper() + novoIme.Substring(1).ToLower();

            }
            else
            {
                Console.WriteLine("Vneseno ime ni ustrezno!");
            }
        }
        
        public void SpremenjenPriimek(string novPriimek)
        {
            if (novPriimek.Length > 1 && novPriimek != "")
            {
                priimek = novPriimek;
                Console.WriteLine("Priimek učenca spremenjen v " + priimek);
                priimek = novPriimek.Substring(0, 1).ToUpper() + novPriimek.Substring(1).ToLower();

            }
            else
            {
                Console.WriteLine("Vnesen priimek ni ustrezen!");
            }
        }

        public void SpremenjenDatumRojstva(DateOnly novDatumRojstva)
        {
            if (novDatumRojstva <= DateOnly.FromDateTime(DateTime.Now) )
            {
                datumRojstva = novDatumRojstva;
                Console.WriteLine("Datum rojstva učenca je spremenjen na " + datumRojstva);
            }
            else
            {
                Console.WriteLine("Datum rojstva ne more biti v prihodnosti!");
            }
        }
        
        public void SpremenjeniIzpis(string novoIme, string novPriimek, DateOnly novDatumRojstva)
        {
            Console.WriteLine("Podatki učenca: " + ime + " " + priimek + " roj. " + datumRojstva.ToString("dd.MM.yyyy"));
            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 56)));

            SpremenjenoIme(novoIme);
            SpremenjenPriimek(novPriimek);
            SpremenjenDatumRojstva(novDatumRojstva);

            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 56)));
            Console.WriteLine("Podatki učenca: " + ime + " " + priimek + " " + datumRojstva.ToString("dd.MM.yyyy"));
        }
        
    }
}