

namespace Drzave
{
    class Drzava
    {
        public string imeDrzave;
        public string[] najvecjaMesta;

        public Drzava(string imeDrzave)
        {
            this.imeDrzave = imeDrzave;
            najvecjaMesta = new string[10];

            for (int i = 0; i < najvecjaMesta.Length; i++)
            {
                najvecjaMesta[i] = "NEDOLOČENO";
            }
        }

        public void Izpis()
        {
            Console.Write("Največja mesta so: ");
            for (int i = 0; i < 10; i++)
            {
                if (najvecjaMesta[i] != "NEDOLOČENO")
                {
                    Console.Write(najvecjaMesta[i] + ", ");
                }
            }

            Console.WriteLine();
        }
    }
    class Program
    {
        public static void Main(String[] args)
        {
            Console.Write("Vnesi ime države: ");
            string vnosDrzave = Console.ReadLine();
            Drzava d1 = new Drzava(vnosDrzave);
            
            Console.Write("Vnesi ime države: ");
            string vnosDrzave2 = Console.ReadLine();
            Drzava d2 = new Drzava(vnosDrzave2);

            Console.WriteLine("Vnesi 10 največjih mest v {0}", d1.imeDrzave);
            
            for (int i = 0; i < d1.najvecjaMesta.Length; i++)
            {
                Console.Write("Vnos {0}: ", i+1);
                string vnos = Console.ReadLine();

                if (vnos == "") break;

                d1.najvecjaMesta[i] = vnos;
            }
            
            Console.WriteLine("Vnesi 10 največjih mest v {0}", d2.imeDrzave);
            
            for (int i = 0; i < d2.najvecjaMesta.Length; i++)
            {
                Console.Write("Vnos {0}: ", i+1);
                string vnos = Console.ReadLine();
                
                if (vnos == "") break;

                d2.najvecjaMesta[i] = vnos;
            }

            Console.Clear();
            
            d1.Izpis();
            d2.Izpis();

        }
    }
}