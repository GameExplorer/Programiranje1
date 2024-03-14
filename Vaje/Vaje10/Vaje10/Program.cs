

namespace Vaje10
{
    class Avto
    {
        public string Znamka { get; set; }
        public string Tip { get; set; }
        public int Letnik { get; set; }
        public double stPrevozenihKilometrov { get; set; }

        public Avto(string Znamka, string Tip, int Letnik, double stPrevozenihKilometrov)
        {
            this.Znamka = Znamka;
            this.Tip = Tip;
            this.Letnik = Letnik;
            this.stPrevozenihKilometrov = stPrevozenihKilometrov;
        }
    }

    class AvtoDatoteka
    {
        private string imeDatoteke;

        public AvtoDatoteka(string imeDatoteke)
        {
            this.imeDatoteke = imeDatoteke;
        }

        public void ShranjevanjeVozil(Avto[] tabelaAvtomobilov)
        {
            StreamWriter sw = new StreamWriter(imeDatoteke);
            
            foreach (Avto avto in tabelaAvtomobilov)
            {
                sw.Write($"{avto.Znamka};{avto.Tip};{avto.Letnik};{avto.stPrevozenihKilometrov};\n");
                
            }
            sw.Close();
        }

        public Avto[] BranjePodatkov()
        {
            string[] vrstice = File.ReadAllLines(imeDatoteke);
            Avto[] tabelaAvtomobilov = new Avto[vrstice.Length];

            for (int i = 0; i < vrstice.Length; i++)
            {
                string[] podatki = vrstice[i].Split(";");
                tabelaAvtomobilov[i] =
                    new Avto(podatki[0], podatki[1], Int32.Parse(podatki[2]), Double.Parse(podatki[3]));
            }

            return tabelaAvtomobilov;
        }
    }
    class Program
    {
        public static void Main(String[] args)
        {
            //1. Naloga
            args = new[] { "NarediMapo" };
            string mapa = args[0];

            if (mapa.Length > 0  && !mapa.Contains('#') && !mapa.Contains('&') &&
                !mapa.Contains('$'))
            {
                if (Directory.Exists(mapa)) Console.WriteLine("Mapa s tem imenom že obstaja");
                else
                {
                    try
                    {
                        Directory.CreateDirectory(mapa);
                        Console.WriteLine("Mapa je ustvarjena");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Napaka pri ustvarjanju mape: " + e.Message);
                    }
                }
            }
            else
            {
                Console.WriteLine("Neustrezno ime mape. Ime mape ne sme biti prazno in ne sme vsebovati #$&!");
            }
            
            //2. Naloga
            string trenutniDirektorij = Directory.GetCurrentDirectory();
            string[] datoteke = Directory.GetFiles(trenutniDirektorij);

            foreach (string dat in datoteke)
            {
                Console.WriteLine(dat + " " + Directory.GetCreationTime(dat));
            }

            //3. Naloga
            char izbira;
            string imeDatoteke = ""; //začetno ime datoteke
            Avto[] tabelaAvtomobilov = null; //na začetku je tabela avtomobilov prazna
            AvtoDatoteka datotekaAvtomobilov = null; //datoteka avtomobilov na začetku prazna

            while (true)
            {
                Console.WriteLine("SEZNAM VOZIL");
                Console.WriteLine("-----------------------------------------------------------------------");
                Console.WriteLine("1. Vpiši ime datoteke");
                Console.WriteLine("2. Priprava testnih podatkov");
                Console.WriteLine("3. Izpis seznama vozil");
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine("4. Shranjevanje vozil v datoteko");
                Console.WriteLine("5. Branje podatkov iz datoteke");
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine("X. Izhod Programa");
                
                Console.Write("Izbira: ");
                izbira = Console.ReadLine()[0];

                switch (izbira)
                {
                    case '1':
                        Console.Clear();
                        Console.Write("Vnesi ime datoteke: ");
                        string vnos = Console.ReadLine();
                        datotekaAvtomobilov = new AvtoDatoteka(vnos);
                        if (datotekaAvtomobilov != null)
                        {
                            Console.WriteLine("Datoteka uspešno kreirana!");
                            Console.WriteLine("\nPritisni tipko za nadaljevanje...");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Napaka pri kreiranju datoteke!");
                            Console.WriteLine("\nPritisni tipko za nadaljevanje...");
                            Console.ReadKey();
                        }
                        break;
                    case '2':
                        Console.Clear();
                        tabelaAvtomobilov = TestniPodatki();
                        if (tabelaAvtomobilov != null)
                        {
                            Console.WriteLine("Podatki uspešno napolnjeni!");
                            Console.WriteLine("\nPritisni tipko za nadaljevanje...");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Podatki neuspešno napolnjeni!");
                            Console.WriteLine("\nPritisni tipko za nadaljevanje...");
                            Console.ReadKey();
                        }
                        break;
                    case '3':
                        Console.Clear();
                        IzpisSeznamVozil(tabelaAvtomobilov);
                        Console.WriteLine("\nPritisni tipko za nadaljevanje...");
                        Console.ReadKey();
                        break;
                    case '4':
                        Console.Clear();
                        if (tabelaAvtomobilov != null && datotekaAvtomobilov != null)
                        {
                            datotekaAvtomobilov.ShranjevanjeVozil(tabelaAvtomobilov);
                            Console.WriteLine("Podatki uspešno shranjeni v datoteko!");
                            Console.WriteLine("\nPritisni tipko za nadaljevanje...");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Vnesi ime datoteke in jo napolni s podatki!");
                            Console.WriteLine("\nPritisni tipko za nadaljevanje...");
                            Console.ReadKey();
                        }
                        break;
                    case '5':
                        Console.Clear();
                        if (tabelaAvtomobilov != null)
                        {
                            tabelaAvtomobilov = datotekaAvtomobilov.BranjePodatkov();
                            Console.WriteLine("Podatki uspešno prebrani!");
                            Console.WriteLine("\nPritisni tipko za nadaljevanje...");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Napaka pri branju podatkov.");
                            Console.WriteLine("\nPritisni tipko za nadaljevanje...");
                            Console.ReadKey();
                        }
                        break;
                    case 'X':
                    case 'x':
                        Console.WriteLine("Izhod iz programa");
                        return;
                    default:
                        Console.WriteLine("Napačna izbira!");
                        break;
                }
            }
        }

