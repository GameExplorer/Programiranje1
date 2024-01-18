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
            
            tabeliranjeFunckije();
            
            #endregion
            
            #region Vaje 6 - Oblikovanje s for zanko
            
            //oblikovanjeIzpisa();
            
            #endregion
        }

        public static void generator()
        {
            int stevec = 0; //šteje poskuse
            Random rnd = new Random();
            int generiranoStevilo = rnd.Next(-100, 101); //zgornja meja ni naključna
            int nakSt = generiranoStevilo; //prva spremenljvka je začasna da lahko vstopim v zanko
            //Obstaja možnost, da bo 0 prvo število zato bi lahko nastavil na -100, tako    
            //bi vedno se zanka izvedla vsaj enkrat ampak se mi zdi, da je tole bolje
            while (nakSt != 0)
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
            int naravnoStevilo = Int32.Parse(Console.ReadLine());
            int naravnoSteviloIzpis = naravnoStevilo; //naravnoStevilo se v zanki spremeni, zato naredim tmp spremenljivko za izpis

            int produkt = 1;
            do
            {
                int stevka = naravnoStevilo % 10;
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
            int n = 0; //števec

            Console.WriteLine("Prvih 50 naravnih števil, ki so deljiva s 3 in niso soda: ");
            
            for (int i = 0; n <= 50; i++)
            {
                int naravnoSt = i; //naravna števila, ki ustrezajo pogoju
                if (naravnoSt % 3 == 0 && naravnoSt % 2 != 0) //pregledamo ali ustrezajo pogoju
                {
                    Console.WriteLine(naravnoSt);
                    n++;
                }
            }
        }
        public static void medDvemaSteviloma()
        {
            Console.WriteLine("Vnesi dve števili!");
            
            Console.Write("Število a: ");
            int st1 = Int32.Parse(Console.ReadLine());
            
            Console.Write("Število b: ");
            int st2 = Int32.Parse(Console.ReadLine());

            if (st1 < st2)
            {
                Console.Write("Ob vnosu števil " + st1 + " in " + st2 + " je zaporedje ");
                while (st1 <= st2)
                {
                    Console.Write(st1);

                    if (st1 < st2) //ta pogoj uporabim, da na zadnjem mestu ne dodam vejice
                    {
                        Console.Write(", ");
                    }
                    st1++;
                }
            }

            else
            {
                Console.Write("Ob vnosu števil " + st1 + " in " + st2 + " je zaporedje ");
                while (st2 <= st1)
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

        /**
         * Tabelirajte funkcijo y = tan(x) na intervalu od 0 do π s korakom π/10.
         * Če vrednost y vmes preseže 10, prekinite izvajanje zanke.
         */
        public static void tabeliranjeFunckije()
        {
            double y; //y vrednost

            for (double x = 0; x <= Math.PI; x += Math.PI / 10)
            {
                y = Math.Tan(x);
                if (y > 10) break;
                Console.WriteLine($"tan({y}) = {x}");
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

        //todo revisit
        public static void oblikovanjeIzpisa()
        {
            //rezultat
            int rezultat = 1;
            int trikotnik = 0; //pol trikotnik začetek
            for(int i = 1; i <= 9; i++) //(x+1)
            {
                Console.WriteLine($"{trikotnik} * 9 + {i} = {rezultat}");
                trikotnik = (trikotnik * 10) + i; //0 .. 1 .. 12 ...
                rezultat = (trikotnik * 9) + (i+1); //0 * 9 + 1 = 1... 1 * 9 + 2 = 11 ...
            }
        }
    }
}