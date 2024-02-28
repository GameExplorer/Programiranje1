

using System.Globalization;

namespace KockaRazred
{
    class Kocka
    {
        public int a;

        public double Prostornina()
        {
            return Math.Pow(a, 3);
        }

        public double Povrsina()
        {
            return 6 * Math.Pow(a, 2);
        }

        public string Izpis()
        {
            return "Kocka: \nrob a = " + a + " \nProstornina = " + Prostornina() + " \nPovrsina = " + Povrsina();
        }
    }

    class KockaSKonstruktorjem
    {
        public int a;

        public KockaSKonstruktorjem(int a)
        {
            this.a = a;
        }

        public double Prostornina()
        {
            return Math.Pow(a, 3);
        }
    }
    class Program
    {
        public static void Main(String[] args)
        {
            //KOCKA BREZ KONSTRUKTORJA
            Console.Write("Vnesi stranico a: ");
            int vnos = Int32.Parse(Console.ReadLine());

            Kocka kocka = new Kocka();

            kocka.a = vnos;

            Console.WriteLine(kocka.Izpis());
            
            //KOCKA S KONSTRUKTORJEM

            Random rnd = new Random();
            
            KockaSKonstruktorjem k1 = new KockaSKonstruktorjem(5);
            KockaSKonstruktorjem k2 = new KockaSKonstruktorjem(rnd.Next(1, 51));
            
            
            if(k1.Prostornina() > k2.Prostornina()) Console.WriteLine("Kocka k1 ({0}) je večja od kocke k2 ({1})", k1.Prostornina(), k2.Prostornina());
            else Console.WriteLine("Kocka k2 ({0}) je večja od kocke k1 ({1})", k2.Prostornina(), k1.Prostornina());
        }
    }
}