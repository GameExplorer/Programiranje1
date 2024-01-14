// See https://aka.ms/new-console-template for more information

namespace Predavanje2
{
    class Program
    {
        static void Main(String[] args)
        {
            #region Prvi primer
            // Uporabnik pozovemo naj vnese 3 mestno število, nato izračunamo enice, desetice in stotice in jih
            // posebi izračunaj

            Console.Write("Vnesi tri-mestno število: ");
            int st = Int32.Parse(Console.ReadLine());

            int enice = st % 10;
            int desetice = st / 10 % 10;
            int stotice = st / 100 % 10;
            
            Console.WriteLine("Enice: " + enice);
            Console.WriteLine("Desetice: " + desetice);
            Console.WriteLine("Stotice: " + stotice);
            
            #endregion

            #region Random

            Random rnd = new Random(/*142*/); // inicilizacija s semenon (seed), Imamo več vrst generatorjev
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
            }

            #endregion
            
            #region If Stavek

            Console.WriteLine();
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
            }
            
            /*
             * if(starost < 18) { ... } pod 18 ... 5€
             * else if(starost >= 60) { ... } nad 60 ... 10€
             * else { ... } ostali ... 20€
             */

            Console.WriteLine("Vaša vstopnica stane 10€!");

            //Vejitve pri navadnih programih so dobrodošle
            
            // switch nekaj novega
            Console.WriteLine(starost switch
            {
                < 18 => "5 EUR",
                >= 60 => "10 EUR",
                _ => "20 EUR"
            });

            #endregion

            #region Ocena

            //Student vnese oceno od 1 do 10
            //program izpiše odlično, če je ocena 10, program izpiše ocena če je med 6 in 9
            //program izpiše ni opravil če je manjša od 6
            
            Console.Write("Vnesi oceno: ");
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
            }
            
            /*Console.WriteLine(ocena switch
            {
                < 6 => "Ni Opravil",
                10 => "Odlično",
                _ => "Opravil",
            });*/

            #endregion
            
            #region Prestopno leto

            Console.Write("Vnesi leto: ");
            int leto = Int32.Parse(Console.ReadLine());

            if (leto % 4 == 0 && leto % 100 != 0 || leto % 400 == 0)
            {
                Console.WriteLine("Prestopno leto");
            }
            else
            {
                Console.WriteLine("Leto ni prestopno");
            }

            #endregion
            
            #region Največja števka

            Random nak = new Random();
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
            
            Console.WriteLine("Največja števka števila " + stIzpis + " je " + maxStevka);
            
            #endregion
        }
    }
}
