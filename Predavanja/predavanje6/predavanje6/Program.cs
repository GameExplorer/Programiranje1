// See https://aka.ms/new-console-template for more information

using System.Net;
using System.Security.Authentication;

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
            Izpis(6, 10);

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

                if (e is DivideByZeroException)
                {
                    Console.WriteLine("Deljenje z 0!");
                }

                if (e is FormatException) //Napaka pre pretvajrnaju v drug podatkovni tip
                {
                    Console.WriteLine("Nisi vnesel število");
                }
                //Console.WriteLine(e.StackTrace);

                //Console.WriteLine("Napaka: " + e);
            }
            finally
            {
                Console.WriteLine("Vedno se izvedem!");
            }

            //Košarkaška žoga (idealno napihnjena) pri vsakem odboju od (idealnih) tal izgubi nekaj energije in
            //zato pride le do 90% višine, iz katere je bila vržena na tla. Napiši metodo, ki izračuna, kolikšno pot prepotuje žoga,
            //ki jo vržemo iz poljubne višine, preden so njeni poskoki manjši od 1 centimetra?
            
            
            double m;
            while (true)
            {
                try
                {
                    Console.Write("Vnesi višino v metrih: ");
                    m = Double.Parse(Console.ReadLine());

                    if (m <= 0)
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                catch

                {
                    Console.WriteLine("Vnesi pozitivno višino!");
                }
            }

            double mIzpis = m;
            int stevecOdbojov = 0;
            double vsotaPoti = 0;

            while (m > 0.01)
            {
                vsotaPoti = m + vsotaPoti; //pred odbojem
                m *= 0.9;
                vsotaPoti = m + vsotaPoti; //po odboju
                stevecOdbojov++;
            }
            
            Console.WriteLine("Žogo smo vrgli z {0} metrov višine in se je odbila {1} krat pri tem pa smo naredili " +
                              "{2} m poti", mIzpis, stevecOdbojov, vsotaPoti);
            
            Console.Write("Vnesi decimalno število: ");
            double st = 25;
        
           try
           {
               st = Convert.ToDouble(Console.ReadLine());
           }
           catch
           {
               Console.WriteLine("Napačen vnos števila, vrednost ostane privzeta");
           }
           finally
           {
               Console.WriteLine("Število = {0}", st);
           }
           
           Console.Write("Vnesi niz: ");
           string niz = Console.ReadLine();

           try
           {
               Console.Write("Kateri znak te zanima (indeks): ");
               int index = Int32.Parse(Console.ReadLine());

               Console.WriteLine("{0} .ti znak v {1} je {2}", index, niz, niz[index - 1]);
           }
           catch (Exception e)
           {
               Console.WriteLine("Napaka: " + e);
           }
           
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
           
        }
    }
}