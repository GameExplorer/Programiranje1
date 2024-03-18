
namespace Kolokvij2017
{
    class Zelva
    {
        public static int stevilo = 10;
        string ime;

        private int VrniStarost()
        {
            return 2;
        }

        public static string imeObjekta()
        {
            return "a";
        }

        public void Nahrani()
        {
        }

    }

    class Zelenjava
    {
        public string ime;
        private double znesek;
        public int kolicina;

        public Zelenjava()
        {
            ime = "Nedoločeno";
            znesek = 0;
            kolicina = 0;
        }

        public void NastaviZnesek(double znesek)
        {
            this.znesek = znesek;
        }
    }

    class Okno
    {
        private double s;
        private double v;

        public Okno(double s, double v)
        {
            this.s = s;
            this.v = v;
        }

        public double Kvadratura()
        {
            return s * v;
        }
    }
    class Program
    {
        public static void Main(String[] args)
        {
            Zelva Kira = new Zelva();

            StreamWriter pisi = File.CreateText("Podatki.txt");
            pisi.WriteLine();
            pisi.WriteLine("4000 Kranj");
            pisi.Close();

            Zelenjava Z1 = new Zelenjava();

            Z1.ime = "Pesa";
            
            Console.Write("Vnesi znesek: ");
            double znesek = Double.Parse(Console.ReadLine());
            Z1.NastaviZnesek(znesek);

            Console.Write("Vnesi kolicino: ");
            Z1.kolicina = Int32.Parse(Console.ReadLine());

            StreamReader beri = File.OpenText("Imena.txt");
            StreamWriter sw = File.CreateText("Imena2.txt");

            string vrstica = beri.ReadLine();
            string novZapis = "";
            while (vrstica != null)
            {
                if (vrstica.Contains(','))
                {
                    novZapis = vrstica.Replace(',', ';');
                    sw.WriteLine(novZapis);
                }

                vrstica = beri.ReadLine();
            }
            
            beri.Close();
            sw.Close();

            Random rnd = new Random();

            Okno O1 = new Okno(rnd.Next(1, 11), rnd.Next(1, 11));
            Okno O2 = new Okno(rnd.Next(1, 11), rnd.Next(1, 11));

            if (O1.Kvadratura() > O2.Kvadratura())
            {
                Console.WriteLine("Okno 1 ima večjo kvadraturo kot okno 2");
            }
            else if (O2.Kvadratura() > O1.Kvadratura())
            {
                Console.WriteLine("Okno 2 ima večjo kvadraturo kot okno 1");
            }
            else
            {
                Console.WriteLine("Okni imata enako kvadraturo");
            }

            Okno[] okna = new Okno[100];

            for (int i = 0; i < okna.Length; i++)
            {
                double nakS = rnd.Next(10, 26);
                double nakV = rnd.Next(10, 26);
                okna[i] = new Okno(nakS, nakV);
            }
            
            Datoteka("test.txt");
        }

        public static void Datoteka(string imeDatoteke)
        {
            if (File.Exists(imeDatoteke)) Console.WriteLine("Datoteka s tem imenom že obstaja!");
            else
            {
                StreamWriter sw = File.CreateText(imeDatoteke);

                for (int i = 1; i < 12; i++)
                {
                    sw.WriteLine(5 * i);
                }
                sw.WriteLine(imeDatoteke + ".dat");

                for (int i = 0; i < imeDatoteke.Length; i++)
                {
                    if (imeDatoteke[i] != '.')
                    {
                        sw.WriteLine(imeDatoteke[i]);
                    }
                    else
                    {
                        break;
                    }
                }
                
                sw.Close();
            }
        }
    }
}