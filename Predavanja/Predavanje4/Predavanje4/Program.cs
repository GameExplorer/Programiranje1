
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

            Random rnd = new Random();

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

            povprecje = vsota / 100.0;
            Console.WriteLine("Vsota števil = {0} \nPovprečje števil = {1}", vsota, povprecje);
            
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
        }
    }
}