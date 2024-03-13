

namespace Vaje10
{
    class Program
    {
        public static void Main(String[] args)
        {
            //1. Naloga
            
            
            //2. Naloga
            string trenutniDirektorij = Directory.GetCurrentDirectory();
            string[] datoteke = Directory.GetFiles(trenutniDirektorij);

            foreach (string dat in datoteke)
            {
                Console.WriteLine(dat + " " + Directory.GetCreationTime(dat));
            }

        }
    }
}