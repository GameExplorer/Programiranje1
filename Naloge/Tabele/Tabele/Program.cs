// See https://aka.ms/new-console-template for more information

using System.Globalization;

namespace Tabele
{
    class Program
    {
        public static void Main(String[] args)
        {
            //NaključnaTabela();
            //TabelaNaključnihŠtevil();
            //TabelaZnakov();
            //TabelaRacunov();
            //TabelaNizov();
            //PrepisVNovoTabelo();
            KvadratnaMatrika();

            // TABELA PRODAJE PO MESECIH
            /*double[] mesecnaProdaja = new double[12];
            double[] vnosi = VnosPodatkov(mesecnaProdaja);
            NajvecjaProdaja(vnosi);*/
        }

        public static void NaključnaTabela()
        {
            Random rnd = new Random();

            int[] tabela = new int[100]; //ustvarim tabelo s 100 mesti

            //Napolnim tabelo
            for (int i = 0; i < tabela.Length; i++)
            {
                tabela[i] = rnd.Next(50, 101);
            }

            int zadnjiElement = tabela[99];
            Console.WriteLine("Zadnji element je: {0}", zadnjiElement);

            double povprečje;
            int vsota = 0;

            int največjeŠtevilo = tabela[0];
            
            //Pogledamo števila, ki so večja od zadnjega elementa, izračunamo povprečje in poiščemo največje število
            for (int i = 0; i < tabela.Length; i++)
            {
                vsota += tabela[i];
                if (tabela[i] > zadnjiElement)
                {
                    Console.Write(tabela[i] + ", ");
                }

                if (največjeŠtevilo < tabela[i])
                {
                    največjeŠtevilo = tabela[i];
                }

            }
            Console.WriteLine();

            povprečje = (double)vsota / tabela.Length;
            Console.WriteLine("Vsota vseh števil je {0}, Povprečje je {1}", vsota, povprečje);

            Console.WriteLine("Največje število je {0}", največjeŠtevilo);
        }

        public static void TabelaNaključnihŠtevil()
        {
            Console.Write("Vnesi velikost tabele: ");
            int n = Int32.Parse(Console.ReadLine());
            
            Console.Write("Vnesi spodnjo mejo: ");
            int a = Int32.Parse(Console.ReadLine());

            Console.Write("Vnesi zgornjo mejo: ");
            int b = Int32.Parse(Console.ReadLine());

            int[] tabela = new int[n];

            //napolnimo tabelo z naključimi števili med a in b
            for (int i = 0; i < tabela.Length; i++)
            {
                tabela[i] = Random.Shared.Next(a, b);
                //Console.WriteLine(tabela[i]);
            }

            //izpis 5 števil v vsaki vrstici
            for (int i = 0; i < tabela.Length; i++)
            {
                Console.Write(tabela[i] + " ");

                if ((i + 1) % 5 == 0) // 4 + 1 = 5 % 5 == 0 --> indeksi se začnejo s 0 ... 5 element ima indeks 4
                {
                    Console.WriteLine();
                }
                
            }
        }

        public static void TabelaZnakov()
        {
            Console.Write("Vnesi velikost tabele: ");
            int n = Int32.Parse(Console.ReadLine());
            char[] tabelaZnakov = new char[n]; //originalna tabela
            char[] novaTabela = new char[n * 3]; //vsak element ponovimo dvakrat

            Random rnd = new Random();

            //Napolnimo tabeli
            for (int i = 0; i < tabelaZnakov.Length; i++)
            {
                tabelaZnakov[i] = (char)rnd.Next('a', 'z' + 1);
                //Console.WriteLine(tabelaZnakov[i]);

                novaTabela[3 * i] = tabelaZnakov[i];
                novaTabela[3 * i + 1] = tabelaZnakov[i];
                novaTabela[3 * i + 2] = tabelaZnakov[i];

            }

            //Izpis originalne tabele
            for (int i = 0; i < tabelaZnakov.Length; i++)
            {
                Console.Write(tabelaZnakov[i]);
                if((i + 1) % 5 == 0) Console.WriteLine();

            }
            
            //Izpis nove tabele
            Console.WriteLine("Podvojeni nizi:");
            for (int i = 0; i < novaTabela.Length; i++)
            {
                Console.Write(novaTabela[i] + " ");
                
                if((i + 1) % 5 == 0) Console.WriteLine();
            }
        }

        public static void TabelaRacunov()
        {
            Random rnd = new Random();
            int[] racuni = new int[10]; //shranimo račune števil
            int stPravilnih = 0;

            for (int i = 0; i < 10; i++)
            {
                int prviFaktor = rnd.Next(100, 1000);
                int drugiFaktor = rnd.Next(0, 10);

                Console.Write("{0} * {1} = ", prviFaktor, drugiFaktor);
                int vnos = Int32.Parse(Console.ReadLine());

                racuni[i] = prviFaktor * drugiFaktor;

                if (racuni[i] == vnos) stPravilnih++;

                Console.WriteLine("Pravilen odgovor: " + racuni[i]);
            }

            Console.WriteLine("Pravilno si rešil {0}/10 primerov", stPravilnih);
        }

