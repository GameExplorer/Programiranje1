

namespace Valute
{
    class Valuta
    {
        public string oznakaValute;
        public double tecaj;

        public Valuta(string oznakaValute, double tecaj)
        {
            this.oznakaValute = oznakaValute;
            this.tecaj = tecaj;
        }
    }
    class Program
    {
        public static void Main(String[] args)
        {
            Valuta v1 = new Valuta("EUR", 1.071);

            Valuta[] valute = Vnos();

            double najvecjiTecaj = 0;
            string najvecjaValuta = "";
            for (int i = 0; i < valute.Length; i++)
            {
                if (valute[i].tecaj > najvecjiTecaj)
                {
                    najvecjiTecaj = valute[i].tecaj;
                    najvecjaValuta = valute[i].oznakaValute;
                }   
            }
            
            Console.WriteLine("Največja valuta je {0} s tečajem {1}", najvecjaValuta, najvecjiTecaj);
        }

        public static Valuta[] Vnos()
        {
            Valuta[] valute = new Valuta[5];

            for (int i = 0; i < valute.Length; i++)
            {
                Console.Write("Vnesi valuto: ");
                string vnosValute = Console.ReadLine();

                Console.Write("Vnesi tečaj: ");
                double vnosTecaja = Double.Parse(Console.ReadLine());

                valute[i] = new Valuta(vnosValute, vnosTecaja);
            }

            return valute;
        }
    }
}