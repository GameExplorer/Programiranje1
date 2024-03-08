
using System.Text.Json;

namespace Predavanje8
{
    class Oseba
    {
        public string Ime; //{ get; private set; }
        public string Priimek; //{ get; private set; }

        public Oseba() {}
        

        public string ToString()
        {
            return "Ime: " + Ime + ", Priimek: " + Priimek;
        }
    }
    
    class Program
    {
        public static void Main(String[] args)
        {
            //Inicializator s privzetim konstruktorjem
            Oseba o = new Oseba
            {
                Ime = "Miha",
                Priimek = "Čevljar",
            };


            
            
            Console.WriteLine(o.ToString());
            Console.WriteLine(JsonSerializer.Serialize(o));
            
            char[] tab = new char[] { 'a', 'b', 'c' };

            Modificiraj(tab);

            for (int i = 0; i < tab.Length; i++)
            {
                Console.WriteLine(tab[i]);
            }
            
            
        }

        public static void Modificiraj(char[] tab)
        {
            tab[0] = 'z';
        }
    }
}