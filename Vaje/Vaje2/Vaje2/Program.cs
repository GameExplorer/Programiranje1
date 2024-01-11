// See https://aka.ms/new-console-template for more information

using System.Reflection.Metadata;

namespace Vaje2
{
    class Vaje2
    {
        static void Main(String[] args)
        {

            #region Vaja 1
            // Console.Write("Vnesite število a: ");
            // int a = Int32.Parse(Console.ReadLine());
            // Console.Write("Vnesite število b: ");
            // int b = Int32.Parse(Console.ReadLine());
            //
            // Console.WriteLine("Vnesli ste števili a = " + a + " in b = " + b);
            //
            // Console.WriteLine("a + b = " + a + " + " + b + " = " + (a+b));
            // Console.WriteLine("a - b = " + a + " - " + b + " = " + (a-b));
            // Console.WriteLine("a / b = " + a + " / " + b + " = " + (a/b));
            // Console.WriteLine("a / b = " + a + " / " + b + " = " + ((double)a/b)); //casting
            // Console.WriteLine("a % b = " + a + " % " + b + " = " + (a%b));
            
            #endregion
            
            #region Vaja 2

            // Console.Write("Vnesite celo število do 999: ");
            // int stevilo = Int32.Parse(Console.ReadLine());
            //
            // // 2.1 Preverimo ali je sodo ali liho
            //
            // if (stevilo > 999 || stevilo < 0) Environment.Exit(0);
            //
            // if (stevilo % 2 == 0)
            // {
            //     Console.WriteLine("Število " + stevilo +  " je sodo");
            // }
            // else
            // {
            //     Console.WriteLine("Število " + stevilo + " je liho");
            // }
            //
            // // 2.2 Izpis števila, ki je za eno manjše od vnesenega in za eno večje od vnesenega
            //
            // Console.WriteLine("Število za 1 manjše: " + (stevilo - 1));
            // Console.WriteLine("Število za 1 večje: " + (stevilo + 1));
            //
            //
            // // 2.3 Vsota posameznih števk
            // int enice = stevilo % 10;
            // int desetice = stevilo / 10 % 10;
            // int stotice = stevilo / 100 % 10;
            //
            // Console.WriteLine("Vsota števk je " + (enice + desetice + stotice));
            
            #endregion
            
            #region Vaja 3
            
            // Uporaba Math razreda za izračun energije .. Einstenova formula

            // int m = 72; //kg
            // int c = 300000000; // m/s
            // double E = Math.Round(m * (Math.Pow(3 * Math.Pow(10,8), 2)));
            //
            // Console.WriteLine("E = " + m + " * " + c + "² " + "= " + E);

            #endregion
            
            #region Vaje 4

            Random rnd = new Random();
            double st1 = Math.Round((rnd.NextDouble() * (11 - 5) + 5),5);
            double st2 = Math.Round((rnd.NextDouble() * (11 - 5) + 5),5);
            
            // hipotenuza
            double hipotenuza = Math.Round((Math.Sqrt(Math.Pow(st1, 2) * Math.Pow(st2, 2))),5);
            Console.WriteLine("Hipotenuza je " + hipotenuza );
            
            // kot
            
            
            // polmer včrtanega kroga

            double s = (st1 + st2 + hipotenuza) / 2; // 

            double ploscina = Math.Sqrt(s * (s - st1) * (s - st2) * (s - hipotenuza)); //Heronova formula za Ploščino
            Console.WriteLine(ploscina);
            
            double radijOcrtanega = ploscina / s; //radij za včrtani krog
            
            Console.WriteLine("Polmer včrtanega kroga je " + radijOcrtanega); 
            
            // polmer očrtanega kroga
            double radijVcrtanega = (st1 * st2 * hipotenuza) / ploscina; // radij  za očrtani krog

            Console.WriteLine("Polmer očrtanega kroga je " + radijVcrtanega);

            // ploščina
            Console.WriteLine("Ploščina trikotnika je " + ploscina); //uporabimo predhodno ustvarjeno formulo

            // višina na hipotenuzo

            // ali je enakokraki
            

            #endregion
            
            #region Vaja 5

            Random nak = new Random();

            int nakStevilo = nak.Next(10, 100); //st1 sem uporabil pri prejšni vaji, zato novo ime spremenljivke
            int prvaStevka = nakStevilo % 10;
            int drugaStevka = nakStevilo / 10 % 10;
            //
            Console.WriteLine(prvaStevka + "00" + drugaStevka);

            #endregion
            
            #region Vaje 6

            int staroStevilo = nakStevilo;
            //Console.WriteLine(staroStevilo);
            String tmp = Convert.ToString(prvaStevka + "" + drugaStevka); //spremenim v string ju združim in nato spet v int
            //Console.WriteLine(tmp);

            int obrnjenoStevilo = Convert.ToInt32(tmp);

            int transformiranoStevilo = (staroStevilo - obrnjenoStevilo);
            
            Console.WriteLine("Novo dobljeno število " + transformiranoStevilo + " je deljivo z 9");

            #endregion
            
            #region Vaje 7

            int stevilo1 = nak.Next(1, 3);
            
            Console.Write("Vnesite število: ");
            int stevilo2 = Int32.Parse(Console.ReadLine());
            
            Console.WriteLine("Število 1: " + stevilo1 + "\nŠtevilo 2: " + stevilo2);

            int tretjaPotenca = Math.Max(stevilo1, stevilo2);
            tretjaPotenca = tretjaPotenca * tretjaPotenca * tretjaPotenca;
            Console.WriteLine("Tretja potenca večjega števila je " + tretjaPotenca);

            #endregion
        }
    }
}