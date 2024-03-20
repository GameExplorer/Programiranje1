namespace Kolokvij2020B;

class Program
{
    class Ulomek
    {
        public static int st = 1;
        private int stevec, imenovalec;

        public double Pretvorba()
        {
            return 0;
        }

        public static string OpisUlomka()
        {
            return "";
        }
        
        private void Krajšaj() {}
    }

    public class Avto
    {
        public string znamka;
        public string tip;
        private double cena;

        public Avto(string znamka, string tip, double cena)
        {
            this.znamka = znamka;
            this.tip = tip;
            this.cena = cena;
        }
    }

    class MotoGP
    {
        public string motor;
        public string drzava;
        private int tocke;

        public MotoGP(string motor, string drzava, int tocke)
        {
            this.motor = motor;
            this.drzava = drzava;
            if(tocke > 0) this.tocke = tocke;
            else Console.WriteLine("Točke ne morejo biti negativne");
        }

        public double SpremeniTocke()
        {
            if (tocke > 0) return tocke;
            else return 0;
        }
    }
    
    static void Main(string[] args)
    {
        Ulomek U1 = new Ulomek();

        Avto A1 = new Avto("Citroen", "C3", 9900);

        Datoteka("Avto.txt");

        MotoGP[] motorji = new MotoGP[20];

        for (int i = 0; i < motorji.Length; i++)
        {
            string vnos = Console.ReadLine();
            string vnos2 = Console.ReadLine();
            int tocke = Int32.Parse(Console.ReadLine());

            motorji[i] = new MotoGP(vnos, vnos2, tocke);
        }

    }

    public static void Datoteka(string imeDatoteke)
    {
        if (File.Exists(imeDatoteke))
        {
            Console.WriteLine("Datoteka že obstaja");
        }
        else
        {
            StreamWriter pisi = File.CreateText(imeDatoteke);

            pisi.WriteLine("Cenik rabljenih avtomobilov: ");

            for (int i = 0; i < 80; i++)
            {
                pisi.Write("*");
            }
            
            Console.Write("Vnesi znamko avtomobila: ");
            string vnos = Console.ReadLine();
            
            Console.Write("Vnesi tip avtomobila: ");
            string vnos1 = Console.ReadLine();

            Console.Write("Vnesi ceno: ");
            string vnos2 = Console.ReadLine();
            
            pisi.WriteLine(vnos + " " + vnos1 + " " + vnos2);

            pisi.Close();

            StreamReader beri = File.OpenText(imeDatoteke);

            string vrstica = beri.ReadLine();
            string tip = "";
            string cena = "";
            
            while (vrstica != null)
            {
                string[] podatki = vrstica.Split(" ");

                tip = podatki[1];
                cena = podatki[2];
                
                vrstica = beri.ReadLine();
            }

            Console.WriteLine("RABLJENO VOZILO");
            Console.WriteLine("TIp: " + tip);
            Console.WriteLine("Cena: " + cena);

            beri.Close();
        }
    }
}