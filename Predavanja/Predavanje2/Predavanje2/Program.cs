
namespace Predavanje2
{
    class Program
    {
        static void Main(String[] args)
        {
            #region Prvi primer
            // Uporabnik pozovemo naj vnese 3 mestno število, nato izračunamo enice, desetice in stotice in jih
            // posebi izračunaj

            /*Console.Write("Vnesi tri-mestno število: ");
            int st = Int32.Parse(Console.ReadLine());

            int enice = st % 10;
            int desetice = st / 10 % 10;
            int stotice = st / 100 % 10;
            
            Console.WriteLine("Enice: " + enice);
            Console.WriteLine("Desetice: " + desetice);
            Console.WriteLine("Stotice: " + stotice);
            
            #endregion

            #region Random

            /*Random rnd = new Random(/*142#1#); // inicilizacija s semenon (seed), Imamo več vrst generatorjev
            //če nastavimo seme bomo vedno dobilo ista števila 
            
            
            Console.WriteLine(rnd.Next(10, 100));
            Console.WriteLine(Random.Shared.Next(10, 100)); //podobno kot zgoraj, ne moreš ga fiksirati
            
            // Program naj zgenerira dvomestno število, naj uporabnika vpraša katero je to, če ga ugane
            // super sicer več sreče prihodnjič

            int nakStevilo = rnd.Next(10, 100);

            Console.Write("Vnesi število: ");
            int vnesenoStevilo = Int32.Parse(Console.ReadLine());

            if (vnesenoStevilo == nakStevilo)
            {
                Console.WriteLine("Super, uganil si pravilno!");
            }
            else
            {
                Console.WriteLine("Več sreče prihodnjič");
                Console.WriteLine("Pravilno število: " + nakStevilo);
            }*/

            #endregion
            
            #region If Stavek

            /*Console.WriteLine();
            // Prodajamo vstopnice
            // Če je uporabnik pod 18 je vstopnica je 5€, če je več kot 18 in manj kot 60 je 20€, sicer 10€

            Console.Write("Vnesi starost: ");
            int starost = Int32.Parse(Console.ReadLine());

            if (starost < 18)
            {
                Console.WriteLine("Vaša vstopnica stane 5€!");
                //Environment.Exit(0);
                //return; druga opcija
            }
            if (starost >= 18 && starost < 60)
            {
                Console.WriteLine("Vaša vstopnica stane 20€!");
                //Environment.Exit(0); //uporaba okoljske spremenljivke
            }*/
            
            /*
             * if(starost < 18) { ... } pod 18 ... 5€
             * else if(starost >= 60) { ... } nad 60 ... 10€
             * else { ... } ostali ... 20€
             */

            /*Console.WriteLine("Vaša vstopnica stane 10€!");

            //Vejitve pri navadnih programih so dobrodošle
            
            // switch nekaj novega
            Console.WriteLine(starost switch
            {
                < 18 => "5 EUR",
                >= 60 => "10 EUR",
                _ => "20 EUR"
            });*/

            #endregion

            #region Ocena

            //Student vnese oceno od 1 do 10
            //program izpiše odlično, če je ocena 10, program izpiše ocena če je med 6 in 9
            //program izpiše ni opravil če je manjša od 6
            
            /*Console.Write("Vnesi oceno: ");
            int ocena = Int32.Parse(Console.ReadLine());

            if (ocena >= 6 && ocena <= 9)
            {
                Console.WriteLine("OPRAVIL!");
            }
            
            else if (ocena < 6)
            {
                Console.WriteLine("Ni Opravil!");
            }

            else if (ocena == 10)
            {
                Console.WriteLine("Odlično!");
            }
            else
            {
                Console.WriteLine("Napačen vnos");
            }*/
            
            /*Console.WriteLine(ocena switch
            {
                < 6 => "Ni Opravil",
                10 => "Odlično",
                _ => "Opravil",
            });*/

            #endregion
            
            #region Prestopno leto

            /*Console.Write("Vnesi leto: ");
            int leto = Int32.Parse(Console.ReadLine());

            if (leto % 4 == 0 && leto % 100 != 0 || leto % 400 == 0)
            {
                Console.WriteLine("Prestopno leto");
            }
            else
            {
                Console.WriteLine("Leto ni prestopno");
            }
            */

            #endregion
            
            #region Največja števka

            /*Random nak = new Random();
            int stevilo = nak.Next(100, 1000);
            int stIzpis = stevilo;

            int maxStevka = stevilo % 10;

            stevilo = stevilo / 10;

            int desetka = stevilo % 10;

            if (desetka > maxStevka) maxStevka = desetka;

            stevilo = stevilo / 10; //stotice

            if (stevilo > maxStevka)
            {
                maxStevka = stevilo;
            }
            
            Console.WriteLine("Največja števka števila " + stIzpis + " je " + maxStevka);*/
            
            #endregion
            
            #region While

            /*int stevec = 0;
            int dva = 0;
            int sest = 0;

            Random kocka = new Random();

            while (stevec < 6_000_000)
            {
                int steviloNaKocki = kocka.Next(1, 7);

                if (steviloNaKocki == 2) dva++;
                if (steviloNaKocki == 6) sest++;

                stevec++;
            }

            Console.WriteLine("Dvojka je padla " + dva);
            Console.WriteLine("Šestka je padla " + sest);

            if (sest > dva)
            {
                Console.WriteLine("Šestka je padla za " + (sest - dva) + " več");
            }
            else
            {
                Console.WriteLine("Dvojka je padla za " + (dva - sest) + " več");
            }

            double x = 4.2;

            while (x > 1) // 4.2 > 1 T ... 2.1 > 1 T ... 1.05 > 1 T ... 0.525 > 1 F ... x3 se izvede
            {
                x = x / 2;
            }

            // UGANIMO NAKLJUČNO ŠTEVILO
            Random nakStevilo = new Random();
            int izbranoStevilo = nakStevilo.Next(1, 100);
            
            Console.Write("Vnesi število: ");
            int vnesenoStevilo = Int32.Parse(Console.ReadLine());

            int neuspeh = 0;

            while (vnesenoStevilo != izbranoStevilo)
            {
                neuspeh++;
                if (vnesenoStevilo > izbranoStevilo)
                {
                    Console.WriteLine("Vneseno število je preveliko!");
                }else 
                { 
                    Console.WriteLine("Vneseno število je premajhno!");
                }
                Console.Write("Nisi vnesel pravilnega števila! Poskusi ponovno: ");
                vnesenoStevilo = Int32.Parse(Console.ReadLine());
            }

            Console.WriteLine("Uspelo ti je uganiti v " + neuspeh + " poskusih");*/

            #endregion

            #region Do-While

            /*Random naklj = new Random();
            int a = naklj.Next(1, 11);
            int b;
            do
            {
                b = naklj.Next(1, 11);
            } while (b == a); //zanka se ponavlja toliko časa dokler je stranica b enaka a
            
            
            float st, sestevek=0;
            int n = 0;    //števec vnesenih števil
            do
            {  //ponavljaj, dokler je vpisano število različno od 0
                Console.Write("Vnesi število oz. 0 za konec/ ...");
    
                st = Convert.ToInt32(Console.ReadLine());
                if (st != 0)//če je vneseno število različno od 0
                {
                    n++;
                    sestevek = sestevek + st;
                }
            } while (st != 0);
            Console.WriteLine("\nSeštevek števil je "+sestevek);
            if (n != 0) //povprečje računamo le, če bilo vneseno vsaj eno število
            {
                float povp = sestevek / n;
                Console.WriteLine("\nNjihova povprecna vrednost pa je " + povp);
            }
            */


            #endregion

            #region For Zanka

            for (int i = 0; i < 10; i++)
            {
                for (int j = 10; j >= i; j--)
                {
                    Console.Write(i);
                }

                Console.WriteLine();
            }

            #endregion
        }
    }
}
