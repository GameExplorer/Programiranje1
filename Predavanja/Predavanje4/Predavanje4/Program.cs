
namespace Predavanje4
{
    class Program
    {
        public static void Main(String[] args)
        {
            //DVODIMENZIONALNA TABELA PRIMER (tabela celih števil 10 vrstic in 10 stolpcev

            int[,] tabelaCelihStevil = new int[10, 10]; // ustvarimo tabelo
            Console.WriteLine(tabelaCelihStevil[0,2]); //izpišemo prvo vrstico, tretji element

            tabelaCelihStevil[0, 2] = 12; //napolnim
            Console.WriteLine(tabelaCelihStevil[0,2]);

            int[,] tabela = new int[2, 3] { { 1, 1, 1 }, { 2, 2, 2 } };
            Console.WriteLine(String.Join(" ", tabela.Cast<int>()));
            
            /*Tabela naključnih števil*/

            int[,] tabelaNakljucnihStevil = new int[5, 10];

            Random rnd = new Random(); //objektna metoda

            for (int vrstice = 0; vrstice < tabelaNakljucnihStevil.GetLength(0); vrstice++) //indeks za vrstico 
            {
                for (int stolpci = 0; stolpci < tabelaNakljucnihStevil.GetLength(1); stolpci++) //indeks za stolpec
                {
                    tabelaNakljucnihStevil[vrstice, stolpci] = rnd.Next(-10, 11);
                }   
            } 
            
            Console.WriteLine(String.Join(" ", tabelaNakljucnihStevil.Cast<int>()));
            
            /* Tabela števil */

            int[,] tabela2 = new int[10, 10];

            for (int vrstice = 0; vrstice < tabela2.GetLength(0); vrstice++)
            {
                for (int stolpci = 0; stolpci < tabela.GetLength(1); stolpci++)
                {
                    if (vrstice == stolpci) // diagonalni elementi dobijo vrednost 1
                    {
                        tabela2[vrstice, stolpci] = 1;
                    }
                    else if (vrstice < stolpci) //elementi nad diagonalo dobijo vrednost 2
                    {
                        tabela[vrstice, stolpci] = 2;
                    }
                }
            }
            Console.WriteLine(String.Join(" ", tabela2.Cast<int>()));
            
            /* VSOTA IN POVPREČNA VREDNOST */

            Random nak = new Random();

            int[,] tab = new int[10, 10];
            int vsota = 0;
            double povprecje;

            for (int vrstica = 0; vrstica < tab.GetLength(0); vrstica++)
            {
                for (int stolpec = 0; stolpec < tab.GetLength(1); stolpec++)
                {
                    tab[vrstica, stolpec] = nak.Next(0, 100);
                    vsota += tab[vrstica, stolpec];
                }
            }

            /* ENODIMENZIONALNA TABELA */
            double vsota1 = 0;
            double povp1;
            int[] tab3 = new int[5];
            for (int i = 0; i < tab3.Length; i++)
            {
                tab3[i] = nak.Next(1, 6);
                vsota1 += tab3[i];
            }

            povp1 = vsota1 / tab3.Length;
            Console.WriteLine("Vsota enodimenzionalne tabele je {0} \nPovprecje je {1}", vsota1, povp1);

            povprecje = vsota / 100.0;
            Console.WriteLine("Vsota števil = {0} \nPovprečje števil = {1}", vsota, povprecje);
            
            // IMELI TABELO NIZOV, KI PREDSTAVLJAJO BESEDE
            // IZRAČUNALI BOMO NAJDALJŠO BESEDO (niz)

            string[] beseda = new string[]{"Danes", "je", "roboticizemis", "mrzlo", "in", "ponedeljek"};
            
            NajdaljsaBeseda(beseda);
            
            //ZNAKI V TABELI

            char[,] tab2 = new char[5, 5];
            Random rnd2 = new Random();
            char trenutniZnak = 'A';
            
            for (int vrstica = 0; vrstica < tab2.GetLength(0); vrstica++)
            {
                for (int stolpec = 0; stolpec < tab2.GetLength(1); stolpec++)
                {
                    //tab2[vrstica, stolpec] = Convert.ToChar(rnd2.Next(65, 91));
                    tab2[vrstica, stolpec] = trenutniZnak;
                    trenutniZnak++;
                }
            }
            Console.WriteLine(String.Join(" ", tab2.Cast<char>()));
            
            
            Console.WriteLine(Sestevek(11,242));    
            
            //izpis od (1,10).. izpiše števila od prve do zadnje
            IzpisOdDo(1,10);
            
            //metoda prejme niz in ga x-krat ponovi
            Console.WriteLine(Ponavljanje("Ponedeljek", 6));
            
            
            //OBJEKT
            Student s1 = new Student{ ime = "Miha", ocena = 10};
            //s1.ime = "Miha";
            //s1.ocena = 10;
            s1.Izpis();
            
        }

        public static string Ponavljanje(string niz, int a)
        {
            string besede = ""; //naredimo spremenljivko, ki bo vračala niz
            for (int i = 1; i <= a; i++)
            {
                besede += niz + " "; //dodam niz k tej spremenljivki
            }

            return besede;
            //return string.Join("", Enumerable.Repeat(niz, a));
        }

        public static void IzpisOdDo(int a, int b)
        {
            for (int i = a; i <= b; i++)
            {
                Console.WriteLine(i);
            }
        }

        /* METODA */
        public static string NajdaljsaBeseda(string[] tabela)
        {
            string najdaljsaBeseda = tabela[0];

            for (int i = 0; i < tabela.Length; i++)
            {
                if(tabela[i].Length > najdaljsaBeseda.Length)
                    najdaljsaBeseda = tabela[i];
            }

            Console.WriteLine(najdaljsaBeseda);

            return najdaljsaBeseda;
        }

        public static int Sestevek(int a, int b)
        {
            return a + b;
        }
    }
    
    

    class Student
    {
        public string ime;
        public int ocena;
        
        public void Izpis()
        {
            Console.WriteLine("Ime: " + this.ime + " Ocena: "  + this.ocena);
        }
    }
}