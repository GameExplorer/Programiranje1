namespace Kolokvij2015;

class Program
{
    class Motor
    {
        public static int st = 1;
        private int prestave;

        public int VrniPrestavo()
        {
            return 5;
        }

        public static string ImeObjekta()
        {
            return "stavek";
        }
        
        private void Karakteristike() {}
    }

    class Prijatelj
    {
        public string ime;
        public string priimek;
        private string telefonskaStevilka;

        public Prijatelj()
        {
            this.ime = "NI PODATKOV";
            this.priimek = "NI PODATKOV";
            this.telefonskaStevilka = "NI PODATKOV";
        }

        public string SetTelefonska(string telefonskaStevilka)
        {
            return telefonskaStevilka;
        }
        
    }

    class Kovanec
    {
        private int r;
        private int v;

        public Kovanec()
        {
        }

        public Kovanec(int r, int v)
        {
            this.r = r;
            this.v = v;
        }

        public int SetR(int r)
        {
            return r;
        }

        public int SetV(int v)
        {
            if(v < 1 || v > 10) Console.WriteLine("Visina ni smiselna");
            return v;
        }
        
        public double Volumen()
        {
            return (4 / 3) * Math.PI * Math.Pow(r, 3);
        }

        public double Povrsina()
        {
            return Math.PI * Math.Pow(r, 2);
        }
    }
    static void Main(string[] args)
    {
        Motor Mercedes = new Motor();

        int s = Mercedes.VrniPrestavo();

        // Mercedes.st = 15; ne moremo dostopati do statičnega polja
        //Console.WriteLine(Mercedes.ImeObjekta()); //ne moremo dostopati do statične metode znotraj ne-statičnega konteksta

        StreamWriter sw = File.CreateText("Stevila.txt");
        Random rnd = new Random();
        int n = rnd.Next(1, 11);

        for (int i = 1; i < 6; i++)
        {
            sw.WriteLine(n * i);
        }

        sw.Close();

        Prijatelj p1 = new Prijatelj();
        p1.ime = "Fernando";
        p1.priimek = "Alonso";

        Prijatelj p2 = new Prijatelj();
        p2.ime = "Max";
        p2.priimek = "Verstappen";
        
        Console.WriteLine(p1.ime + " " + p1.priimek + " " + p1.SetTelefonska("15142412"));
        Console.WriteLine(p2.ime + " " + p2.priimek + " " + p2.SetTelefonska("1241512"));

        StreamReader beri = File.OpenText("Podatki.txt");
        string vrstica = beri.ReadLine();

        double vsota = 0;

        while (vrstica != null)
        {
            string[] deli = vrstica.Split(' ');

            //Za vsak del
            foreach (string del in deli)
            {
                //Poskusi pretvoriti del v niz
                double stevilo;
                if (double.TryParse(del, out stevilo))
                {
                    //Če je pretvorba uspesna dodaj stevilo k vsoti
                    vsota += stevilo;
                }
            }
            
            //Preberi naslednjo vrstico
            vrstica = beri.ReadLine();
        }

        Console.WriteLine("Vsota števil v datoteki je " + vsota);
        beri.Close();


        Kovanec[] kovanci = new Kovanec[100];

        //Ustvarimo tabelo 100 kovancev
        for (int i = 0; i < kovanci.Length; i++)
        {
            int polmer = rnd.Next(1, 11);
            int visina = rnd.Next(1, 11);

            kovanci[i] = new Kovanec(polmer, visina);
        }

        //Poiščemo kovanec z največjo povrsino
        double najvecjaPovrsina = 0;

        for (int i = 0; i < 100; i++)
        {
            double povrsina = kovanci[i].Povrsina();

            if (najvecjaPovrsina < povrsina)
            {
                najvecjaPovrsina = povrsina;
            }
        }
        Console.WriteLine("Največja povrsina je " + najvecjaPovrsina);

        Datoteka("Stevke");
    }

    public static void Datoteka(string imeDatoteke)
    {
        if (File.Exists(imeDatoteke)) File.AppendText(imeDatoteke + "Kopija");
        else
        {
            StreamWriter sw = File.CreateText(imeDatoteke);
            DateTime datum = new DateTime(2024, 3, 17);
            sw.WriteLine($"Lewis Hamitlon {datum}");
            sw.WriteLine();

            for (int i = 0; i < 100; i++)
            {
                if (i % 2 == 0)
                {
                    if (i % 3 == 0 && i % 5 != 0)
                    {
                        sw.WriteLine(i + " ");
                    }
                }
            }
            
            sw.Close();
        }
    }
}