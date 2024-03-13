namespace DatotekeOsnove
{
    class Program
    {
        public static void Main(String[] args)
        {
            string dir =
                "\\Programiranje1\\Naloge\\Datoteke\\DatotekeOsnove\\DatotekeOsnove";

            if (!Directory.Exists(dir)) //pogledamo, če imenik obstaja, če ne ga ustvarimo
            {
                Directory.CreateDirectory(dir);
            }

            string[] datoteke = Directory.GetFiles(dir); //imena datotek v mapi
            Console.WriteLine("Seznam datotek v imeniku DatotekeOsnove: ");

            foreach (string imeDatoteke in datoteke) //izpis imen datotek v naši mapi
            {
                Console.WriteLine(imeDatoteke);
            }

            DateTime datum = Directory.GetCreationTime(@"C:\Windows"); 
            Console.WriteLine("Mapa Windwos je bila ustvarjena " + datum.ToShortDateString()); //izpišemo, kdaj je bila mapa ustvarjena

            string[] mape = Directory.GetDirectories(@"C:\Program Files"); //Podmape
            foreach(string ime in mape) //izpišemo imena vseh datotek mape 
                Console.WriteLine(ime);

            string mapa = @"Program Files";
            Console.WriteLine("Mapa " + mapa + " se nahaja na disku " + Directory.GetDirectoryRoot(@"C:\Program Files"));

            string tekocaMapa = Directory.GetCurrentDirectory(); //pot do mape
            Console.WriteLine(tekocaMapa); //izpis tekoče mape
            
            //Pridobivanje celotne poti do datoteke
            string datIme = "Datoteka.txt";
            string celotnaPot = Path.GetFullPath(datIme);
            Console.WriteLine(celotnaPot);
            
            
            //Metodi Exists in CreateText
            Console.Write("Ime datoteke (brez končnice): ");
            string datotekaIme = Console.ReadLine();
            datotekaIme += ".txt";

            if (File.Exists(datotekaIme)) Console.WriteLine("Datoteka " + datotekaIme + " že obstaja!");
            else
            {
                //ZAPIS STAVKA V DATOTEKO
                StreamWriter pisi = File.CreateText(datotekaIme);
                Console.WriteLine(Path.GetFullPath(datotekaIme)); //izpis celotne poti datoteke
                pisi.WriteLine("Stavek bo zapisan v datoteko");
                pisi.Close(); //zapremo datoteko OBVEZNO!
                Console.WriteLine("Ustvarili smo datoteko " + datotekaIme);
                
                //PREPIS STAVKA V DATOTEKO
                string stavekPrepis = "Tudi ta stavek bo zapisan v datoteko";
                File.WriteAllText(datotekaIme, stavekPrepis);
                Console.WriteLine("Ustvarilo smo datoteko " + datotekaIme);
            }
            
            //Zapis celotne tabele imen v datoteko
            string[] Imena = {"Janko", "Metka", "Ana", "Petra" };
            File.WriteAllLines("Imena.txt", Imena);
            
            //Zapis poljubnega niza v datoteko
            string stavek = "Ta stavek bomo zapisali v datoteko!";
            File.WriteAllText("Vaja.txt", stavek);
            
            //Dodajanje niza v datoteko
            string stavek1 = "\nTa stavek bomo dodali v datoteko";
            File.AppendAllText("Vaja.txt", stavek1);
            
            //Brisanje datoteke
            string imeDatoteke2 = "test2.txt";
            if(File.Exists(imeDatoteke2)) File.Delete(imeDatoteke2);
            
            //Kopiranje datoteke
            string imeDatoteke3 = "Vaja.txt";
            if(File.Exists(imeDatoteke2)) 
                File.Copy(imeDatoteke3, "Rezerva.txt");

            //Branje besedila
            string vsebina = File.ReadAllText("Vaja.txt");
            Console.WriteLine(vsebina); //izpis niza
            
            //Branje vsebine datoteke tabele nizov
            string[] stavki2 = File.ReadAllLines("Imena.txt");

            foreach (string ime in stavki2)
            {
                Console.WriteLine(ime);
            }
            
            //Zapis podatov, vsak v svojo vrstico
            StreamWriter pisi2 = File.CreateText("Podatki.txt");
            pisi2.WriteLine("Ivan Cankar");
            pisi2.WriteLine("Cankarjeva 22");
            pisi2.WriteLine("1000 Ljubljana");
            pisi2.Close();
            
            //2. način
            string besedilo2 = "Ivan Cankar \nCankarjeva 22 \n1000 Ljubljana";
            File.AppendAllText("Podatki1.txt", besedilo2); //ustvarimo novo datoteko in vanjo zapišemo besedilo

            File.WriteAllText("Podatki2.txt", besedilo2); //če datoteka že obstajam, prepiše besedilo

            //Zapis 100 števil v datoteko

            if (File.Exists("Stevila.txt")) Console.WriteLine("Datoteka že obstaja");
            else
            {
                //1. Način, vsako število posebi zapišemo v datoteko
                StreamWriter pisi3 = File.CreateText("Stevila.txt");

                for (int i = 0; i < 100; i++) pisi3.WriteLine(i); //vsako število v svoji vrstici
                pisi3.Close();
                
                //2. Način, najprej ustvarimo niz števil nato pa celoten niz zapišemo v datoteko
                string stevila = "";
                for (int i = 0; i < 100; i++) stevila += i + "\n";
                File.AppendAllText("Stevila1.txt", stevila); //zapiranje datoteke ni potrebno, ker metoda jo sama zapre
            }
            
            //UPORABNIŠKI VNOS STAVKOV V DATOTEKO
                
            //1. način
            StreamWriter pisi5 = File.CreateText("Besedilo.txt");
            while (true)
            {
                Console.Write("Vnesi stavek: ");
                string stavek2 = Console.ReadLine();
                if (stavek2.Length > 0) //stavek vsebuje vsaj en znak
                    pisi5.WriteLine(stavek2);
                else break; //uporabnik vnese prazen niz
            }

            pisi5.Close();
            
            //2. način

            string besedilo = "";
            while (true)
            {
                Console.Write("Vnesi poljuben stavek: ");
                string stavek6 = Console.ReadLine();

                if (stavek6.Length > 0)
                    besedilo += stavek6 + "\n";
                else break; //vnesemo prazen niz
            }
            File.AppendAllText("Besedilo1.txt", besedilo);
            
            
            //Branje datoteke, izračun povprečne vrednosti števil
            //1. Način obdelujemo vsako vrstico posebej
            string ime2 = "Stevila.txt";
            int vsota = 0;
            int stVrstic = 0; //začetno število vrstic v datoteki
            StreamReader beri = File.OpenText("Stevila.txt"); //odpiranje datoteke za branje
            string vrstica = beri.ReadLine(); //skušamo brati prvo vrstico

            while (vrstica != null) //če je bilo branje uspešno 
            {
                stVrstic++;
                int stevilo = Convert.ToInt32(vrstica); //pretvorba v število
                vsota += stevilo;
                vrstica = beri.ReadLine(); //beremo naslednjo vrstico
            }

            beri.Close();
            Console.WriteLine("V datoteki je " + stVrstic + " vrstic");
            Console.WriteLine("Povprečje vseh števil je " + ((double) vsota / stVrstic));
            
            //2.način vsebino prenesemo v tabelo nizov nato pa obdelujemo to tabelo
            string[] tabelaVrstic = File.ReadAllLines("Stevila.txt");
            vsota = 0;

            for (int i = 0; i < tabelaVrstic.Length; i++)
            {
                vsota += Int32.Parse(tabelaVrstic[i]); //vesbino celice pretvorimo v število in prištejemo k vsoti
            }

            double povprecje = Convert.ToDouble(vsota) / tabelaVrstic.Length;
            Console.WriteLine("Njihova povprečna vrednost je " + povprecje);
        }
    }
}