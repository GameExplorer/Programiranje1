// See https://aka.ms/new-console-template for more information

namespace Vaje6
{
    class Program
    {
        public static void Main(String[] args)
        {
            //1. Naloga
            //PregledPodatkovForEach();
            
            //2. Naloga
            //SwitchStavek();
            
            //3. Naloga
            //Pravokotnik();

            //4. Naloga
            //KlicMetodeZnotrajZanke();

            //5. Naloga
            //IskanjeSumljiveBesede();

            //6. Naloga
            //TockeNaIzpitu();
            
            //7. Naloga
            Loterija();
        }

        public static void PregledPodatkovForEach()
        {
            int[,] tabela = new int[10, 10];
            Random rnd = new Random();
            int vsota = 0;
            double povpVrednost;

            //napolnim tabelo
            for (int i = 0; i < tabela.GetLength(0); i++)
            {
                for (int j = 0; j < tabela.GetLength(1); j++)
                {
                    tabela[i,j] = rnd.Next(1, 1001);
                    Console.WriteLine(tabela[i,j]);
                }
            }

            //sprehod po elementih in izračunam vsoto
            foreach (int stevilka in tabela)
            {
                vsota += stevilka;
            }

            //delim vsoto z številom vseh elementov in dobim povprečje
            int vsiElementi = tabela.GetLength(0) * tabela.GetLength(1);
            povpVrednost = (double)vsota / vsiElementi;
            Console.WriteLine("Povprečna vrednost v tabeli je {0}", povpVrednost);
            
        }
        
        public static void SwitchStavek()
        {
            Console.Write("Vnesi prvo število: ");
            int st1 = Int32.Parse(Console.ReadLine());

            Console.Write("Vnesi drugo število: ");
            int st2 = Int32.Parse(Console.ReadLine());
            
            while (true)
            {
                Console.Clear();
                
                Console.WriteLine("Vnesi prvo število {0}:", st1);
                Console.WriteLine("Vnesi drugo število: {0}", st2);
                
                Console.WriteLine();
                Console.WriteLine("Katero operacijo nad števili želite izvesti");
                Console.WriteLine("A - Seštevanje");
                Console.WriteLine("B - Odštevanje");
                Console.WriteLine("C - Množenje");
                Console.WriteLine("D - Deljenje");
                Console.WriteLine("X - Izhod");
                
                Console.Write("Izberite možnost: ");
                char izbira = Console.ReadLine().ToLower()[0];
                Console.WriteLine();
                
                switch (izbira)
                {
                    case 'a':
                        Console.WriteLine("Vsota števil {0} in {1} je {2}", st1, st2, (st1+st2));
                        break;
                    case 'b':
                        Console.WriteLine("Razlika števil {0} in {1} je {2}", st1, st2, (st1-st2));
                        break;
                    case 'c':
                        Console.WriteLine("Produkt števil {0} in {1} je {2}", st1, st2, (st1*st2));
                        break;
                    case 'd':
                        Console.WriteLine("Rezultat deljenja števil {0} in {1} je {2}", st1, st2, (st1/st2));
                        break;
                    case 'x':
                        Console.WriteLine("Hvala za uporabo programa. \nNasvidenje!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Izbrana možnost ni na voljo \nProsim izberite eno od danih možnosti!");
                        break;
                }

                Console.ReadLine(); //da nam takoj ne skoči nazaj na začetek zanke

            }
        }

        public static void Pravokotnik()
        {
            // !! Ta del kode sem dal v svojo metodo, za lepši pregled isto bi delovala, če bi bila v main metodi
            Console.Write("Vnesi stranico a: ");
            double a = Double.Parse(Console.ReadLine());

            Console.Write("Vnesi stranico b: ");
            double b = Double.Parse(Console.ReadLine());

            double rezultat = Ploscina(a, b);
            Console.WriteLine("Ploščina pravokotnika je {0} e^2", rezultat);
        }
        
        public static double Ploscina(double a, double b)
        {
            return Math.Round(a * b, 2);
        }

        public static void KlicMetodeZnotrajZanke()
        {
            //ustvarimo 2D tabelo
            int[,] tabela = new int[10, 10];
            Random rnd = new Random();

            //napolnimo tabelo
            for (int i = 0; i < tabela.GetLength(0); i++)
            {
                for (int j = 0; j < tabela.GetLength(1); j++)
                {
                    tabela[i, j] = rnd.Next(0, 1001);
                }
            }
            
            //Pregledujemo vse elemente
            foreach (int stevilka in tabela)
            {
                string rez = PreveriUstreznost(stevilka);
                Console.WriteLine("{0} - {1}", stevilka, rez);
            }
        }

        public static string PreveriUstreznost(int stevilka)
        {
            if (stevilka % 2 == 0) return "Število je deljivo z 2";
            if (stevilka % 3 == 0) return "Število je deljivo s 3";
            if (stevilka % 5 == 0) return "Število je deljivo s 5";

            return "Število ni deljivo z 2, 3 ali 5";
        }

