

namespace RazredDirectoryOsnove
{
    class Program
    {
        public static void Main(String[] args)
        {
            string dir = @"Direktorij";
            //Preverimo če imenik obstaja

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            
            //Imena vseh datotek shranimo v tabelo datoteke
            string[] datoteke = Directory.GetFiles(dir);
            Console.WriteLine("Seznam datotek imenika Direktorij:");

            foreach (string imeDatoteke in datoteke)
                Console.WriteLine(imeDatoteke);

            try
            {
                Directory.Delete(dir);
                Console.WriteLine("Mapa uspešno izbrisana!");
            }
            catch
            {
                Console.WriteLine("Brisanje neuspešno, ker mapa vsebuje datoteke");
            }

            DateTime datum = Directory.GetCreationTime(@"C:\Program Files");
            Console.WriteLine(@"Mapa je bila kreirana " + datum);
            
            //Ugotovimo katere podmape vsebuje Program Files
            string direktorij = @"C:\Program Files";
            string[] mape = Directory.GetDirectories(direktorij);

            foreach (string ime in mape)
            {
                Console.WriteLine(ime + " " + Directory.GetCreationTime(ime));
            }

            string pot = Directory.GetDirectoryRoot("TestniDirektorij1");
            Console.WriteLine(pot);

            string pot1 = Directory.GetCurrentDirectory();
            Console.WriteLine(pot1);
            
            Console.WriteLine("Mapa '" + direktorij + "' se nahaja na disku " + Directory.GetDirectoryRoot(@"c:\Program Files"));
            
            Console.WriteLine(@"V mapi C:\Program Files je " + Directory.GetFiles(direktorij).Length +  " datoteke");
            Console.WriteLine(@"V mapi C:\Program Files je " + Directory.GetDirectories(direktorij).Length + " podmap");
            
        }
    }
}