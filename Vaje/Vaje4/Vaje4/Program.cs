/*
 * Izjavljam, da sem nalogo opravil samostojno in da sem njen avtor. Zavedam se, da v primeru,
 * če izjava prvega stavka ni resnična, kršim disciplinska pravila.
 */

using System.Text.RegularExpressions;

namespace Vaje4
{
    class Program
    {
        public static void Main(String[] args)
        {
            // BREAK AND CONTINUE
            
            //1. Naloga
            //Operacije();

            //2. Naloga
            //MnozenjeDoSto();
            
            /* ************************************************* */
            
            // NIZI 
            
            /* ************************************************* */

            // 3. Naloga
            //Presledki();
            
            // 4. Naloga
            //Manipulacija();

            // 5. Naloga
            //Razmnozi();

            // 6. Naloga TODO revisit
            GeneriranjeGesel();
            
            // 7. Naloga
            //ModernaZgodba();

        }

        public static void Operacije()
        {

            int vsota = 0;
            int stevec = 0;

            while (stevec < 10)
            {
                if (stevec < 5)
                {
                    //Uporabniške številke
                    Console.Write("Vnesi 5 celih števil: ");
                    int stevilka = Int32.Parse(Console.ReadLine());

                    //stevilka je soda, pozitivna in ni mnogokratnik števila 10
                    if (stevilka % 2 == 0 && stevilka > 0 && stevilka % 10 != 0 ) vsota += stevilka;
                    // številka je liha in pozitivna, nobeno liho število ni mnogokratnik 10, ta pogoj je odveč
                    else if (stevilka % 2 != 0 && stevilka > 0) vsota -= stevilka;

                    //Console.WriteLine("Vsota je {0}", vsota); //sprotno preverjanje, vsota DELA pravilno
                    
                    stevec++;
                    continue; //nazaj na pogoj 
                }

                /* //Pomozni izpis
                Console.WriteLine();
                Console.WriteLine("Vsota uporabnikovih cifer " + vsota);
                Console.WriteLine();
                */
                
                //Random številke
                Random rnd = new Random();
                int rndStevilke = rnd.Next(-100, 101);
                rndStevilke = rnd.Next(-100, 101);

                //ista logika kot pri uporabniških številih
                if (rndStevilke % 2 == 0 && rndStevilke > 0 && rndStevilke % 10 != 0) vsota += rndStevilke;
                else if (rndStevilke % 2 != 0 && rndStevilke > 0) vsota -= rndStevilke;

                //Console.WriteLine("Naključna številka " + rndStevilke);
                
                stevec++;
            }
            
            Console.WriteLine("Vsota števil je {0} ", vsota);
        }

        public static void MnozenjeDoSto()
        {
            Console.Write("Vnesi realno število: ");

            double vnos = Double.Parse(Console.ReadLine());
            double stevilkaZaIpis = vnos;

            int stevec = 0;

            //če ni pozitivno število se program zaključi
            if (vnos < 0)
            {
                Console.WriteLine("Število mora biti večje od 0!");
                Environment.Exit(1); 
            }

            while (true) //zanka se vendo izvede tudi za število večje od 100
            {
                // izračuna tudi, če je večje od 100 ampak v if stavku potem števec odštejemo tako, da je 
                // v izpisu za števila večje od 100 vedno piše da smo ga 0 pomnožili da smo prišli do 100 kar je pravilno.
                
                vnos *= 1.1;
                //Console.WriteLine(vnos);
                stevec++;
                
                if (vnos > 100) //odštejemo števec da dobimo zadnje število, ki ni preseglo 100 in končamo zanko
                {
                    stevec--;
                    break;
                }
            }

            Console.WriteLine("Vašo številko {0} je bilo potrebno {1} pomnožiti z 1.1 da ste prišli do 100", stevilkaZaIpis, stevec);
        }
        
        public static void Presledki()
        {
            Console.Write("Vnesi niz: ");
            string vnos = Console.ReadLine();
            Console.WriteLine(vnos);
            string noviStavek = "";

            for (int i = 0; i < vnos.Length; i++) //sprehod po nizu
            {
                if (vnos[i] != 32) noviStavek += vnos[i] + " "; //če ni presledek potem naredi presledek za znakom
                else noviStavek += ""; // če je presledek ga ne podvoji
            }

            Console.WriteLine(noviStavek);
        }
        
        public static void Manipulacija()
        {
            string stavek = "  Čeprav je še včeraj snežilo, je dan lep in sončen. Avtobus je imel zamudo, ampak nič ne de.   ";
            
            /* vodilni in končni presledki - TRIM */
            string trim = stavek.Trim();
            Console.WriteLine(trim);
            
            /* Zamenjava v angleške črke  ... ali poenostaviš pa uporabiš Replace v stavku*/
            string zamenjava = "";
            for (int i = 0; i < stavek.Length; i++)
            {
                char trenutniZnak = stavek[i];

                switch (trenutniZnak)
                {
                    case 'č':
                    case 'ć':
                        zamenjava += 'c';
                        break;
                    case 'Č':
                    case 'Ć':
                        zamenjava += 'c';
                        break;
                    case 'ž':
                        zamenjava += 'z';
                        break;
                    case 'Ž':
                        zamenjava += 'ž';
                        break;
                    case 'š':
                        zamenjava += 's';
                        break;
                    case 'Š':
                        zamenjava += 'š';
                        break;
                    default:
                        zamenjava += trenutniZnak;
                        break;
                }

            }
            Console.WriteLine(zamenjava.ToLower());

            /* Vrne podniz zadnji štirih znakov brez končnih presledkov */
            Console.WriteLine(trim.Substring(trim.Length - 4));
            
            /* Različni znaki od A in a*/
            string maliStavek = stavek.ToLower();
            int stevecZnakov = 0;

            for (int i = 0; i < maliStavek.Length; i++)
            {
                if (maliStavek[i] != 'a') stevecZnakov++;
            }

            Console.WriteLine("V stavku je {0} znakov različnih od A oz. a", stevecZnakov);
            
            /* Zadnje tri znake nadomesti z ___  */
            string izpis = stavek.Trim().Remove(stavek.Trim().Length - 3,3); // odstrani vodilne in končne presledke, nato odstrani de.
            Console.WriteLine(izpis.Insert(izpis.Length, "...")); //vstavi ... na koncu niza
            
            /*string nadomestek = trim.Substring(trim.Length - 3);

            for (int i = 0; i < nadomestek.Length; i++)
            {
                nadomestek = nadomestek.Replace(nadomestek[i], '_');
            }*/
            //Console.WriteLine(nadomestek);
            
            /* Sredina niza */
            string vstavi = stavek.Insert(stavek.Length / 2, "___");
            Console.WriteLine(vstavi);
            
            /* Odstrani vse znake od šestega niza naprej */
            Console.WriteLine(stavek.Remove(6));
            
        }

