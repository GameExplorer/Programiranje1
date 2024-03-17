

namespace Kolokvij12
{
    class Reka
    {
        private double dolzina;
        private string ime;

        public Reka()
        {
            this.dolzina = -1;
            this.ime = "Nedoločeno";
        }
        public Reka(double dolzina, string ime)
        {
            this.dolzina = dolzina;
            this.ime = ime;
        }

        public string Izpis()
        {
            return "Ime reke: " + ime + ", dolzina reke: " + dolzina;
        }
        
        public static void PrimerjavaRek(Reka r1, Reka r2)
        {
            if (r1.dolzina > r2.dolzina)
            {
                Console.WriteLine("Reka " + r1.ime + " je daljša od " + r2.ime);
            }
            else if(r2.dolzina < r1.dolzina)
            {
                Console.WriteLine("Reka " +  r2.ime + " je daljša od " + r1.ime);
            }
            else
            {
                Console.WriteLine("Reki " + r1.ime + " " + r2.ime + " sta enako dolgi!");
            }
        }
        
    }
    class Program
    {
        public static void Main(String[] args)
        {
            Random rnd = new Random();
            StreamWriter sw = new StreamWriter("Loto.txt");

            for (int i = 0; i < 7; i++)
            {
                sw.Write(rnd.Next() + " ");
            }
            
            sw.Close();

            Reka r1 = new Reka(4000, "Sava");
            Console.WriteLine(r1.Izpis());
            Reka r2 = new Reka(3001, "Drava");
            Console.WriteLine(r2.Izpis());

            Reka.PrimerjavaRek(r1, r2);

            Reka[] reke = new Reka[100];

            //preberemo vsebino datoteke
            string vsebinaDatoteke = File.ReadAllText("Ocene.txt");
            
            //Razdelimo vsebino na ime študenta in ocene
            string[] deli = vsebinaDatoteke.Split(";");
            
            //izračun povprečja ocen
            double vsota = 0;

            for (int i = 1; i < deli.Length; i++)
            {
                vsota += Int32.Parse(deli[i]);
            }

            double povp = vsota / (deli.Length - 1);
            Console.WriteLine("Povprečna ocena je " + povp);


            string potDoDatoteke = @"C:\PRO1\Razdalja.txt";
            
            //Prepiši vsebino na zaslon
            IzpisiDatotekoNaZaslon(potDoDatoteke);

            //Poišče in izpiše ime najbolj oddaljenega mesta
            string najboljOddaljenoMesto = NajboljOddaljenKraj(potDoDatoteke);
            Console.WriteLine("Najbolj oddaljen kraj je " + najboljOddaljenoMesto);
        }

        public static void IzpisiDatotekoNaZaslon(string imeDatoteke)
        {
            string[] vrstice = File.ReadAllLines(imeDatoteke);

            foreach (string vrstica in vrstice)
            {
                Console.WriteLine(vrstica);
            }
        }

        public static string NajboljOddaljenKraj(string imeDatoteke)
        {
            string[] vrstice = File.ReadAllLines(imeDatoteke);
            string najdaljeOddaljenKraj = "";
            int najvecjaRazdalja = 0;

            foreach (string vrstica in vrstice)
            {
                string[] deli = vrstica.Split("|");
                string imeKraja = deli[0];
                int razdalja = Int32.Parse(deli[1]);

                if (razdalja > najvecjaRazdalja)
                {
                    najvecjaRazdalja = razdalja;
                    najdaljeOddaljenKraj = imeKraja;
                }
            }

            return najdaljeOddaljenKraj;
        }

        
    }
}