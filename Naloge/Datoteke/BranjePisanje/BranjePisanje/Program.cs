

namespace BranjePisanje
{
    class Program
    {
        public static void Main(String[] args)
        {
            OsebniPodatki();
            DatotekaNakStevil();
            BranjePodatkov();
            BranjeZnakov();
            KopijaDatoteke();
            KopijaDatotekePoZnakih();
            BranjeNakStevil();
            MetKocke();
            Kraji();
            Zneski();
            Stevila();
            PovprecnaVrednostStevil();
            Manekenke();
        }

        public static void OsebniPodatki()
        {

            string dat = "Naslov.txt";

            if (File.Exists(dat)) Console.WriteLine("Datoteka s tem imenom že obstaja!");
            else
            {
                StreamWriter sw = File.CreateText(dat);
                sw.WriteLine("Ivan Cankar");
                sw.WriteLine("Cankarjeva 5");

                for (int i = 0; i <= 50; i += 2)
                {
                    sw.Write(i + " ");
                }

                Console.WriteLine("Datoteka uspešno ustvarjan in zapisana");
                
                sw.Close();

            }
        }

        public static void DatotekaNakStevil()
        {
            Random rnd = new Random();
            string dat = "NakljucnaStevila.txt";

            int n = rnd.Next(1, 11);
            

            if (File.Exists(dat)) Console.WriteLine("Datoteka s tem imenom že obstaja!");
            else
            {
                StreamWriter sw = File.CreateText(dat);

                for (int i = 0; i < n; i++)
                {
                    sw.WriteLine(rnd.Next(1, 100));
                }

                Console.WriteLine("Datoteka uspešno ustvarjena");
                sw.Close();
            }
            
        }

        public static void BranjePodatkov()
        {
            string vsebinaDatoteke = File.ReadAllText("Student.txt");

            string[] deli = vsebinaDatoteke.Split(";");

            double vsota = 0;
            double povp = 0;

            string ime = "";

            for (int i = 1; i < deli.Length; i++)
            {
                vsota += Int32.Parse(deli[i]);
                ime = deli[0];
            }

            povp = vsota / (deli.Length - 1);
            Console.WriteLine("Student " + ime + " ima povprečno oceno " + povp );
        }

        public static void BranjeZnakov()
        {
            StreamReader sr = File.OpenText("Student.txt");
            int beri = sr.Read();

            while (beri != -1)
            {
                Console.WriteLine((char)beri);
                beri = sr.Read();
            }
            
            sr.Close();
        }

        public static void KopijaDatoteke()
        {
            StreamReader beri = File.OpenText("Naslov.txt");
            StreamWriter pisi = File.CreateText("Naslov2.txt");

            string vrstica = beri.ReadLine();
            while (vrstica != null)
            {
                Console.WriteLine(vrstica);
                pisi.WriteLine(vrstica); //zapiši v novo datoteko
                vrstica = beri.ReadLine(); //preberi novo vrstico
            }

            beri.Close();
            pisi.Close();
        }

        public static void KopijaDatotekePoZnakih()
        {
            StreamReader beri = File.OpenText("Student.txt");
            StreamWriter pisi = File.CreateText("Student2.txt");
            
            int prebranZnak = beri.Read();

            while (prebranZnak != -1)
            {
                pisi.Write((char)prebranZnak);
                prebranZnak = beri.Read();
            }

            beri.Close();
            pisi.Close();
        }

        public static void BranjeNakStevil()
        {
            StreamReader sr = File.OpenText("NakljucnaStevila.txt");
            string imeDat = "NakljucnaStevila.txt";
            string vrstica = sr.ReadLine();
            int vsota = 0;

            while (vrstica != null)
            {
                Console.WriteLine(vrstica);
                vsota += Int32.Parse(vrstica);
                vrstica = sr.ReadLine();
            }

            Console.WriteLine("Vsota v datoteki " + imeDat + " je " + vsota);
        }

        public static void MetKocke()
        {
            StreamWriter pisi = File.CreateText("Kocka.txt");

            Random rnd = new Random();

            for (int i = 1; i < 1001; i++)
            {
                pisi.WriteLine(i + ". met: " + rnd.Next(1,7));
            }

            pisi.Close();

            StreamReader beri = File.OpenText("Kocka.txt");
            string vrstica = beri.ReadLine();
            string[] deli = vrstica.Split(":");
            double vsota = 0;
            double povp = 0;
            int stVrstic = 0;
            
            while (vrstica != null)
            {
                //Console.WriteLine(vrstica);
                vsota += Int32.Parse(deli[1]);
                stVrstic++;
                vrstica = beri.ReadLine();
            }

            povp = vsota / stVrstic;
            Console.WriteLine("Povprečni met kocke je " + povp);
            beri.Close();
        }

