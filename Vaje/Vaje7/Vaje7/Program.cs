//"Izjavljam, da sem nalogo opravil samostojno in da sem njen avtor.
//Zavedam se, da v primeru, če izjava prvega stavka ni resnična, kršim disciplinska pravila."
// 

namespace Vaje7
{
    class PravokotniTrikotnik
    {
        public int a; //javna atributa, kateti
        public int b;

        /*public PravokotniTrikotnik()
        {
            this.a = a;
            this.b = b;
        }*/
        public double Hipotenuza()
        {
            return Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
        }

        public double Ploscina()
        {
            return a * b / 2.0;
        }

        public double Obseg()
        {
            return a + b + Hipotenuza();
        }
    }

    class AnalizaDatoteke
    {
        public string imeDatoteke;

        //Konstrutor za vnos podatka o celotnem imenu datoteke
        public AnalizaDatoteke(string imeDatoteke) 
        {
            this.imeDatoteke = imeDatoteke;
        }

        public string Mapa()
        {
            string mapa = imeDatoteke;

            //vzamemo dolžino celotnega niza, odštejemo imeDatoteke in koncnico + 2 pa za piko in zadnji slash
            //nalogo sem se lotil od zadaj naprej sem dobil koncnico nato imeDatoteke in šele na konec pot
            //dobimo dolžino mape
            int dolzina = imeDatoteke.Length - (datotekaIme().Length + koncnica().Length + 2);
            
            //izpišemo mapo tako, da izpišemo od prve črke do zadnje za dolžino mape, ki jo dobimo zgoraj
            mapa = mapa.Substring(0, dolzina);

            return mapa;
        }

        public string datotekaIme()
        {
            string datoteka = "";

            for (int i = imeDatoteke.Length - 1; i > 0; i--)
            {
                string trenutniZnak = imeDatoteke[i].ToString();
                if (trenutniZnak == "\\") break;
                datoteka = imeDatoteke[i] + datoteka; //Seznam,txt
            }

            datoteka = datoteka.Remove(datoteka.IndexOf('.')); //znebimo vse kar je po piki
            return datoteka;
        }

        public string koncnica()
        {
            //odstrani vse znake od prvega do pike .. nato pa s substringom začnemo po piki in izpišemo le 
            //končnico datoteke
            string koncnica = imeDatoteke.Remove(0, imeDatoteke.IndexOf('.'));
            koncnica = koncnica.Substring(1);
            return koncnica;
        }
    }

    class Trgovina
    {
        private string ime;
        public string naslov;
        public int velikostTrgovine;

        public Trgovina(string ime, string naslov, int velikostTrgovine)
        {
            this.ime = ime;
            this.naslov = naslov;
            this.velikostTrgovine = velikostTrgovine;
        }

        public void Naslov(string noviNaslov)
        {
            this.ime = noviNaslov;
        }

        public string Izpis()
        {
            return string.Format("Ime: {0}, naslov: {1}, velikost:{2} m²", ime, naslov, velikostTrgovine); 
        }
    }
    
    class Program
    {
        public static void Main(String[] args)
        {
            //Namesto, da je vse nametano v konzolnem oknu sem se odločil za tale pristop
            //inspiracija iz pred 2 nalog nazaj
            char izbira;
            do
            {
                Console.WriteLine("Izberi nalogo:");
                Console.WriteLine("1. Naloga");
                Console.WriteLine("2. Naloga");
                Console.WriteLine("3. Naloga");
                Console.WriteLine("4. Naloga");
                Console.WriteLine("X. Izhod");
                
                Console.Write("Izberi nalogo: ");
                izbira = Console.ReadKey().KeyChar;

                Console.WriteLine();

                switch (izbira)
                {
                    case '1':
                        Console.Clear();

                        //Vnos neštevila v int
                        try
                        {
                            Console.Write("Vnesi število med 0 in 1000: ");
                            int vnos = Int32.Parse(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.Write("Nisi vnesel števila");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Napaka " + e);
                        }

                        Console.WriteLine();

                        //Deljenje z nic
                        Console.Write("Vnesi x: ");
                        int x = Int32.Parse(Console.ReadLine());

                        Console.Write("Vnesi y: ");
                        int y = Int32.Parse(Console.ReadLine());

                        try
                        {
                            int rez = x / y;
                            Console.WriteLine("Rezultat je {0}", rez);
                        }
                        catch (DivideByZeroException)
                        {
                            Console.WriteLine("Deljenje z 0 ni dovoljeno!");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Napaka " + e);
                        }

                        //Indeks izven tabele
                        int[] tabela = new int[5];

                        try
                        {
                            tabela[6] = 32;
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("Vneseni indeks je izven tabele");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Napaka " + e);
                        }

                        Console.WriteLine("\nPritisni tipko za nadaljevanje...");
                        Console.ReadKey();
                        
                        break;

                    case '2':
                        Console.Clear();
                        Console.Write("Vnesi dolžino katete a: ");
                        int a = Int32.Parse(Console.ReadLine());

                        Console.Write("Vnesi dolžino katete b: ");
                        int b = Int32.Parse(Console.ReadLine());

                        Console.WriteLine();

                        PravokotniTrikotnik trikotnik = new PravokotniTrikotnik();

                        trikotnik.a = a; //zapis katet v atribute objekta
                        trikotnik.b = b;

                        Console.WriteLine("Dolžina hipotenuze: {0}", trikotnik.Hipotenuza());

                        Console.WriteLine("Ploščina obsega: {0}", trikotnik.Ploscina());

                        Console.WriteLine("Obseg trikotnika: {0}", trikotnik.Obseg());

                        Console.WriteLine("\nPritisni tipko za nadaljevanje...");
                        Console.ReadKey();
                        break;

                    case '3':
                        Console.Clear();
                        Console.Write("Vnesi pot datoteke: ");
                        string datoteka = Console.ReadLine();

                        Console.Clear();

                        AnalizaDatoteke ad = new AnalizaDatoteke(datoteka);

                        Console.WriteLine("Polno ime: {0}", ad.imeDatoteke);
                        Console.WriteLine(string.Concat(Enumerable.Repeat("-", 32)));

                        Console.WriteLine("Mapa: {0}", ad.Mapa());
                        Console.WriteLine("Datoteka: {0}", ad.datotekaIme());
                        Console.WriteLine("Končnica: {0}", ad.koncnica());

                        Console.WriteLine("\nPritisni tipko za nadaljevanje...");
                        Console.ReadKey();

                        break;

                    case '4':
                        Console.Clear();
                        Trgovina t1 = new Trgovina("Hofer", "Celovška cesta 5", 300);
                        Console.WriteLine(t1.Izpis());

                        Trgovina t2 = new Trgovina("Lidl", "Tržaška cesta 12", 400);
                        Console.WriteLine(t2.Izpis());
                        
                        Console.WriteLine("\nPritisni tipko za nadaljevanje...");
                        Console.ReadKey();

                        break;

                    case 'X':
                    case 'x':
                        Console.WriteLine("Zapiranje...");
                        break;

                    default:
                        Console.WriteLine("Nepravilna izbira! Poskusi ponovno");
                        break;
                }

                Console.WriteLine();
            } while (izbira != 'X' && izbira != 'x');

        }
    }
}