        public static void IskanjeSumljiveBesede()
        {
            string niz = "V mirnem mestu je živel nenavaden besedni tat, ki je ponoči kradel samo črke 'a' in 'u'. " +
                         "Prebivalci so prejemali čudna sporočila, vsa brez teh dveh ključnih črk. Vsak dan " +
                         "so postajali bolj radovedni, kdo je ta skrivnostni tat. Končno so ga odkrili, ko so " +
                         "ga zalotili v trenutku, ko je skušal ukrasti 'u' s krajevnega znaka. Kljub svojemu nenavadnemu " +
                         "hobiju si je pridobil simpatije in postal del mestne folklore.";

            string[] tabelaBesed = niz.Split(new char[] { ' ', ',', '.' }); //razdelimo besede

            foreach (string beseda in tabelaBesed) //sprehod po tabeli in kličemo metodo, da preverimo ali je beseda sumljiva
            {
                bool rez = PreveriBesedo(beseda);
                
                //če je metoda vrnila true izpiše besedo
                if(rez) Console.WriteLine("Beseda <{0}> je sumljiva", beseda);
            }
        }

        public static bool PreveriBesedo(string beseda)
        {
            //če je v besedi a in u vrne true
            if (beseda.Contains('a') && beseda.Contains('u'))
            {
                return true;
            }
            
            //sicer false
            return false;
        }

        public static void TockeNaIzpitu()
        {
            string[,] tabelaŠtudentov = new string[5, 2];
            string ime;
            string tocke;
            
            //dodamo študente in njihove točke
            for (int i = 0; i < tabelaŠtudentov.GetLength(0); i++)
            {
                Console.Write("Študent: ");
                ime = Console.ReadLine();
                tabelaŠtudentov[i, 0] = ime; //v i-ti vrstici in v prvem stolpcu dodamo ime študenta

                Console.Write("Vnesi točke: ");
                tocke = Console.ReadLine();
                tabelaŠtudentov[i, 1] = tocke; //v i-ti vrstici in v drugem stolpcu dodamo točke
            }

            string imeIzpis = "";
            string rez = "";

            Console.WriteLine();
            Console.WriteLine("PREGLED OCEN");
            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 48)));
            
            //sprehod po tabeli študentov in izpis imena študenta in njegov uspeh
            for (int i = 0; i < tabelaŠtudentov.GetLength(0); i++)
            {
                for (int j = 0; j < tabelaŠtudentov.GetLength(1); j++)
                {
                    int tockeIzpita = Convert.ToInt32(tabelaŠtudentov[i,1]);
                    imeIzpis = tabelaŠtudentov[i, 0];
                    rez = PreveriOceno(tockeIzpita); //pokličemo metodo, da preverimo uspeh
                }
                Console.WriteLine("Študent/ka {0} je prejel/a oceno {1}.", imeIzpis, rez);

            }
            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 48)));

        }

        public static string PreveriOceno(int ocena)
        {
            //else if je nepotreben
            if (ocena >= 85) return "ODLIČNO";
            if (ocena >= 70) return "PRAV DOBRO";
            if (ocena >= 60) return "DOBRO";
            if (ocena >= 50) return "ZADOSTNO";
            
            return "NEZADOSTNO";
        }

        public static void Loterija()
        {
            //Napolnim tabelo 15 študentov in na začetku nastavimo točke na 0
            string[,] tabelaTekmovalcev = 
            {
                { "Cene", "0" }, { "Mitja", "0" }, { "Ana", "0" }, { "Klara", "0" }, { "Iva", "0" },
                { "Mirko", "0" }, { "Janez", "0" }, { "Bine", "0" }, { "Gregor", "0" }, { "Špela", "0" },
                { "Polona", "0" }, { "Manca", "0" }, { "Tilen", "0" }, { "Jakob", "0" }, { "Eva", "0" }
            };

            //vrnemo tabelo s tekmovalci in njihovimi točkami
            string[,] rezultati = Zrebanje(tabelaTekmovalcev);
            
            int maxTocke = Convert.ToInt32(rezultati[0,1]); //privzamem, da ima prva oseba največ točk
            int indexOsebe = 0;
            
            //iščemo osebo z največjim številom točk in shranimo njen indeks, ko jo najdemo
            for (int i = 0; i < rezultati.GetLength(0); i++)
            {
                int trenutneTocke = Convert.ToInt32(rezultati[i, 1]); 
                if (maxTocke < trenutneTocke)
                {
                    maxTocke = trenutneTocke;
                    indexOsebe = i; 
                }
            }

            //shranimo zmagovalca v spremenljivki
            string zmagovalec = rezultati[indexOsebe, 0]; 
            string stTock = rezultati[indexOsebe, 1];

            Console.WriteLine("Izžrebana oseba: {0} z doseženim številom točk: {1}", zmagovalec, stTock);

            //Izpis ostalih tekmovalcev
            Console.WriteLine();
            Console.WriteLine("Ostale osebe: ");
            for (int i = 0; i < rezultati.GetLength(0); i++)
            {
                if (i != indexOsebe)
                {
                    Console.WriteLine(rezultati[i,0] + ": " + rezultati[i,1]);
                }
            }
        }

        public static string[,] Zrebanje(string[,] tabelaTekmovalcev)
        {
            Random rnd = new Random();

            //naredimo 100k žrebanj in pri vsak žrebanju naključnemu tekmovalcu dodelimo 1 točko
            for (int i = 0; i < 100000; i++)
            {
                int indexOsebe = rnd.Next(0, 15); //izberemo naključnega tekmovalca
                int dodeliTocko = Convert.ToInt32(tabelaTekmovalcev[indexOsebe, 1]) + 1; //dodelimo točko nak. tekmovalcu
                tabelaTekmovalcev[indexOsebe, 1] = Convert.ToString(dodeliTocko); //toćko spremenimo nazaj v string
            }

            return tabelaTekmovalcev; //vrnemo nazaj tabelo s točkami
        }
    }
}