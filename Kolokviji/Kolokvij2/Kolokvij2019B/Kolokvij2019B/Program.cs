namespace Kolokvij2019B;

class Program
{
    class Izpit
    {
        public string student;
        private int ocena;

        public string Izpis()
        {
            return "A";
        }
    }

    class Telefon
    {
        private int dolzina, sirina;
        private string proizvajalec;

        public Telefon(int dolzina, int sirina, string proizvajalec)
        {
            this.dolzina = dolzina;
            this.sirina = sirina;
            this.proizvajalec = proizvajalec;
        }
    }

    class Student
    {
        private string student;
        private int[] ocene;

        public Student(string student, int[] ocene)
        {
            if (student.Length > 0) this.student = student;
            else student = "Nedoločeno";
            
            // Preveri, ali je dolžina tabele ocen enaka 10
            if (ocene.Length == 10)
            {
                // Preveri vsako oceno in jo omeji na območje med 5 in 10
                for (int i = 0; i < ocene.Length; i++)
                {
                    if (ocene[i] < 5)
                    {
                        this.ocene[i] = 5;
                    }
                    else if (ocene[i] > 10)
                    {
                        this.ocene[i] = 10;
                    }
                    else
                    {
                        this.ocene[i] = ocene[i];
                    }
                }
            }
            else
            {
                // Če dolžina tabele ocen ni enaka 10, ustvari novo tabelo z ustrezno dolžino in nastavi privzete vrednosti na 5
                this.ocene = new int[10];
                for (int i = 0; i < this.ocene.Length; i++)
                {
                    this.ocene[i] = 5;
                }
            }
        }

        public double Povprecje()
        {
            int vsota = 0;
            for (int i = 0; i < ocene.Length; i++)
            {
                vsota += ocene[i];
            }

            return (double)vsota / ocene.Length;
        }
    }
    
    static void Main(string[] args)
    {
        Izpit I1 = new Izpit();

        Student S1 = new Student("Janez", new int[] { 5, 6, 7, 8, 9, 10, 8, 6, 5,4 });

        Console.WriteLine(I1.student);
        string st = I1.Izpis();

        Telefon T1 = new Telefon(7, 11, "Samsung");

        StreamReader beri = File.OpenText("Telefoni.txt");
        string vrstica = beri.ReadLine();

        double maxCena = 0;
        string imeMaxCena = "";

        while (vrstica != null)
        {
            string[] podatki = vrstica.Split(";");
            Console.WriteLine("Oznaka: " + podatki[0] + " Cena: " + podatki[1]);

            double trenutnaCena = Double.Parse(podatki[1]);

            if (maxCena < trenutnaCena)
            {
                maxCena = trenutnaCena;
                imeMaxCena = podatki[0];
            }

            vrstica = beri.ReadLine();
        }

        Console.WriteLine("Najdrazji telefon je " + imeMaxCena + " cena telefona je " + maxCena);

        beri.Close();

        Dodaj("Iphone 14", 1100);
    }

    public static void Dodaj(string oznaka, double cena)
    {
        StreamWriter pisi = File.AppendText("Telefoni.txt");

        pisi.WriteLine(oznaka + ";" + cena);

        pisi.Close();
    }
}