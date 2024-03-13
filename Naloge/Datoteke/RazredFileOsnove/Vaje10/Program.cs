

namespace Vaje10
{
    class Avto
    {
        public string Znamka { get; set; }
        public string Tip { get; set; }
        public int Letnik { get; set; }
        public double stPrevozenihKilometrov { get; set; }

        public Avto(string Znamka, string Tip, int Letnik, double stPrevozenihKilometrov)
        {
            this.Znamka = Znamka;
            this.Tip = Tip;
            this.Letnik = Letnik;
            this.stPrevozenihKilometrov = stPrevozenihKilometrov;
        }
    }

    class AvtoDatoteka
    {
        
    }
    class Program
    {
        public static void Main(String[] args)
        {
            //1. Naloga
            args = new[] { "" };
            string mapa = args[0];

            if (mapa.Length > 0  && !mapa.Contains('#') && !mapa.Contains('&') &&
                !mapa.Contains('$'))
            {
                if (Directory.Exists(mapa)) Console.WriteLine("Mapa s tem imenom že obstaja");
                else
                {
                    try
                    {
                        Directory.CreateDirectory(mapa);
                        Console.WriteLine("Mapa je ustvarjena");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Napaka pri ustvarjanju mape: " + e.Message);
                    }
                }
            }
            else
            {
                Console.WriteLine("Neustrezno ime mape. Ime mape ne sme biti prazno in ne sme vsebovati #$&!");
            }
            
            
            //2. Naloga
            string trenutniDirektorij = Directory.GetCurrentDirectory();
            string[] datoteke = Directory.GetFiles(trenutniDirektorij);

            foreach (string dat in datoteke)
            {
                Console.WriteLine(dat + " " + Directory.GetCreationTime(dat));
            }

            //3. Naloga
            
        }
    }
}