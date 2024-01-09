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

            Random rnd = new Random(/*142*/); // inicilizacija s semenon (seed)
            
            Console.WriteLine(rnd.Next(10, 100));

            #endregion
        }
    }
}
