
using System.Diagnostics;

namespace Knjiznica
{
    class Predmet
    {
        public string[] seznamPredmetov; //tabela predmetov

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
        public int[,] redovalnica;

        public Ucenec(string ime, string priimek, DateOnly datumRojstva, Predmet predmeti)
        {
            SpremenjenoIme(ime);
            SpremenjenPriimek(priimek);
            SpremenjenDatumRojstva(datumRojstva);
            redovalnica = new int[predmeti.seznamPredmetov.Length, 5];
        }

        public Ucenec(string ime, string priimek, DateOnly datumRojstva, Predmet predmeti, int letnik, string oddelek)
            : this(ime, priimek, datumRojstva, predmeti) //kjer smo jih v prejšen konstruktorju naredili
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

        public string vnosOcen(string imePredmeta, int ocena, Predmet predmet)
        {
            
            
            
            bool predmetObstaja = false;
            int indeksPredmeta = -1;


            //pogledamo ali predmet obstaja v seznamu predmetov, če obstaja mu pripišemo ustrezen indeks
            for (int i = 0; i < predmet.seznamPredmetov.Length; i++)
            {
                if (predmet.seznamPredmetov[i] == imePredmeta)
                {
                    predmetObstaja = true;
                    indeksPredmeta = i;
                    break;
                }
            }

            //če predmet ne obstaja
            if (!predmetObstaja)
            {
                return "Predmet ne obstaja!";
            }

            bool vseOcenePredmeta = true; //predpostavimo, da ima predmet vse ocene
            for (int i = 0; i < 5; i++)
            {
                //če predmet na tem mestu nima ocene potem nastavimo bool vrednost na false
                if (redovalnica[indeksPredmeta, i] == 0)
                {
                    vseOcenePredmeta = false;
                    break;
                }
            }

            //če je predmet že poln, ne moremo vnesti dodatne ocene
            if (vseOcenePredmeta)
            {
                return "Dodatne ocene ni mogoče vnesti!";
            }

            //ocena ni med 1 in 5
            if (ocena < 1 || ocena > 5)
            {
                return "Ocena ni ustrezna!";
            }
            
            //poiščemo prazen prostor v redovalnici
            for (int i = 0; i < 5; i++)
            {
                if (redovalnica[indeksPredmeta, i] == 0)
                {
                    redovalnica[indeksPredmeta, i] = ocena;
                    return "Ocena " + ocena + " uspešno zapisana za predmet " + imePredmeta;
                }
            }
            

            return "";
        }
        public void IzpisRedovalnice(Predmet predmet)
        {
            
            Console.WriteLine();
            Console.WriteLine("Redovalnica za učenca {0} {1}:", ime, priimek);
            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 48)));
            
            //izpis ocen in imen predmetov
            for (int i = 0; i < predmet.seznamPredmetov.Length; i++)
            {
                Console.Write(predmet.seznamPredmetov[i] + ": ");

                bool niOcen = true;
                for (int j = 0; j < 5; j++)
                {
                    if (redovalnica[i, j] != 0)
                    {
                        Console.Write(redovalnica[i, j] + ", ");
                        niOcen = false;
                    }
                }

                Console.WriteLine();
            }
            
            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 48)));
        }
        
        //Destruktor
        ~Ucenec()
        {
            //Preverimo ali je tabela že izbirisana, če ni jo izbrišemo
            if(redovalnica != null) redovalnica = null;
        }
        
    }
}