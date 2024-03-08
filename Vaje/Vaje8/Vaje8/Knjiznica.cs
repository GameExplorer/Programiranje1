
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
        public Predmet predmeti;

        public Ucenec(string ime, string priimek, DateTime datumRojstva, Predmet predmeti)
        {
            SpremeniIme(ime);
            SpremeniPriimek(priimek);
            SpremeniDatumRojstva(datumRojstva);
            this.predmeti = new Predmet();
            redovalnica = new int[predmeti.seznamPredmetov.Length, 5]; //število predmetov enako
                                                                       //št. predmetov v razredz Predmet in največ 5 ocen za vsak predmet
        }

        public Ucenec(string ime, string priimek, DateTime datumRojstva, Predmet predmeti, int letnik, string oddelek)
            : this(ime, priimek, datumRojstva, predmeti) //kjer smo jih v prejšen konstruktorju naredili lahko samo pokličemo this
                                                        // in se izgonemo, da bi še enkrart pisali isto
        {
            this.letnik = letnik;
            this.oddelek = oddelek;
            this.predmeti = new Predmet();
            
        }

        public Ucenec(string ime, string priimek, DateTime datumRojstva)
        {
            this.ime = ime;
            this.priimek = priimek;
            this.datumRojstva = datumRojstva;
            this.predmeti = new Predmet();
            redovalnica = new int[predmeti.seznamPredmetov.Length, 5]; //število predmetov enako
            //št. predmetov v razredz Predmet in največ 5 ocen za vsak predmet
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
                    return $"Osnovni podatki: {ime}, {priimek}, roj. {datumRojstva.ToString("dd.MM.yyyy")}";
                default:
                    return $"Vsi podatki: {ime}, {priimek} roj. {datumRojstva.ToString("dd.MM.yyyy")}, odd. {letnik}.{oddelek}";
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
            // Predmet predmet = new Predmet(); 

            // Poiščemo indeks predmeta
            int indeksPredmeta = -1;
            try
            {
                for (int i = 0; i < predmeti.seznamPredmetov.Length; i++)
                {
                    if (predmeti.seznamPredmetov[i] == imePredmeta)
                    {
                        indeksPredmeta = i;
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Napaka: " + e.Message);
            }

            // Preverimo, ali je bil predmet najden
            if (indeksPredmeta == -1)
            {
                return "Predmet \"" + imePredmeta + "\" ne obstaja!";
            }

            // Preverimo, ali ima predmet prostor za novo oceno
            bool vseOcenePredmeta = true;
            for (int i = 0; i < 5; i++)
            {
                if (redovalnica[indeksPredmeta, i] == 0)
                {
                    vseOcenePredmeta = false;
                    break;
                }
            }

            if (vseOcenePredmeta)
            {
                return "Dodatne ocene pri predmetu " + imePredmeta + " ni mogoče vnesti!";
            }

            // Preverimo, ali je ocena veljavna
            if (ocena < 1 || ocena > 5)
            {
                return "Ocena ni ustrezna!";
            }

            // Najdemo prazen prostor v redovalnici in zapišemo oceno
            for (int i = 0; i < redovalnica.GetLength(1); i++)
            {
                if (redovalnica[indeksPredmeta, i] == 0)
                {
                    redovalnica[indeksPredmeta, i] = ocena;
                    return "Ocena " + ocena + " uspešno zapisana za predmet " + imePredmeta;
                }
            }

            return "Dodatne ocene pri predmetu " + imePredmeta + " ni mogoče vnesti!";
        }
        public void IzpisRedovalnice()
        {
            Console.WriteLine();
            Console.WriteLine("Redovalnica za učenca {0} {1}:", ime, priimek);
            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 48)));
        
            // Izpis ocen in imen predmetov z uporabo členske spremenljivke predmet
            for (int i = 0; i < predmeti.seznamPredmetov.Length; i++)
            {
                Console.Write(predmeti.seznamPredmetov[i] + ": ");

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
            redovalnica = null;
        }
    }

    class Oddelek
    {
        private int letnik;
        private string kodaOddelka;
        private Ucenec[] seznamUcencev;

        
        public Oddelek(int letnik, string kodaOddelka)
        {
            this.letnik = letnik;
            this.kodaOddelka = kodaOddelka;
            seznamUcencev = new Ucenec[15];
        }

        public void VnosPdatkovUcenca(int index, string ime, string priimek, DateTime datumRojstva)
        {
            // Preverimo, če je indeks v mejah tabele in če na tem indeksu že obstaja učenec
            if (index >= 0 && index < seznamUcencev.Length && seznamUcencev[index] == null)
            {
                seznamUcencev[index] = new Ucenec(ime, priimek, datumRojstva);
                Console.WriteLine($"Podatki o učencu {ime} {priimek} uspešno vnešeni.");
            }
            else
            {
                Console.WriteLine("Napaka pri vnosu podatkov o učencu.");
            }
        }

        public void SpremembaImenaUcenca(int index, string novoIme)
        {
            if (index >= 0 && index < seznamUcencev.Length && seznamUcencev[index] != null)
            {
                seznamUcencev[index].SpremeniIme(novoIme);
            }
            else
            {
                Console.WriteLine("Napaka pri spreminjanju imena učenca.");
            }
        }

        public void SpremembaPriimkaUcenca(int index, string novPriimek)
        {
            if (index >= 0 && index < seznamUcencev.Length && seznamUcencev[index] != null)
            {
                seznamUcencev[index].SpremeniPriimek(novPriimek);
            }
            else
            {
                Console.WriteLine("Napaka pri spreminjanju priimka učenca.");
            }
        }

        public void SpremembaDatumaRojstva(int index, DateTime novDatumRojstva)
        {
            if (index >= 0 && index < seznamUcencev.Length && seznamUcencev[index] != null)
            {
                seznamUcencev[index].SpremeniDatumRojstva(novDatumRojstva);
            }
            else
            {
                Console.WriteLine("Napaka pri spreminjanju datuma rojstva učenca.");
            }
        }
        
        // Metoda za izpis seznama vnesenih učencev
        public void IzpisSeznamUcencev()
        {
            Console.WriteLine();
            Console.WriteLine("Seznam učencev v oddelku: " + letnik + "." + kodaOddelka);
            Console.WriteLine(string.Concat(new string('-', 40)));

            foreach (Ucenec ucenec in seznamUcencev)
            {
                if (ucenec != null)
                {
                    Console.WriteLine(ucenec.IzpisPodatkov("osnovni"));
                }
            }

            Console.WriteLine(string.Concat(new string('-', 40)));
        }
        
        public string VnosOceneUcenca(int indexUcenca, string imePredmeta, int ocena)
        {
            if (indexUcenca >= 0 && indexUcenca < seznamUcencev.Length && seznamUcencev[indexUcenca] != null)
            {
                return seznamUcencev[indexUcenca].vnosOcen(imePredmeta, ocena);
            }
            else
            {
                return "Napaka";
            }
        }

        public void IzpisRedovalniceUcenca(int indexUcenca)
        {
            if (indexUcenca >= 0 && indexUcenca < seznamUcencev.Length && seznamUcencev[indexUcenca] != null)
                {
                    seznamUcencev[indexUcenca].IzpisRedovalnice();
                }
                else
                {
                    Console.WriteLine("Napaka pri izpisu redovalnice. Učenec ne obstaja v tem oddelku.");
                }
                    
            
        }

        ~Oddelek()
        {
            seznamUcencev = null;
        }
        
    }
}