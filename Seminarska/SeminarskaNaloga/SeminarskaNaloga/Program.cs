namespace SeminarskaNaloga;

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
        
        while (true)
        {
            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 64)));
            Console.WriteLine("NALOGE:".PadLeft(18));
            Console.WriteLine("1. Izpis podatkov".PadLeft(24));
            Console.WriteLine("2. Dodaj ekipe v datoteko");
            Console.WriteLine("3. Tajnica (Pretvori v csv)");
            Console.WriteLine("X. Zapri datoteko".PadLeft(24));
            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 64)));

            Console.WriteLine();
            Console.Write("Izberi nalogo: ");
            izbira = Console.ReadLine()[0];
            

            switch (izbira)
            {
                case '1':
                    Console.WriteLine("Izberi način izpisa");
                    Console.WriteLine("a - Izpis imen vseh ekip");
                    Console.WriteLine("b - Izpis vseh podatkov o eni ekipi");
                    Console.Write("Izberi izpis: ");
                    char izpisIzbira = Console.ReadLine()[0];
                    switch (izpisIzbira)
                    {
                        case 'a':
                            Console.Clear();
                            BranjeDatoteke("Ekipa.txt", 'a');
                            break;
                        case 'b':
                            Console.Clear();
                            BranjeDatoteke("Ekipa.txt", 'b');
                            break;
                    }
                    Console.WriteLine("Pritisni tipko za nadaljevanje...");
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
        Console.WriteLine("███████╗ ██████╗ ██████╗ ███╗   ███╗██╗   ██╗██╗      █████╗      ██╗");
        Console.WriteLine("██╔════╝██╔═══██╗██╔══██╗████╗ ████║██║   ██║██║     ██╔══██╗    ███║");
        Console.WriteLine("█████╗  ██║   ██║██████╔╝██╔████╔██║██║   ██║██║     ███████║    ╚██║");
        Console.WriteLine("██╔══╝  ██║   ██║██╔══██╗██║╚██╔╝██║██║   ██║██║     ██╔══██║     ██║");
        Console.WriteLine("██║     ╚██████╔╝██║  ██║██║ ╚═╝ ██║╚██████╔╝███████╗██║  ██║     ██║");
        Console.WriteLine("╚═╝      ╚═════╝ ╚═╝  ╚═╝╚═╝     ╚═╝ ╚═════╝ ╚══════╝╚═╝  ╚═╝     ╚═╝");
        Console.WriteLine("                                                                      ");
        
        Console.WriteLine();
        Console.Write("Pritisni tipko za nadaljevanje...");
        Console.ReadKey();
    }

    public static void BranjeDatoteke(string datoteka, char izbira)
    {
        try
        {
            StreamReader beri = File.OpenText("Ekipe.txt");
            string vrstica = beri.ReadLine();
            string[][] vseEkipe = new string[10][];

            int stevec = 0;
            
            while (vrstica != null)
            {
                vseEkipe[stevec] = vrstica.Split(";");
                stevec++;
                vrstica = beri.ReadLine();
            }

            //Izpis imen vseh ekip
            if (izbira == 'a')
            {
                Console.WriteLine("--- SEZNAM EKIP ---".PadLeft(24));
                for(int i = 0; i < stevec; i++)
                {
                    Console.WriteLine(vseEkipe[i][0].PadLeft(20)); //izpis ekipe na tem indeksu in samo njeno ime
                }
            }

            //Izpis vseh podatkov o eni ekipi
            if (izbira == 'b')
            {
                Console.Write("Vnesi ime ekipe: ");
                string vnos = Console.ReadLine();
                bool najden = false;
                for(int i = 0; i < stevec; i++)
                {
                    if (vnos == vseEkipe[i][0])
                    {
                        Console.WriteLine("Ekipa: " + vseEkipe[i][0] + " \nMotor: " + vseEkipe[i][1] + " \nTP: " + vseEkipe[i][2] +
                                          " \nLokacija: " + vseEkipe[i][3] + " \nNaslovi: " + vseEkipe[i][4]);
                        najden = true;
                        break;
                    }
                }
                if(!najden) Console.WriteLine("Ekipa ni bila najdena!");
            }
            
            beri.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Napaka pri branju datoteke: " + e.Message);
        }
    }
}