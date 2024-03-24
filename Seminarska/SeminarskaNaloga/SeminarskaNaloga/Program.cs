
namespace SeminarskaNaloga;

using Destinacije;

//"Izjavljam, da sem nalogo opravil samostojno in da sem njen avtor. Zavedam se, da v primeru, če izjava prvega stavka ni resnična, kršim disciplinska pravila."

class Program
{
    static void Main(string[] args)
    {
        //Naslov
        Naslov();
        Console.Clear();
        
        //Menu z nalogami
        char izbira;
        string destinacijeDatoteka = "Destinacije.txt";
        string letalaDatoteka = "Letala.txt";
        string vnosNoveDatoteke = "";
        
        Destinacije destinacija = new Destinacije();
        
        while (true)
        {
            
            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 42)));
            
            Console.WriteLine(" ---- INFORMACIJE ----".PadLeft(26));
            Console.WriteLine("1. Izpis podatkov".PadLeft(24));
            
            Console.WriteLine(" --- DESTINACIJE ---".PadLeft(26));
            Console.WriteLine("2. Dodaj novo destinacijo".PadLeft(28));
            
            Console.WriteLine(" ---- LETALIŠČE ---- ".PadLeft(26));
            Console.WriteLine("3. Ustvari lete".PadLeft(24));
            Console.WriteLine("4. Izpiši seznam letov".PadLeft(28));
            Console.WriteLine("5. Izpis popularnih destinacij".PadLeft(32));

            Console.WriteLine(" --- TAJNICA --- ".PadLeft(24));
            Console.WriteLine("6. Tajnica (Pretvori v csv)".PadLeft(32));

            Console.WriteLine(" --- VOZOVNICA --- ".PadLeft(26));
            Console.WriteLine("7. Kupi Vozovnico".PadLeft(24));
            
            Console.WriteLine(" --- IZHOD --- ".PadLeft(24));
            Console.WriteLine("X. Zapri datoteko".PadLeft(24));
            
            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 42)));

            Console.WriteLine();
            Console.Write("Izberi nalogo: ");
            izbira = Console.ReadLine()[0];
            
            switch (izbira)
            { 
                case '1':
                    Console.Clear();
                    Console.WriteLine("Izberi način izpisa");
                    Console.WriteLine("a - Izpis vseh destinacij");
                    Console.WriteLine("b - Izpis vseh letal");
                    Console.Write("Izberi izpis: ");
                    char izpisIzbira = Console.ReadLine()[0];
                    switch (izpisIzbira)
                    {
                        case 'a':
                            Console.Clear();
                            Console.WriteLine("--- SEZNAM DESTINACIJ ---".PadLeft(28));
                            BranjeDatoteke(destinacijeDatoteka, 'a');
                            break;
                        case 'b':
                            Console.Clear();
                            Console.WriteLine("--- SEZNAM LETAL ---".PadLeft(24));
                            BranjeDatoteke(letalaDatoteka, 'b');
                            break;
                    }
                    Console.Write("\nPritisni tipko za nadaljevanje...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case '2':
                    Console.Clear();
                    
                    Console.Write("Vnesi število destinacij, ki jih želiš dodati: ");
                    int steviloDestinacij = Int32.Parse(Console.ReadLine());
                    Destinacije[] destinacije = new Destinacije[steviloDestinacij];
                    
                    destinacije = destinacija.VnosDestinacij(destinacije);
                    destinacija.ZapisDestinacij(destinacije, destinacijeDatoteka);
                    Console.WriteLine("Destinacije dodane!");
                    Console.Write("\nPritisni tipko za nadaljevanje...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case '3':
                    Console.Clear();
                    
                    if (vnosNoveDatoteke == "")
                    {
                        Console.Clear();
                        Console.Write("Vnesi ime datoteke (za lete): ");
                        vnosNoveDatoteke = Console.ReadLine() + ".txt";

                        if (File.Exists(vnosNoveDatoteke)) 
                        {
                            Console.WriteLine("Datoteka s tem imenom že obstaja!");
                            //vnosNoveDatoteke = ""; // Ponastavimo ime datoteke, da jo bo treba ponovno vnesti
                        }
                        else
                        {
                            UstvariNakljucneLete(destinacijeDatoteka, letalaDatoteka, vnosNoveDatoteke);
                            Console.WriteLine("Datoteka z leti uspešno ustvarjena!");
                        }
                    }
                    Console.Write("\nPritisni tipko za nadaljevanje...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case '4':
                    Console.Clear();
                    if(vnosNoveDatoteke == "") Console.WriteLine("Najprej ustvarite datoteko (Naloga 3)");
                    else
                    {
                        Console.WriteLine("SEZNAM LETOV".PadLeft(48));
                        Console.WriteLine("Odhod".PadRight(32) + "Prihod".PadRight(32) + "Letalo".PadRight(32) + "Potniki".PadRight(32) + "Razdalja[km]");
                        IzpisLetov(vnosNoveDatoteke);
                    }

                    Console.WriteLine();
                    Console.Write("\nPritisni tipko za nadaljevanje...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case '5':
                    Console.Clear();

                    if(vnosNoveDatoteke == "") Console.WriteLine("Najprej ustvarite datoteko (Naloga 3)");
                    else
                    {
                        List<string> top5Destinacij = Destinacije.NajboljPriljubljeneDestinacije(vnosNoveDatoteke);

                        Console.WriteLine("--- TOP 5 DESTINACIJ ---".PadLeft(40));
                        foreach (var dest in top5Destinacij)
                        {
                            Console.WriteLine(dest);
                        }
                    }

                    Console.Write("\nPritisni tipko za nadaljevanje...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case '6':
                    Console.Clear();
                    
                    if(vnosNoveDatoteke == "") Console.WriteLine("Najprej ustvarite datoteko (Naloga 3)");
                    else
                    {
                        Console.Write("Vnesi ime csv datoteke: ");
                        string vnosCSV = Console.ReadLine();

                        if (vnosCSV == "")
                        {
                            Console.WriteLine("Nisi vnesel ime csv datoteke");
                            Console.WriteLine("Ponovno jo vnesi!");
                            Console.Write("Vnesi ime csv datoteke: ");
                            vnosCSV = Console.ReadLine();
                        }

                        if (!vnosCSV.Contains(".csv")) vnosCSV += ".csv";

                        PretvoriCSV(vnosNoveDatoteke, vnosCSV);
                    }

                    Console.WriteLine("Podatki pretvorjeni v csv datoteko");
                    Console.Write("\nPritisni tipko za nadaljevanje...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case '7':
                    Console.Clear();
                    if(vnosNoveDatoteke == "") Console.WriteLine("Najprej ustvarite datoteko (Naloga 3)");
                    else
                    {
                        KupiVozovnico(vnosNoveDatoteke);
                    }

                    Console.Write("\nPritisni tipko za nadaljevanje...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 'X':
                case 'x':
                    Console.WriteLine("Zapiranje");
                    return;
                default:
                    Console.WriteLine("Napačna izbira naloge");
                    break;
            }
        }
    }

    public static void Naslov()
    {
        Console.WriteLine("░██████╗██╗░░░░░░█████╗░░█████╗░██╗██████╗░");
        Console.WriteLine("██╔════╝██║░░░░░██╔══██╗██╔══██╗██║██╔══██╗");
        Console.WriteLine("╚█████╗░██║░░░░░██║░░██║███████║██║██████╔╝");
        Console.WriteLine("░╚═══██╗██║░░░░░██║░░██║██╔══██║██║██╔══██╗");
        Console.WriteLine("██████╔╝███████╗╚█████╔╝██║░░██║██║██║░░██║");
        Console.WriteLine("╚═════╝░╚══════╝░╚════╝░╚═╝░░╚═╝╚═╝╚═╝░░╚═╝");
        
        Console.WriteLine();
        Console.Write("Pritisni tipko za nadaljevanje...");
        Console.ReadKey();
    }

    public static void BranjeDatoteke(string datoteka, char izbira)
    {
        try
        {
            StreamReader beri = File.OpenText(datoteka);
            string vrstica = beri.ReadLine();
            
            while (vrstica != null)
            {
                string[] podatki = vrstica.Split(";");
                
                //Izpis vseh destinacij
                if (izbira == 'a')
                {
                    Console.WriteLine(podatki[0].PadLeft(12) + " - " + podatki[1]); //izpis destinacij na tem indeksu in samo njeno ime
                }
                //Izpis vseh letal
                if (izbira == 'b')
                {
                    Console.WriteLine(vrstica.PadLeft(20));
                }
                vrstica = beri.ReadLine();
            }
            beri.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Napaka pri branju datoteke: " + e.Message);
        }
    }

    public static void UstvariNakljucneLete(string destDatoteka, string letalaDatoteka, string izhodnaDatoteka)
    {
        string[] tabDestinacij = File.ReadAllLines(destDatoteka);
        string[] tabLetal = File.ReadAllLines(letalaDatoteka);

        Random rnd = new Random();

        int stDestinacij = tabDestinacij.Length;
        int stLetal = tabLetal.Length;

        List<string> leti = new List<string>();

        int stLetov = rnd.Next(15, 51);

        for (int i = 0; i < stLetov; i++)
        {
            //Naključna destinacija (prihod in odhod) in letalo
            string odhod = tabDestinacij[rnd.Next(stDestinacij)];
            string prihod = tabDestinacij[rnd.Next(stDestinacij)];
            string letalo = tabLetal[rnd.Next(stLetal)];

            string[] odhodPodatki = odhod.Split(";");
            string[] prihodPodatki = prihod.Split(";");

            string odhodMesto = odhodPodatki[0];
            string odhodDrzava = odhodPodatki[1];

            string prihodMesto = prihodPodatki[0];
            string prihodDrzava = prihodPodatki[1];
            
            //Naključna razdalja
            int razdalja = rnd.Next(400, 10000);
            
            //Naključno št. potnikov
            int potniki = rnd.Next(1, 350);
            
            //Sestavljanje leta
            string infoLeta = $"{odhodMesto} ({odhodDrzava});{prihodMesto} ({prihodDrzava});"
                                                                           + $"{letalo};{potniki};{razdalja}";
            
            //Dodajanje v seznam
            leti.Add(infoLeta);
        }
        
        //Zapis v datoteko
        File.WriteAllLines(izhodnaDatoteka, leti);
    }

    public static void IzpisLetov(string letiDatoteka)
    {
        try
        {
            StreamReader beriLete = File.OpenText(letiDatoteka);

            string vrstica = beriLete.ReadLine();

            while (vrstica != null)
            {
                string[] podatki = vrstica.Split(";");

                string odhod = podatki[0];
                string prihod = podatki[1];
                string letalo = podatki[2];
                string stPotnikov = podatki[3];
                string razdalja = podatki[4];

                Console.WriteLine($"{odhod}".PadRight(32) + $"{prihod}".PadRight(32) + $"{letalo}".PadRight(32) + $"{stPotnikov}".PadRight(32) + $"{razdalja}".PadRight(32));
                vrstica = beriLete.ReadLine();
            }

            beriLete.Close(); 
        }
        catch (Exception e)
        {
            Console.WriteLine("Napaka pri branju datoteke: " + e.Message);
        }
    }

    public static void PretvoriCSV(string tekstovnaDatoteka, string csvDatoteka)
    {
        try
        {
            string[] vrstice = File.ReadAllLines(tekstovnaDatoteka);

            // Imena stolpcev
            string[] imenaStolpcev = { "Odhod", "Prihod", "Letalo", "St. Potnikov", "Razdalja" };

            // dodajanje imena stolpcev
            string zapis = string.Join(";", imenaStolpcev) + Environment.NewLine;
            
            zapis += string.Join(Environment.NewLine,
                vrstice.Select(x => x.Split(';')).Select(x => string.Join(";", x)));
            File.WriteAllText(csvDatoteka, zapis);
        }
        catch (Exception e)
        {
            Console.WriteLine("Napaka bri branju datoteke ali pri zapisovanju v csv: " + e.Message);
        }
        
    }

    public static void KupiVozovnico(string letalisce)
    {
        try
        {
            Console.WriteLine("OSEBNI PODATKI");
            Console.Write("Vnesi ime: ");
            string ime = Console.ReadLine();

            Console.Write("Vnesi priimek: ");
            string priimek = Console.ReadLine();

            Console.Write("\nNadaljuj na naslednji korak ->");
            Console.ReadKey();
            Console.Clear();

            IzpisiLetalisca(letalisce);
            
            // Klic metode za izbiro letališča
            string izbranoLetalisce = PreberiInPreveriLetalisce(letalisce);
            
            IzpisiOdhode(izbranoLetalisce, letalisce);

            // Klic metode za izbiro destinacije
            string izbranaDestinacija = PreberiInPreveriDestinacijo(izbranoLetalisce, letalisce);

            // Izračun časa potovanja
            (int ur, int minute) casPotovanja = IzracunajCasPotovanja(izbranoLetalisce, izbranaDestinacija, letalisce);

            if (casPotovanja.ur != -1 && casPotovanja.minute != -1)
            {
                Console.Clear();
                Console.WriteLine("".PadRight(25, '-'));
                Console.WriteLine("OSEBNI PODATKI");
                Console.WriteLine($"Ime: {ime}");
                Console.WriteLine($"Priimek: {priimek}");
                Console.WriteLine("".PadRight(25, '-'));

                Console.WriteLine();
                Console.WriteLine("".PadRight(64, '-'));
                Console.WriteLine("INFORMACIEJ O LETU".PadLeft(32));
                Console.WriteLine("\nODHOD".PadLeft(24) + "PRIHOD".PadLeft(24));
                Console.WriteLine($"{izbranoLetalisce}".PadRight(12) + $" -> {izbranaDestinacija} ".PadRight(20) +
                                  $" Cas: {casPotovanja.ur}h {casPotovanja.minute}min");
                Console.WriteLine("".PadRight(64, '-'));

            }
            else
            {
                Console.WriteLine("Napaka pri izračunu časa potovanja!");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Napaka: " + e.Message);
        }
    }
    
    // Metoda za izpis letališč
    public static void IzpisiLetalisca(string datoteka)
    {
        // Preberemo datoteko in izpišemo vsako letališče le enkrat
        var letalisca = File.ReadLines(datoteka)
            .Select(vrstica => vrstica.Split(';')[0])
            .Distinct();

        Console.WriteLine("Možna letališča:");
        foreach (var letalisce in letalisca)
        {
            Console.WriteLine(letalisce);
        }
    }

    // Metoda za branje vnosa uporabnika in preverjanje veljavnosti letališča
    public static string PreberiInPreveriLetalisce(string datoteka)
    {
        while (true)
        {
            Console.Write("\nIzberi letališče: ");
            string izbranoLetalisce = Console.ReadLine();

            if (File.ReadLines(datoteka).Any(vrstica => vrstica.Split(';')[0] == izbranoLetalisce))
            {
                return izbranoLetalisce; // Vrnemo izbrano letališče, če je veljavno
            }
            else
            {
                Console.WriteLine("Vnešeno letališče ni na seznamu! Poskusite znova.");
            }
        }
    }

    // Metoda za izpis odhodov iz izbranega letališča
    public static void IzpisiOdhode(string letalisce, string datoteka)
    {
        Console.WriteLine($"\nOdhodi iz letališča {letalisce}:");
        var odhodi = File.ReadLines(datoteka)
            .Where(vrstica => vrstica.Split(';')[0] == letalisce)
            .Select(vrstica => vrstica.Split(';')[1]);

        foreach (var odhod in odhodi)
        {
            Console.WriteLine($"{letalisce} -> {odhod}");
        }
    }
    
    // Metoda za branje vnosa uporabnika in preverjanje veljavnosti destinacije
    public static string PreberiInPreveriDestinacijo(string izbranoLetalisce, string datoteka)
    {
        while (true)
        {
            Console.Write($"\nIzberi destinacijo iz seznama odhodov za letališče {izbranoLetalisce}: ");
            string izbranaDestinacija = Console.ReadLine();

            if (File.ReadLines(datoteka).Any(vrstica => vrstica.Split(';')[1] == izbranaDestinacija && vrstica.Split(';')[0] == izbranoLetalisce))
            {
                return izbranaDestinacija; // Vrnemo izbrano destinacijo, če je veljavna
            }
            else
            {
                Console.WriteLine("Vnešena destinacija ni na seznamu odhodov! Poskusite znova.");
            }
        }
    }
    
    public static (int ur, int minute) IzracunajCasPotovanja(string izbranoLetalisce, string izbranaDestinacija, string datoteka)
    {
        try
        {
            string[] podatki = File.ReadLines(datoteka)
                .First(vrstica => vrstica.Split(';')[0] == izbranoLetalisce && vrstica.Split(';')[1] == izbranaDestinacija)
                .Split(';');

            int razdalja = int.Parse(podatki[4]); // Razdalja je v petem stolpcu

            double casPotovanja = razdalja / 800.0; // Izračun časa potovanja v urah

            int ur = (int)casPotovanja; // Celotno število ur
            int minute = (int)((casPotovanja - ur) * 60); // Pretvorba delovnih ur v minute

            return (ur, minute);
        }
        catch (Exception e)
        {
            Console.WriteLine("Napaka pri izračunu časa potovanja: " + e.Message);
            return (-1, -1); // V primeru napake vrnemo neveljavne vrednosti
        }
    }
    
}