        public static Avto[] TestniPodatki()
        {
            Avto[] tabelaAvtomobilov = new Avto[10];

            tabelaAvtomobilov[0] = new Avto("Nissan", "Skyline Type GT-R R34", 1999, 7000);
            tabelaAvtomobilov[1] = new Avto("Ferrari", "F40", 1987, 1245);
            tabelaAvtomobilov[2] = new Avto("Mclaren", "F1", 1992, 63333);
            tabelaAvtomobilov[3] = new Avto("Toyota", "Supra", 1993, 100000);
            tabelaAvtomobilov[4] = new Avto("Acura", "Integra Type R", 1997, 52001);
            tabelaAvtomobilov[5] = new Avto("Porsche", "Cayman", 2005, 89642);
            tabelaAvtomobilov[6] = new Avto("Subaru", "WRX", 2002, 164210);
            tabelaAvtomobilov[7] = new Avto("Bugatti", "Veyron", 2005, 176424);
            tabelaAvtomobilov[8] = new Avto("Ford", "GT", 2005, 30512);
            tabelaAvtomobilov[9] = new Avto("Porsche", "918 Spyder", 2013, 200514);

            return tabelaAvtomobilov;
        }

        public static void IzpisSeznamVozil(Avto[] tabelaAvtomobilov)
        {
            if (tabelaAvtomobilov != null)
            {
                Console.WriteLine("Seznam vozil: ");
                foreach (Avto avtomobil in tabelaAvtomobilov)
                {
                    Console.WriteLine("Znamka: {0}, Tip: {1}, Letnik: {2}", avtomobil.Znamka, avtomobil.Tip, avtomobil.Letnik);
                }
            }
            else
            {
                Console.WriteLine("Tabela vozil je prazna");
            }
        }
    }
}