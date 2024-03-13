
namespace ObdelavaDatoteke
{
    class Program
    {
        public static void Main(String[] args)
        {
            //Branje tekstovnih datotek po znakih
            //Uporabimo metodo Read. Ta nam vrne kodo znaka, ki ga preberemo, ko bomo naleteli
            //na konec datoteke, bo prebrana koda -1, ki jo uporabimo za to, da vemo, kdaj smp pri koncu.

            StreamReader sr = File.OpenText("Datoteka.txt");
            int beri = sr.Read(); //preberemo prvi znak iz datoteke

            while (beri != -1)
            {
                Console.WriteLine((char)beri); //izpisujemo ustrezne znake
                beri = sr.Read(); //beremo naslednji znak
            }

            sr.Close(); //zapiranje datoteke
            
            //KOPIJA DATOTEKE PO ZNAKIH
            StreamReader beri2 = File.OpenText("Datoteka.txt");
            StreamWriter pisi = File.CreateText("IzhodnaDatoteka.txt");
            int prebranZNak = beri2.Read();

            while (prebranZNak != -1) //konec datoteke
            {
                pisi.Write((char)prebranZNak); //izpisujemo ustrezne znake
                prebranZNak = beri2.Read();
            }

            //StreamReader in StreamWriter obvzeno moramo zapreti!!
            beri2.Close();
            pisi.Close();
            
            //Kopija datoteke po vrsticah
            StreamReader beri3 = File.OpenText("Datoteka.txt"); //odpremo datoteko, ki jo bomo prebrali
            StreamWriter pisi2 = File.CreateText("IzhodnaDatoteka2.txt"); //izpis podatkov v izhodno datoteko
            string vrstica = beri3.ReadLine(); //beremo vrstico

            while (vrstica != null) //dokler ni prazna vrstica
            {
                Console.WriteLine(vrstica); //izpis vrstice
                pisi2.WriteLine(vrstica); //zapis v izhodno datoteko
                vrstica = beri3.ReadLine(); //bermeo naslednjo vrstico
            }
            
            beri3.Close();
            pisi2.Close();
            
            //Napišimo metodo Primerjaj, ki sprejme imeni dveh datotek in primerja njuno vsebino.
            //Če sta vsebini datotek enaki, metoda vrne vrednost true, sicer vrne false. Predpostavimo,
            //da sta imeni datotek ustrezni (torej, da datoteki za branje obstajata).

            string datoteka1 = "Datoteka.txt";
            string datoteka2 = "IzhodnaDatoteka2.txt";
            bool rez = Primerjaj(datoteka1, datoteka2);
            Console.WriteLine(rez);

        }

        public static bool Primerjaj(string datoteka1, string datoteka2)
        {
            //Odpremo obe datoteki za branje
            StreamReader dat1 = File.OpenText(datoteka1);
            StreamReader dat2 = File.OpenText(datoteka2);
            
            //preberemo vsebino prve in druge datoteke
            string beriDatoteko1 = dat1.ReadToEnd(); //vsebina prve datoteke
            string beriDatoteko2 = dat2.ReadToEnd(); //vsebina druge datoteke
            
            //zapremo oba tokova
            dat1.Close();
            dat2.Close();
            
            //primerjamo vsebini
            return (beriDatoteko1.Equals(beriDatoteko2));
        }
    }
}