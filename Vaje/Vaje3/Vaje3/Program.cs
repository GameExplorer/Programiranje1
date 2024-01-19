// Izjavljam, da sem nalogo opravil samostojno in dam sen njen avtor.
// Zavedam se, da v primeru, če izjava prvega stavka ni resnična, kršim disciplinska pravila

namespace Vaje3
{
    class Program
    {
        public static void Main(String[] args)
        {
            #region Vaje 1 - While
            
            // Koliko poskusi, da generator naključnih števil generira število 0
            //generator();
            
            #endregion
            
            #region Vaje 2 - Do While
            
            //Izračun neničelnih števk naranvnega števila

            //naravniProdukt();

            #endregion
            
            #region Vaje 3 - Zanka For

            //izpisPrvihNaravnihStevil();
            
            #endregion
            
            #region Vaje 4 - Med dvema številoma

            //medDvemaSteviloma();
            
            #endregion
            
            #region Vaje 5 - Tabeliranje funkcije
            
            //tabeliranjeFunckije();
            
            #endregion
            
            #region Vaje 6 - Oblikovanje s for zanko
            
            oblikovanjeIzpisa();
            
            #endregion
        }

        public static void generator()
        {
            int stevec = 0; //šteje poskuse
            Random rnd = new Random(); 
            int generiranoStevilo = rnd.Next(-100, 101); //ustvarimo naključna števila
            int nakSt = generiranoStevilo; //prva spremenljvka je začasna da lahko vstopim v zanko
            //Obstaja možnost, da bo 0 prvo število zato bi lahko nastavil na -100, tako    
            //bi vedno se zanka izvedla vsaj enkrat ampak se mi zdi, da je tole bolje
            while (nakSt != 0) //dokler ni 0 izvedi se
            {
                nakSt = rnd.Next(-100, 101);
                //Console.WriteLine(nakSt);
                stevec++;
            }
            Console.WriteLine("Generator je potreboval " + stevec + " poskuse, da je generiral 0");

        }
        public static void naravniProdukt()
        {
            Console.Write("Vnesi naravno število: ");
            int naravnoStevilo = Int32.Parse(Console.ReadLine()); //preberemo število od uporabnika
            int naravnoSteviloIzpis = naravnoStevilo; //naravnoStevilo se v zanki spremeni, zato naredim začasno spremenljivko za izpis

            int produkt = 1;
            
            do
            {
                int stevka = naravnoStevilo % 10; // 1024 ... 102 ostane 4 .. potem 4 preverjamo v if stavku
                if (stevka != 0) //če števka ni 0 zmnoži števke, če je jo preskoči in deli naprej
                {
                    produkt *= stevka;
                    //Console.WriteLine(produkt);
                }
                naravnoStevilo /= 10;

            } while (naravnoStevilo > 0);

            Console.WriteLine("Za število " + naravnoSteviloIzpis + " program vrne produkt " + produkt);
        }
        public static void izpisPrvihNaravnihStevil()
        {
            int n = 0; //števec, ki šteje naravna števila

            Console.WriteLine("Prvih 50 naravnih števil, ki so deljiva s 3 in niso soda: ");
            
            for (int i = 0; n <= 50; i++)
            {
                if (i % 3 == 0 && i % 2 != 0) //pregledamo ali število ustreza pogoju
                {
                    Console.WriteLine(i);
                    n++; //povečamo števec
                }
            }
        }
        public static void medDvemaSteviloma()
        {
            Console.WriteLine("Vnesi dve števili!"); //zahtevamo vnos od uporabnika
            
            Console.Write("Število a: ");
            int st1 = Int32.Parse(Console.ReadLine());
            
            Console.Write("Število b: ");
            int st2 = Int32.Parse(Console.ReadLine());

            if (st1 < st2) //če je prvo število večje od drugega
            {
                Console.Write("Ob vnosu števil " + st1 + " in " + st2 + " je zaporedje ");
                while (st1 <= st2) //dokler je prvo manjše od drugega izvajaj zanko
                {
                    Console.Write(st1);

                    if (st1 < st2) //ta pogoj uporabim, da na zadnjem mestu ne dodam vejice
                    {
                        Console.Write(", ");
                    }
                    st1++; //povečujemo prvo število
                }
            }

            else //prvo število je večje od drugega
            {
                Console.Write("Ob vnosu števil " + st1 + " in " + st2 + " je zaporedje ");
                while (st2 <= st1) //zanka v obratni smeri
                {
                    Console.Write(st2);
                    if (st2 < st1)
                    {
                        Console.Write(", ");
                    }
                    st2++;
                }
            }
        }
        
        public static void tabeliranjeFunckije()
        {
            double y; //y vrednost

            for (double x = 0; x <= Math.PI; x += Math.PI / 10) //od 0 do Pi
            {
                y = Math.Tan(x); //tabeliranje funkcije
                if (y > 10) break; //če preseže 10 konča izvajanje
                Console.WriteLine($"tan({y}) = {x}"); //izpis
            }   

            //Alternativa 
            /*double x = 0;
            while (x <= Math.PI)
            {
                y = Math.Tan(x);
                Console.WriteLine($"tan({y}) = {x}");
                if (y > 10) break;
                x += Math.PI / 10
            }*/
        }
        
        public static void oblikovanjeIzpisa()
        {
            int rezultat = 1; //rezultat mora biti 1 ker je prvi rezultat 1
            int trikotnik = 0; //pol trikotnik začetek
            
            for(int i = 1; i <= 9; i++) //(x+1)
            {
                //prvi rezultat je že zapisan v prvi vrstici...
                Console.WriteLine($"{trikotnik} * 9 + {i} = {rezultat}");
                trikotnik = (trikotnik * 10) + i; //0 * 10 + 1 = 1 ...  1 * 10 + 2 = 12 ...
                rezultat = (trikotnik * 9) + (i+1); //1 * 9 + 2 = 11... 12 * 9 + 3 = 111 ...
            }
        }
    }
}