namespace Kolokvij2018;

class Program
{
    class Ocala
    {
        public string proizvajalec;
        private double cena;
        public int kolicina;

        public Ocala()
        {
            proizvajalec = "Nedolocen";
            cena = -1;
            kolicina = -1;
        }

        public void NastaviCeno(double znesek)
        {
            this.cena = znesek;
        }
    }

    class Parcela
    {
        private double s;
        private double v;

        public Parcela(double s, double v)
        {
            this.s = s;
            this.v = v;
        }

        public double Velikost()
        {
            return 2 * s * v;
        }
    }
    
    
    static void Main(string[] args)
    {
        StreamWriter sw = File.CreateText("Podatki.txt");

        Console.Write("Vnesi stavek: ");
        string vnos = Console.ReadLine();
        sw.WriteLine(vnos);
        
        sw.WriteLine();

        sw.WriteLine(vnos.Length);

        sw.Close();

        Ocala o1 = new Ocala();

        o1.proizvajalec = "BOSS";
        
        o1.NastaviCeno(120);

        Console.Write("Vnesi kolicino: ");
        int kolicina = Int32.Parse(Console.ReadLine());
        o1.kolicina = kolicina;

        StreamReader beri = File.OpenText("Stavki.txt");
        StreamWriter pisi = File.CreateText("Stavki1.txt");
        string vrstica = beri.ReadLine();

        while (vrstica != null)
        {
            int index = vrstica[vrstica.Length - 1];
            if (index != '.')
            {
                pisi.WriteLine(vrstica.Insert(vrstica.Length, "."));
            }
            else
            {
                pisi.WriteLine(vrstica);
            }
            
            vrstica = beri.ReadLine();
        }
        
        beri.Close();
        pisi.Close();

        Parcela p1 = new Parcela(4, 5);
        Parcela p2 = new Parcela(12, 6);
        
        if(p1.Velikost() > p2.Velikost()) Console.WriteLine("Parcela p1 je večja od p2");
        else if(p2.Velikost() > p1.Velikost()) Console.WriteLine("Parcela p2 je večja od p1");
        else Console.WriteLine("Parceli sta enako veliki");

        Parcela[] parcele = new Parcela[100];

        for (int i = 0; i < parcele.Length; i++)
        {
            Random rnd = new Random();
            double nakS = rnd.Next(50, 101);
            double nakV = rnd.Next(50, 101);

            parcele[i] = new Parcela(nakS, nakV);
        }
        
        Datoteke("test");
    }

    public static void Datoteke(string imeDatoteke)
    {
        string novoIme = imeDatoteke + "kopija";
        if (File.Exists(imeDatoteke))
        {
            File.Copy(imeDatoteke, novoIme);
        }
        else
        {
            StreamWriter pisi = File.CreateText(novoIme);
            
            pisi.WriteLine("Kranj;" + DateTime.Now);
            for (int i = 0; i < novoIme.Length; i++)
            {
                pisi.Write(novoIme[i] + " ");
            }

            for (int i = 0; i <= 10; i++)
            {
                pisi.WriteLine();
            }
            pisi.WriteLine("KONEC DATOTEKE");
            pisi.Close();
        }
    }
}