        public static void TabelaNizov()
        {
            string[] tabelaNizov = new string[10];

            //Polnimo tabelo z našimi nizi
            for (int i = 0; i < tabelaNizov.Length; i++)
            {
                Console.Write("Vnesi {0}. niz: ", (i+1));
                tabelaNizov[i] = Console.ReadLine();
                //Console.WriteLine(tabelaNizov[i]);
            }

            string najdaljsiNiz = tabelaNizov[0];

            for (int i = 0; i < tabelaNizov.Length; i++)
            {
                if (tabelaNizov[i].Length > najdaljsiNiz.Length)
                {
                    najdaljsiNiz = tabelaNizov[i];
                }
            }
            
            Console.WriteLine("Najdaljši niz je {0} ", najdaljsiNiz);
        }

        public static double[] VnosPodatkov(double[] tabela)
        {
            for (int i = 0; i < tabela.Length; i++)
            {
                Console.Write("Vnesi mesečno prodajo za {0}. mesec: ", i+1);
                tabela[i] = Double.Parse(Console.ReadLine());
            }

            return tabela;
        }

        public static void NajvecjaProdaja(double[] tabelaMesecneProdaje)
        {
            double najvecjaProdaja = tabelaMesecneProdaje[0];
            int stMeseca = 0;

            for (int i = 0; i < tabelaMesecneProdaje.Length; i++)
            {
                if (tabelaMesecneProdaje[i] > najvecjaProdaja)
                {
                    najvecjaProdaja = tabelaMesecneProdaje[i];
                    stMeseca = i+1;
                }
            }

            Console.WriteLine("Največja prodaja je bila v {0} mesecu in je znašala {1}€", stMeseca, najvecjaProdaja);
        }

        public static void PrepisVNovoTabelo()
        {
            Random rnd = new Random();

            int[] tabela = new int[10];

            Console.Write("Prvotna tabela: ");
            //Napolnimo tabelo
            for (int i = 0; i < tabela.Length; i++)
            {
                tabela[i] = rnd.Next(1, 101);
                Console.Write(tabela[i] + " ");
            }

            Console.WriteLine();
            int[] novaTabela = new int[tabela.Length];
            
            //Sortiramo števila 
            for (int i = 0; i < tabela.Length / 2; i++)
            {
                novaTabela[i] = tabela[i * 2]; // vsak sod indeks zapiše v novo tabelo torej 0 .. 2 .. 4 in njihove elemente zapiše v tabelo
            }

            int k = tabela.Length / 2;
            for (int i = 1; i < tabela.Length; i = i + 2)
            {
                novaTabela[k] = tabela[i];
                k++;
            }
            
            //izpis elementov
            Console.Write("Nova tabela: ");
            for (int i = 0; i < novaTabela.Length; i++)
            {
                Console.Write(novaTabela[i] + " ");
                
                //if(i + 1 % 10 == 0) Console.WriteLine();
            }
        }

        public static void KvadratnaMatrika()
        {
            int[,] tabela = new int[7, 7];
            Random rnd = new Random();

            int maxVrednost = 0;
            
            //polnimo tabelo
            for (int i = 0; i < tabela.GetLength(0); i++)
            {
                for (int j = 0; j < tabela.GetLength(1); j++)
                {
                    tabela[i, j] = rnd.Next(0, 1001);
                    Console.Write(tabela[i,j] + " ");

                    if ((j + 1) % 7 == 0) Console.WriteLine();
                }
            }

            maxVrednost = 0;
            int stolpec = 0;
            int vrstica = 0;
            int stevec = 0;

            for (int i = 0; i < tabela.GetLength(0); i++)
            {
                for (int j = 0; j < tabela.GetLength(1); j++)
                {
                    if (maxVrednost < tabela[i, j])
                    {
                        maxVrednost = tabela[i, j];
                        vrstica = i;
                        stolpec = j;
                    }

                    if (tabela[i, j] % 5 == 0)
                    {
                        stevec++;
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("Največji element: {0} na indexu [{1}, {2}]", maxVrednost, vrstica, stolpec );
            Console.WriteLine("Število števil, ki so deljiva s 5 je {0}", stevec);

            Console.WriteLine();
            //zmanjšane vrednost elementov
            for (int i = 0; i < tabela.GetLength(0); i++)
            {
                for (int j = 0; j < tabela.GetLength(1); j++)
                {
                    tabela[i, j] -= 2;
                    Console.Write(tabela[i,j] + " ");
                    
                    if ((j + 1) % 7 == 0) Console.WriteLine();

                }
            }
        }
    }
}