        public static void Kraji()
        {
            StreamReader sr = File.OpenText("Kraji.txt");
            StreamWriter sw = File.CreateText("Kraji2.txt");
            string vrstica = sr.ReadLine();
          

            int vsotaPreb = 0;
            string najvecjiKraj = "";
            int najvecPreb = 0;
            
            while (vrstica != null)
            {
                string[] deli = vrstica.Split(";");
                int trenutnoPreb = Int32.Parse(deli[2]);
                vsotaPreb += Int32.Parse(deli[2]);
                if (najvecPreb < trenutnoPreb)
                {
                    najvecPreb = trenutnoPreb;
                    najvecjiKraj = deli[0];
                }
                
                sw.WriteLine(deli[0] + " - " + deli[1]);

                vrstica = sr.ReadLine();
            }

            sw.WriteLine(vsotaPreb);
            
            Console.WriteLine("Največji kraj je " + najvecjiKraj + " s " + najvecPreb + " prebivalci");
            
            sr.Close();
            sw.Close();
        }

        public static void Zneski()
        {
            Random rnd = new Random();
            int stZapisov = rnd.Next(100, 201);

            string vsebinaDatoteke = "";

            for (int i = 0; i < stZapisov; i++)
            {
                vsebinaDatoteke += rnd.NextDouble() * 100 + "\n";
            }
            
            File.WriteAllText("Zneski.txt", vsebinaDatoteke);

            string[] tabZneskov = new string[stZapisov];

            for (int i = 0; i < tabZneskov.Length; i++)
            {
                tabZneskov[i] = (rnd.NextDouble() * 100).ToString();
            }
            
            File.WriteAllLines("Zneski1.txt", tabZneskov);
            string[] tabStevil = File.ReadAllLines("Zneski.txt");
            Array.Sort(tabStevil);
            File.WriteAllLines("Zneski.txt", tabStevil);
        }

        public static void Stevila()
        {
            StreamWriter pisi = File.CreateText("Stevila.txt");
            int stVrstic = 0;

            for (int i = 0; i < 200; i += 5)
            {
                pisi.Write(i + " ");
                stVrstic++;
                
                if(stVrstic % 10 == 0) pisi.WriteLine();
            }

            pisi.Close();

            string[] tabela = File.ReadAllLines("Stevila.txt"); //vsebino datoteke prenesemo v tabelo nizov
            
            //v vsaki vrstici te tabele so cela števila ločena s presledki razen v zadnji
            //Tabelo bomo obdelali in vsako vrstico splitali glede na presledke
            for(int i = 0; i < tabela.Length; i++)
            {
                string[] tabStevil = tabela[i].Split(' ');
                int vsota = 0;

                //Obdelamo tabelo števil a izpustimo zadnjo vrstico ker je prazna
                for (int j = 0; j < tabStevil.Length - 1; j++)
                {
                    vsota += Int32.Parse(tabStevil[j]);
                }

                tabela[i] += " Vsota " + vsota;
            }
            
            //Obdelamo tabelo zapišemo nazaj v datoteko
            File.WriteAllLines("Stevila.txt", tabela);
        }

        public static void PovprecnaVrednostStevil()
        {
            StreamReader beri = File.OpenText("Zneski.txt");
            string datotekaIme = "Zneski.txt";
            string vrstica = beri.ReadLine();

            double vsota = 0;
            double povp = 0;

            int stVrstic = 0;
            while (vrstica != null)
            {
                vsota += Double.Parse(vrstica);
                stVrstic++;

                vrstica = beri.ReadLine();
            }

            povp = vsota / stVrstic;
            Console.WriteLine("Povprečna vrednost števil v datoteki " + datotekaIme + " je " + Math.Round(povp,2));
        }

        public static void Manekenke()
        {
            StreamReader beri = File.OpenText("Manekenke.txt");
            string vrstica = beri.ReadLine();

            int maxVisina = 0;
            string najVecjaManekenka = "";

            int minVisina = 9999;
            string najmanjsaManekenka = "";
            
            while (vrstica != null)
            {
                string[] podatki = vrstica.Split(":");

                int trenutnaVisina = Int32.Parse(podatki[0]);

                //shranjujemo največjo manekenko
                if (trenutnaVisina > maxVisina)
                {
                    maxVisina = trenutnaVisina;
                    najVecjaManekenka = podatki[1] + " " + podatki[2];
                }

                if (minVisina > trenutnaVisina)
                {
                    minVisina = trenutnaVisina;
                    najmanjsaManekenka = podatki[1] + " " + podatki[2];
                }

                vrstica = beri.ReadLine();
            }

            Console.WriteLine("Največja manekenka je " + najVecjaManekenka + ", ki meri " + maxVisina + "cm");
            Console.WriteLine("Najmanjša manekenka je " + najmanjsaManekenka + ", ki meri " + minVisina + "cm");

            beri.Close();
        }
    }
}