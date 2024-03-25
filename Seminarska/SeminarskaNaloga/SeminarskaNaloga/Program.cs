
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
        
        //DATOTEKE
        string destinacijeDatoteka = "Destinacije.txt";
        string letalaDatoteka = "Letala.txt";
        string letiDatoteka = ""; //za shranjevanje datoteke v nalogi 3
        
        char izbira;
        
        Destinacije destinacija = new Destinacije();
        
        //Naloge
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
            Console.WriteLine("6. Pretvori v CSV".PadLeft(24));

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

                    try
                    {
                        Console.Write("Vnesi število destinacij, ki jih želiš dodati: ");
                        int steviloDestinacij = Int32.Parse(Console.ReadLine());
                        Destinacije[] destinacije = new Destinacije[steviloDestinacij];
                    
                        destinacije = destinacija.VnosDestinacij(destinacije);
                        destinacija.ZapisDestinacij(destinacije, destinacijeDatoteka);
                        Console.WriteLine("Destinacije dodane!");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Napaka pri dodajanju destinacij" + e.Message);
                        throw;
                    }
                    
                    Console.Write("\nPritisni tipko za nadaljevanje...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case '3':
                    Console.Clear();
                    
                    if (letiDatoteka == "")
                    {
                        Console.Clear();
                        Console.Write("Vnesi ime datoteke (za lete): ");
                        letiDatoteka = Console.ReadLine() + ".txt";

                        if (File.Exists(letiDatoteka)) 
                        {
                            Console.WriteLine("Datoteka s tem imenom že obstaja!");
                        }
                        else
                        {
                            UstvariNakljucneLete(destinacijeDatoteka, letalaDatoteka, letiDatoteka);
                            Console.WriteLine("Datoteka z leti uspešno ustvarjena!");
                        }
                    }
                    Console.Write("\nPritisni tipko za nadaljevanje...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case '4':
                    Console.Clear();
                    if(letiDatoteka == "") Console.WriteLine("Najprej ustvarite datoteko (Naloga 3)");
                    else
                    {
                        Console.WriteLine("SEZNAM LETOV".PadLeft(48));
                        Console.WriteLine("Odhod".PadLeft(12) + "Prihod".PadLeft(24) + "Letalo".PadLeft(24) + "Potniki".PadLeft(24) + "Razdalja[km]".PadLeft(24));
                        IzpisLetov(letiDatoteka);
                    }

                    Console.WriteLine();
                    Console.Write("\nPritisni tipko za nadaljevanje...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case '5':
                    Console.Clear();

                    if(letiDatoteka == "") Console.WriteLine("Najprej ustvarite datoteko (Naloga 3)");
                    else
                    {
                        //seznam top5 destinacij
                        List<string> top5Destinacij = Destinacije.NajboljPriljubljeneDestinacije(letiDatoteka);

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
                    
                    if(letiDatoteka == "") Console.WriteLine("Najprej ustvarite datoteko (Naloga 3)");
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

                        PretvoriCSV(letiDatoteka, vnosCSV);
                    }

                    Console.WriteLine("Podatki pretvorjeni v csv datoteko");
                    Console.Write("\nPritisni tipko za nadaljevanje...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case '7':
                    Console.Clear();
                    if(letiDatoteka == "") Console.WriteLine("Najprej ustvarite datoteko (Naloga 3)");
                    else
                    {
                        KupiVozovnico(letiDatoteka);
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

    //Branje podatkov iz datotek
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

    //Metoda ustvari naključne lete 
    public static void UstvariNakljucneLete(string destDatoteka, string letalaDatoteka, string izhodnaDatoteka)
    {
        string[] tabDestinacij = File.ReadAllLines(destDatoteka);
        string[] tabLetal = File.ReadAllLines(letalaDatoteka);

        Random rnd = new Random();

        int stDestinacij = tabDestinacij.Length;
        int stLetal = tabLetal.Length;

        //Seznam letov
        List<string> leti = new List<string>();

        //Naključno število letov
        int stLetov = rnd.Next(25, 101);

        for (int i = 0; i < stLetov; i++)
        {
            //Naključna destinacija (prihod in odhod) in naključno letalo
            string odhod = tabDestinacij[rnd.Next(stDestinacij)];
            string prihod = tabDestinacij[rnd.Next(stDestinacij)];
            string letalo = tabLetal[rnd.Next(stLetal)];
            
            string[] odhodPodatki = odhod.Split(";");
            string[] prihodPodatki = prihod.Split(";");

            //Dobimo podatke za mesto in državo odhoda/prihoda
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

    //Metoda izpiše lete ustvarjene v prejšni metodi
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

                Console.WriteLine($"{odhod}".PadRight(26) + $"{prihod}".PadRight(26) + $"{letalo}".PadRight(28) + $"{stPotnikov}".PadRight(20) + $"{razdalja}");
                vrstica = beriLete.ReadLine();
            }

            beriLete.Close(); 
        }
        catch (Exception e)
        {
            Console.WriteLine("Napaka pri branju datoteke: " + e.Message);
        }
    }

    //Metoda pretovri txt datoteko v csv datoteko
    public static void PretvoriCSV(string tekstovnaDatoteka, string csvDatoteka)
    {
        try
        {
            string[] vrstice = File.ReadAllLines(tekstovnaDatoteka);

            // Imena stolpcev
            string[] imenaStolpcev = { "Odhod", "Prihod", "Letalo", "St. Potnikov", "Razdalja" };

            // dodajanje imena stolpcev na začetku vrstice
            string zapis = string.Join(";", imenaStolpcev) + Environment.NewLine;
            
            //Dodajanje ostalih podatkov v datoteko source: stackoverflow
            zapis += string.Join(Environment.NewLine,
                vrstice.Select(x => x.Split(';')) //razdeli vsako vrstico na podnize
                    .Select(x => string.Join(";", x))); //razdeljene dele združi nazaj v nize ločeni z ;
            File.WriteAllText(csvDatoteka, zapis); //zapis v datoteko
        }
        catch (Exception e)
        {
            Console.WriteLine("Napaka bri branju datoteke ali pri zapisovanju v csv: " + e.Message);
        }
        
    }

    //Metoda ustvari vozonico za uporabnika
    public static void KupiVozovnico(string letalisce)
    {
        try
        {
            //OSEBNI PODATKI
            Console.WriteLine("OSEBNI PODATKI");
            Console.Write("Vnesi ime: ");
            string ime = Console.ReadLine();

            Console.Write("Vnesi priimek: ");
            string priimek = Console.ReadLine();

            Console.Write("\nNadaljuj na naslednji korak ->");
            Console.ReadKey();
            Console.Clear();

            //Izpis seznam letalisc
            IzpisiLetalisca(letalisce);
            
            // Klic metode za izbiro letališča
            string izbranoLetalisce = PreberiInPreveriLetalisce(letalisce);
            
            Console.Write("\nPritisni tipko za nadaljevanje...");
            Console.ReadKey();
            Console.Clear();
            
            //Izpis odhodov
            IzpisiOdhode(izbranoLetalisce, letalisce);

            // Klic metode za izbiro destinacije
            string izbranaDestinacija = PreberiInPreveriDestinacijo(izbranoLetalisce, letalisce);

            // Izračun časa potovanja
            (int ur, int minute) casPotovanja = IzracunajCasPotovanja(izbranoLetalisce, izbranaDestinacija, letalisce);

            Random rnd = new Random();

            int stNakupa = rnd.Next(1000, 10001);
            int stNakupa1 = rnd.Next(100, 1001);
            string stNakupaZnak = "";
            for (int i = 0; i < 4; i++)
            {
                int nakSt = rnd.Next(65, 91);
                stNakupaZnak += Convert.ToChar(nakSt);
            }
            
            if (casPotovanja.ur != -1 && casPotovanja.minute != -1)
            {
                Console.Clear();
                Console.WriteLine("".PadRight(36, '-'));
                Console.WriteLine("OSEBNI PODATKI");
                Console.WriteLine($"Ime: {ime}");
                Console.WriteLine($"Priimek: {priimek}");
                Console.WriteLine($"Številka nakupa: {stNakupa} - {stNakupa1}{stNakupaZnak}");
                Console.WriteLine("".PadRight(36, '-'));

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

        Console.WriteLine("SEZNAM LETALISC".PadLeft(18));
        Console.WriteLine("----------------------");
        foreach (var letalisce in letalisca)
        {
            Console.WriteLine(letalisce);
        }
        Console.WriteLine("----------------------");
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
        Console.WriteLine(string.Concat(Enumerable.Repeat("-", 48)));
        var odhodi = File.ReadLines(datoteka)
            .Where(vrstica => vrstica.Split(';')[0] == letalisce) // filtrira vrstice na podlagi pogoj, preveri ali je prvi del enak "letalisce"
            .Select(vrstica => vrstica.Split(';')[1]); //zbere določen del vsake vrstice po razdelitvi po podpičju

        //Izpis
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
            Console.Write($"\nIzberi destinacijo iz seznama za letališče {izbranoLetalisce}: ");
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
    
    //Metoda, ki izračuna čas potovanja
    public static (int ur, int minute) IzracunajCasPotovanja(string izbranoLetalisce, string izbranaDestinacija, string datoteka)
    {
        try
        {
            //rebere vrstice iz datoteke in nato poišče prvo vrstico, ki ustreza določenemu pogojnemu izrazu
            //Ko je najdena prva vrstica, ki ustreza tem pogojem, se razdeli na dele in shrani v niz podatki
            string[] podatki = File.ReadLines(datoteka)
                .First(vrstica => vrstica.Split(';')[0] == izbranoLetalisce && vrstica.Split(';')[1] == izbranaDestinacija)
                .Split(';');

            int razdalja = int.Parse(podatki[4]);

            double casPotovanja = razdalja / 800.0; // Izračun časa potovanja v urah, vsa letalo se premikajo z 800km/h

            int ur = (int)casPotovanja; // Celotno število ur
            int minute = (int)((casPotovanja - ur) * 60); // Pretvorba ur v minute

            return (ur, minute);
        }
        catch (Exception e)
        {
            Console.WriteLine("Napaka pri izračunu časa potovanja: " + e.Message);
            return (-1, -1);
        }
    }
    
}