        public static void Razmnozi()
        {
            Console.Write("Vnesi niz: ");
            string vnos = Console.ReadLine();
            
            Console.Write("Vnesi kolikokrat bi razmnožil niz: ");
            int stevilka = Int32.Parse(Console.ReadLine());

            string novNiz = "";

            //sprehod po nizu
            for (int i = 0; i < vnos.Length; i++)
            {
                var ponovitev = Enumerable.Repeat(vnos[i], stevilka); //uporabim Enumerable za ponavljanje vsake črke
                //namesto var-a lahko lahko napišem IEnumerable<char> je samo za boljši pregled
                Console.Write(string.Join("", ponovitev)); //združimo v en niz
            }
        }
        
        public static void GeneriranjeGesel()
        {
            string geslo = "";
            
            //1. in 2. znak naključni števki,
            int stevec = 0;
            Random rnd = new Random();
            while (stevec < 2)
            {
                int nakSt = rnd.Next(0, 10);
                geslo += nakSt;
                stevec++;
            }
            //Console.WriteLine(geslo);

            //3 znak je velika oz. mala črka ang abecede

            Random nakljucno = new Random();
            string znaki = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            
            char nakZnak = znaki[nakljucno.Next(znaki.Length)];
            geslo += nakZnak;
            
            //Console.WriteLine(geslo);
            
            // 4 naključen soglasnik ang abecede
            string soglasniki = "QqRrTtZzPpSsDdFfGgHhJjKkLlXxCcVvBbNnMm";
            
            int nakljucenSoglasnik = rnd.Next(soglasniki.Length); //naključen indeks znaka
            char znakSoglasnik = soglasniki[nakljucenSoglasnik]; // ta indeks je shranjen v char znakSoglasnik
            geslo += znakSoglasnik;

            /*int znakStevilka;
            do
            {
                znakStevilka = rnd.Next(65, 123);
                char znak = Convert.ToChar(znakStevilka);
                geslo += znak;

            } while (znakStevilka >= 91 && znakStevilka <= 96 );*/
            
            
            // 5 naključen samoglasnik ang abecede
            string samoglasniki = "AEIOUWYaeiouwy"; //v angleščini sta w in y samoglasnika "včasih"
            int naključenSamoglasnik = rnd.Next(samoglasniki.Length);
            char znakSamoglasnika = samoglasniki[naključenSamoglasnik];
            geslo += znakSamoglasnika;
            
            //Console.WriteLine(geslo);
            
            // 6 - 7 naključno sodo število
            stevec = 0;
            while (stevec < 2)
            {
                int nakSt = rnd.Next(5,50)*2;
                geslo += nakSt;
                stevec++;
            }

            //Console.WriteLine(geslo);
            
            // 8 -9 naključno liho število
            stevec = 0;
            while (stevec < 2)
            {
                int nakSt = rnd.Next(6,50)*2-1;
                geslo += nakSt;
                stevec++;
            }

            Console.WriteLine("Končno geslo je {0}", geslo);
        }

        public static void ModernaZgodba()
        {
            string besedilo =
                "Bedanec je vedno rad koval načrte, kako bi premagal Kekca, najbolj premetenega fanta v vasi." +
                "\nTokrat se je odločil, da ga bo premagal z izjemno pametno zvijačo. Pripravil je past iz vrvi in vej, " +
                "\na Kekec je bil preveč previden. Ko se je Bedanec že veselil zmage, ga je Kekec presenetil " +
                "z lastno zvijačo\nin ga pustil v svoji pasti, smejoč se: \"Naslednjič bolje premisli, Bedanec!\"";

            // Zamenjaj bedanec v starec in Kekec v deček
            besedilo = besedilo.Replace("Bedanec", "starec").Replace("Kekec", "deček");
            Console.WriteLine(besedilo);
            Console.WriteLine();

            // odstrani pametno in vej
            besedilo = besedilo.Replace("pametno", "").Replace("vej", "");
            Console.WriteLine(besedilo);
            Console.WriteLine();
            
            // Na koncu besedila vstavi niz
            besedilo = besedilo.Insert(besedilo.Length - 1, " Naslednjič bolje premisli!");
            Console.WriteLine(besedilo);
            Console.WriteLine();

            // Prvi stavek z veliko začetnico 
            string velikaPrvaCrka = Convert.ToString(besedilo[0]).ToUpper(); //vzamemo prvi znak in ga spremenimo v veliko črko
            Console.WriteLine(velikaPrvaCrka + besedilo.Substring(1)); //začnemo podniz od t naprej
        }
    }
}