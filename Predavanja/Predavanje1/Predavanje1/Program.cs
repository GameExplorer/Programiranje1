// See https://aka.ms/new-console-template for more information

namespace Predavanje1
{
    class Program
    {
        static void Main(String[] args)
        {
            // IZPIS
            Console.Write("Danes je petek\n");
            Console.WriteLine("Jutri je sobota");
            
            // Backslash
            Console.WriteLine("Izpis \" narekovaja");
            Console.WriteLine("Izpis znaka\\");
            Console.WriteLine("Izpis dvojnega narekovaja\"C#\"");
            
            // Matematične operacije
            
            Console.WriteLine(14);
            Console.WriteLine(-14.892); //decimalno ločilo je PIKA!!
            Console.WriteLine(1 + 2);
            Console.WriteLine(1 + 2 * 3);
            Console.WriteLine(1.2 + 2.5);
            Console.WriteLine((1 + 2) * (3 + 4));


            //int stevilo = 38;
            int stevilo = Int32.Parse(Console.ReadLine());
            Console.WriteLine(stevilo);
            int enice = stevilo % 10;
            //Console.WriteLine(enice);
            int desetice = stevilo / 10;
            //Console.WriteLine(desetice);
            int novo_stevilo = enice * 10 + desetice;
            Console.WriteLine(novo_stevilo);

            int km = 712;
            double gorivo = 52.2;
            double poraba = gorivo / km * 100;
            Console.WriteLine("Poraba goriva na 100km je " + Math.Round(poraba,2));

            Console.Write("Vnesite ceno izdelka: ");
            double cena = Double.Parse(Console.ReadLine());
            double cena30 = Math.Round(cena * 1.3, 2);
            Console.WriteLine("30% podražitev cene: " + cena30);
            double cena25 = Math.Round(cena * 0.975,2); //Nova cena = 0.75 * 1.3x -> 0.975
            Console.WriteLine("25% pocenitev cene: " + cena25);
            
            // RANDOM

            Random rnd = new Random();
            int nakljStevilo = rnd.Next(500);
            
            // MATH
            Random nak = new Random();
            int x = nak.Next(100, 1000);
            int y = nak.Next(100, 1000);
            int z = nak.Next(100, 1000);

            double povprecje = (x + y + z) / 3.0;
            Console.WriteLine(Math.Round(povprecje,2));
        }
    }
}