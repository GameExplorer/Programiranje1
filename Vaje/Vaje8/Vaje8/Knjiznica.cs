
namespace Knjiznica
{
    class Predmet
    {
        public string[] seznamPredmetov = new [] {"Slovenščina", "Matematika", "Fizika", "Kemija", "Angleščina"}; //tabela predmetov

        public Predmet() //konstrutor
        { }

        /**
         * Metoda izpiše seznam predmetov
         */
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
        
        //Destruktor, zapremo tabelo (objekt uničimo)
        ~Predmet()
        {
            seznamPredmetov = null;
        }
    }

    class Ucenec
    {
        private string ime;
        private string priimek;
        private DateTime datumRojstva; 
        public int letnik;
        public string oddelek;
        public int[,] redovalnica; //tabela ocen

        public Ucenec(string ime, string priimek, DateTime datumRojstva, Predmet predmeti)
        {
            SpremeniIme(ime);
            SpremeniPriimek(priimek);
            SpremeniDatumRojstva(datumRojstva);
            redovalnica = new int[predmeti.seznamPredmetov.Length, 5]; //število predmetov enako
                                                                       //št. predmetov v razredz Predmet in največ 5 ocen za vsak predmet
        }

        public Ucenec(string ime, string priimek, DateTime datumRojstva, Predmet predmeti, int letnik, string oddelek)
            : this(ime, priimek, datumRojstva, predmeti) //kjer smo jih v prejšen konstruktorju naredili lahko samo pokličemo this
                                                        // in se izgonemo, da bi še enkrart pisali isto
        {
            this.letnik = letnik;
            this.oddelek = oddelek;
        }

        public string IzpisPodatkov(string izbira)
        {
            //Metoda izpiše podatke o učencu, navodila sem tako razumel tako, da
            //se uporabnik odloči ali izpisal osnovne ali vse podatke o učencu
            switch (izbira)
            {
                case "ime":
                    return "Ime učenca: " + ime;
                case "priimek":
                    return "Priimek učenca: " + priimek;
                case "datumrojstva":
                    return "Datum rojstva: " + datumRojstva.ToString("dd.MM.yyyy");
                case "letnik":
                    return "Letnik: " + letnik;
                case "oddelek" :
                    return "Oddelek: " + oddelek;
                case "osnovni":
                    return string.Join("Osnovni podatki: {0}, {1}, roj. {2}", ime, priimek,
                        datumRojstva.ToString("dd.MM.yyyy"));
                default:
                    return string.Join("Vsi podatki: {0}, {1} roj. {2}, odd. {3}.{4} ", ime, priimek, datumRojstva.ToString("dd.MM.yyyy"), letnik, oddelek);
            }
        }
        
        //Metode za spreminjanje podatkov
        public void SpremeniIme(string novoIme)
        {
            if (novoIme.Length > 1 && novoIme != "")
            {
                ime = novoIme; //da izpiše originalni vnos
                Console.WriteLine("Ime učenca spremenjeno v " + ime);
                ime = novoIme.Substring(0, 1).ToUpper() + novoIme.Substring(1).ToLower();
            }
            else
            {
                Console.WriteLine("Vneseno ime ni ustrezno!");
            }
        }
        
        public void SpremeniPriimek(string novPriimek)
        {
            if (novPriimek.Length > 1 && novPriimek != "")
            {
                priimek = novPriimek; //da izpiše originalni vnos, drugače ni potreben
                Console.WriteLine("Priimek učenca spremenjen v " + priimek);
                priimek = novPriimek.Substring(0, 1).ToUpper() + novPriimek.Substring(1).ToLower();

            }
            else
            {
                Console.WriteLine("Vnesen priimek ni ustrezen!");
            }
        }

        public void SpremeniDatumRojstva(DateTime novDatumRojstva)
        {
            DateTime najnizjeLeto = new DateTime(1900, 1, 1); 
            //Če vneseni datum ni večji od trenutnega datuma (datum.now vzame trenutni dan, ko je program zagnan) in pogledamo
            //da uporabnik ni vnesel datuma pred 1.1.1900
            if (novDatumRojstva <= DateTime.Now && novDatumRojstva >= najnizjeLeto && novDatumRojstva != null) 
            {
                datumRojstva = novDatumRojstva;
                Console.WriteLine("Datum rojstva učenca je spremenjen na " + datumRojstva.ToString("dd.MM.yyyy"));
            }
            // ... sicer javi napako
            else
            {
                Console.WriteLine("Datum rojstva ne more biti v prihodnosti!");
            }
        }
        
        //Metoda, ki izpiše spremenjene podatke o učencu
        public void SpremenjeniIzpis(string novoIme, string novPriimek, DateTime novDatumRojstva)
        {
            //Izpis originalnih podatkov
            Console.WriteLine("Podatki učenca: " + ime + " " + priimek + " roj. " + datumRojstva.ToString("dd.MM.yyyy"));
            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 56)));

            //Klic metod in izpis spremenjenih podatkov
            SpremeniIme(novoIme);
            SpremeniPriimek(novPriimek);
            SpremeniDatumRojstva(novDatumRojstva);

            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 56)));
            Console.WriteLine("Podatki učenca: " + priimek + " " + ime + " " + datumRojstva.ToString("dd.MM.yyyy"));
        }

        public string vnosOcen(string imePredmeta, int ocena)
        {
            Predmet predmet = new Predmet();
            //pogledamo ali predmet obstaja v seznamu predmetov, če obstaja mu pripišemo ustrezen indeks in nastavimo
            //bool vrednost na true
            bool predmetObstaja = false;
            int indeksPredmeta = -1; //vrstica 0 nekaj pomeni, -1 pa nič ne pomeni
            
            for (int i = 0; i < predmet.seznamPredmetov.Length; i++)
            {
                if (predmet.seznamPredmetov[i] == imePredmeta)
                {
                    predmetObstaja = true;
                    indeksPredmeta = i;
                    break;
                }
            }

            //če predmet ne obstaja izpišemo, da ne obstaja
            if (!predmetObstaja)
            {
                return "Predmet \"" + imePredmeta + "\" ne obstaja!";
            }

            //Pogledamo ali predmet nima več kot 5 ocen
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
                return "Dodatne ocene pri predmetu " + imePredmeta + " ni mogoče vnesti!";
            }

            //Preverimo ali je vnešena ocena med 1 in 5
            if (ocena < 1 || ocena > 5)
            {
                return "Ocena ni ustrezna!";
            }
            
            //poiščemo prazen prostor v redovalnici in zapišemo oceno
            for (int i = 0; i < redovalnica.GetLength(1); i++)
            {
                if (redovalnica[indeksPredmeta, i] == 0)
                {
                    redovalnica[indeksPredmeta, i] = ocena;
                    return "Ocena " + ocena + " uspešno zapisana za predmet " + imePredmeta;
                }
            }

            return "";
        }
        public void IzpisRedovalnice()
        {
            Predmet predmet = new Predmet();
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
        
        //Destruktor, zapremo tabelo redovalnica
        ~Ucenec()
        {
            //Preverimo ali je tabela že izbirisana, če ni jo izbrišemo
            if(redovalnica != null) redovalnica = null;
        }
    }
}