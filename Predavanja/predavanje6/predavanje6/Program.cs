// See https://aka.ms/new-console-template for more information

namespace predavanje6
{
    class Program
    {

        /**
         * Metoda, ki prejme 2 števili in izpiše vsa števila vmes
         */
        public static void Izpis(int a, int b)
        {
            for (int i = a; i <= b; i++)
            {
                Console.WriteLine(i);
            }
        }

        // metoda prejme tabelo in vrne vsoto v tabeli
        public static int Sestej(int[] tabela)
        {
            int vsota = 0;

            for (int i = 0; i < tabela.Length; i++)
            {
                vsota += tabela[i];
            }

            return vsota;
        }
        
        //metoda prejme niz in vrne prvi znak ki se dvakrat zaporedoma ponovi
        public static char PonovljenZnak(string stavek)
        {
            char trenutniZnak = stavek[0];
            int stevec = 0;

            for (int i = 1; i < stavek.Length; i++)
            {
                if (stavek[i] == trenutniZnak)
                {
                    stevec++;
                    
                    if (stevec == 2)
                    {
                        break;
                    }
                }
                else
                {
                    trenutniZnak = stavek[i];
                }
            }

            return trenutniZnak;

        }

        public static char PonovljenZnak2(string stavek)
        {
            for (int i = 1; i < stavek.Length; i++)
            {
                if (stavek[i - 1] == stavek[i])
                {
                    return stavek[i];
                }
            }

            throw new Exception("Ta niz ne vsebuje podvojenih znakov");
        }
        
        public static void Main(String[] args)
        {
           Izpis(6,10);

           int[] tabela = new int[] { 1, 2, 3 };
           int rezultat = Sestej(tabela);
           Console.WriteLine("Rezultat je {0}", rezultat);

           char rez = PonovljenZnak("Monoliith  ");
           Console.WriteLine(rez);
           
           // VAROVALNI BLOK


           try
           {
               Console.Write("Vnesi a: ");
               int a = Int32.Parse(Console.ReadLine());

               Console.Write("Vnesi b: ");
               int b = Int32.Parse(Console.ReadLine());

               Console.WriteLine(a / b);

           }
           catch (Exception e)
           {
               //Console.WriteLine("Napaka: " + e);

               if (e is DivideByZeroException)
               {
                   Console.WriteLine("Deljenje z 0");    

               }

               if (e is FormatException)
               {
                   Console.WriteLine("Nisi vnesel število");
               }
               //Console.WriteLine(e.StackTrace);
           }
           finally
           {
               Console.WriteLine("Vedno se izvedem!");
           }

           /*
           for (;;)
           {
               Console.WriteLine("Vnesi besedo!");
               Console.Write("> ");
               string vnos = Console.ReadLine();
               char rez2 = ' ';

               try
               {
                   Console.WriteLine("Ponovljen znak: {0}", PonovljenZnak2(vnos));
               }
               catch(Exception e)
               {
                   Console.WriteLine("Prazen niz ali se noben znak ne ponovi dvakrat");
               }
               Console.WriteLine();
           }
            */
           
        }
    }
}