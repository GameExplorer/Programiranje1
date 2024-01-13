// See https://aka.ms/new-console-template for more information

namespace Vaje1
{
    class Vaje1
    {
        static void Main(String[] args)
        {
            #region Vaja 2
            // Napišite program, ki bo izpisal naslednje vrstice (vsa števila izpisujte kot števila,
            // (npr. Console.WriteLine("Število "+11);) in jih ne vpisujte kot znake). Namesto xxxxx napišite
            // ustrezno število, ki naj ga program »izračuna«):
            
            Console.WriteLine("Dne 3/12/1800 je bil rojen \"dr\" France Prešern");
            Console.WriteLine("Od takrat je minilo že " + (2024 - 1800));
            
            #endregion
            
            #region Vaja 3
            Console.WriteLine(9 + 1 * 6 + 2);                      // 17t:
            Console.WriteLine((9 + 1) * 6 + 2);                    // 62:
            Console.WriteLine(9 + 1 * 6 + 2);                      // 17:
            //Console.WriteLine("9 + 1" * 6 + 2);                   //Napaka po nizu manjka + :
            Console.WriteLine("9 + 1" + 6 + 2);                  // 9 + 18 amapak v resnici je vse niz:
            Console.WriteLine("9 + 1" + (6 + 2));                // 9 + 18:
            Console.WriteLine("9 + \n1 + 6 + \n2");           // 9 + [nova vrstica] 1 + 6 + [nova vrstica] 2:
            Console.WriteLine(5 % 3 + 6 / 2);                      // 5:
            Console.WriteLine(10 % (3 + 6) / 2);                  // 0:
            Console.WriteLine((5 % 3 + 6) / 2);                    // 4 če zaokroži navzgor:
            Console.WriteLine(5 % (3 + 6 / 2));                    // 5:
            Console.WriteLine( "PRO1" + " - " + "Vaje");      // PRO1  - Vaje:
            #endregion
            
            #region Vaje 4
            Console.WriteLine(3456 / 77 - (3456 % 77));
            
            Console.WriteLine("Danes\nje\nlep\ndan");
            Console.Write("Danes" + " je" + " lep" + " dan");
            Console.WriteLine(); //za naslednjo
            #endregion
            
            #region Vaje 5
            Console.WriteLine((4 * 2 + 6) / 2 - 4); //pa res
            Console.WriteLine(((15 - 1) * 3 + 12) / 3 + 5 - 15); // dela če prebereš navodilo do konca
            Console.WriteLine((10 * 3 + 45) * 2 / 6 - 10); //čarovnija
            #endregion
        }
    }
}