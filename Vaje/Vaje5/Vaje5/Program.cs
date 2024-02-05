/*
 * "Izjavljam, da sem nalogo opravil samostojno in da sem njen avtor. Zavedam se, da v primeru,
 * če izjava prvega stavka ni resnična, kršim disciplinska pravila."
 */

namespace Vaje5
{
 class Program
 {
  public static void Main(String[] args)
  {
   //PregledovanjeTabele();
   //PrenosPodatkov();
   //Pregledovanje2DTabele();
   //PrimerjavaDvehTabel();
   //TabelaZRealnimiPodatki();
   //DeloSTabelamiNizov();
   //KriptiranjePodatkov();
  }

  public static void PregledovanjeTabele()
  {
   int[] tabela = new int[100];
   Random rnd = new Random(); 
   
   //polnimo tabelo z naključnimi števili
   for (int i = 0; i < tabela.Length; i++)
   {
    tabela[i] = rnd.Next(10, 101);
    //Console.WriteLine(tabela[i]);
   }
   
   //zadnji element
   int zadnjiElement = tabela[99];
   
   Console.Write("Števila, ki so večja od zadnjega elementa ({0}) so: ", zadnjiElement);
   //iščemo vrednosti, ki so večje od zadnjega elementa
   for (int i = 0; i < tabela.Length; i++)
   {
    if (tabela[i] > zadnjiElement)
    {
     Console.Write(tabela[i] + " ");
    }
   }
  }

  public static void PrenosPodatkov()
  {
   //Vnesemo dolžino tabele
   Console.Write("Vnesi dolžino tabele: ");
   int velikostTabele = Int32.Parse(Console.ReadLine());
   int[] a = new int[velikostTabele];

   Random rnd = new Random();
   
   //Napolnimo tabelo
   Console.Write("Prvotna tabela: ");
   for (int i = 0; i < a.Length; i++)
   {
    a[i] = rnd.Next(-100, 101);
    Console.Write(a[i] + " ");
   }
   
   //ustvarimo novo tabelo in podvojimo elemente iz prejšne tabele
   int[] b = new int[a.Length * 2];

   for (int i = 0; i < a.Length; i++)
   {
    b[2 * i] = a[i];
    b[2 * i + 1] = a[i];
   }

   Console.WriteLine();
   
   //izpis tabele b
   Console.Write("Nova tabela: ");
   for (int i = 0; i < b.Length; i++)
   {
    Console.Write(b[i] + " ");
   }
  }

  public static void Pregledovanje2DTabele()
  {
   int[,] tabela = new int[5, 3];

   Random rnd = new Random();

   for (int i = 0; i < tabela.GetLength(0); i++)
   {
    for (int j = 0; j < tabela.GetLength(1); j++)
    {
     tabela[i, j] = rnd.Next(-5, 5);
     //Console.WriteLine(tabela[i,j]);
    }
   }

   int stevec = 0; //šteje koliko elementov ustreza pogoju
   
   for (int i = 0; i < tabela.GetLength(0); i++)
   {
    for (int j = 0; j < tabela.GetLength(1); j++)
    {
     if (tabela[i, j] > -2 && tabela[i, j] < 2) stevec++;
    }
   }
   
   Console.WriteLine("Število elementov, ki so večji od -2 in manjši od 2 je {0}", stevec);
  }

  public static void PrimerjavaDvehTabel()
  {
   int[,] prvaTabela = new int[5, 10];
   int[,] drugaTabela = new int[5, 10];

   Random rnd = new Random();
   
   //polnimo obe tabeli
   Console.WriteLine("Elementi v prvi tabeli: ");
   for (int i = 0; i < prvaTabela.GetLength(0); i++)
   {
    for (int j = 0; j < prvaTabela.GetLength(1); j++)
    {
     prvaTabela[i,j] = rnd.Next(1, 101);
     Console.Write(prvaTabela[i,j] + " ");
     
     if((j + 1) % 5 == 0) Console.WriteLine(); //za lepši izpis
    }
   }

   Console.WriteLine();
   
   Console.WriteLine("Elementi v drugi tabeli: ");
   for (int i = 0; i < drugaTabela.GetLength(0); i++)
   {
    for (int j = 0; j < drugaTabela.GetLength(1); j++)
    {
     drugaTabela[i, j] = rnd.Next(1, 101);
     Console.Write(drugaTabela[i,j] + " ");

     if((j + 1) % 5 == 0) Console.WriteLine(); //za lepši izpis
    }
   }

   Console.WriteLine();
   
   //Poiščemo elemente, ki so v prvi niso pa v drugi
   int stevilo;
   Console.Write("Števila, ki so v prvi tabeli in niso v drugi: ");
   for (int i = 0; i < prvaTabela.GetLength(0); i++)
   {
    for (int j = 0; j < prvaTabela.GetLength(1); j++)
    {
     stevilo = prvaTabela[i, j]; //shranimo število v spremenljivko
     bool jeVDrugi = false; //privzamemo, da se prvi element ne nahaja v drugi tabeli

     //sprehod po drugi tabeli
     for (int k = 0; k < drugaTabela.GetLength(0); k++)
     {
      for (int l = 0; l < drugaTabela.GetLength(1); l++)
      {
       if (stevilo == drugaTabela[k, l]) //če je število enako številu v drugi tabeli
       {
        jeVDrugi = true; //potem nastavimo jeVDrugi na true, torej se nahaja v obeh tabelah
        break;
       }
      }
     }
     
     //če je jeVDrugi false torej, če ga ni v drugi tabeli, ga izpišem
     if(!jeVDrugi) Console.Write(stevilo + " ");

    }
   }
  }

  public static void TabelaZRealnimiPodatki()
  {
   int[,] tabela = new int[2, 5];
   int trenutnoStevilo;

   Random rnd = new Random();

   //Polnimo tabelo hkrati pa pregledamo, če je število unikatno torej, če se samo enkrat ponovi
   for (int i = 0; i < tabela.GetLength(0); i++)
   {
    for (int j = 0; j < tabela.GetLength(1); j++)
    {
     bool jeUnikatno = true;

     //Zanka se izvaja toliko časa dokler ne dobimo unikatnega števila
     do
     {
      trenutnoStevilo = rnd.Next(-20, 21); //random številka
      jeUnikatno = true; //je unikatna

      // preverimo ali je dejansko unikatno število ali ne
      for (int k = 0; k < tabela.GetLength(0); k++)
      {
       for (int l = 0; l < tabela.GetLength(1); l++)
       {
        if (tabela[k, l] == trenutnoStevilo) //če je isto število v tabeli številka ni unikatna... false
        {
         jeUnikatno = false;
         break;
        }
       }
       if (!jeUnikatno) break;
      }
     } while (!jeUnikatno);

     tabela[i, j] = trenutnoStevilo; //polnimo unikatna števila
     //Console.WriteLine(tabela[i,j]);
    }
   }

   for (int i = 0; i < tabela.GetLength(0); i++)
   {
    for (int j = 0; j < tabela.GetLength(1); j++)
    {
     double y = 2.7 * tabela[i, j] + 3;
     Console.WriteLine("2,7 * {0} + 3 = {1}", tabela[i,j], y);
    }
   }
   
  }
  
  public static void DeloSTabelamiNizov()
  {
   string[] imena = new string[5];
   string[] priimki = new string[5];

   //Vnesemo 5 študentov
   for (int i = 0; i < 5; i++)
   {
    Console.Write("Vpišite ime študenta: ");
    string vnosImena = Console.ReadLine().ToUpper();
    imena[i] = vnosImena;
    
    Console.Write("Vpišite priimek študenta: ");
    string vnosPriimka = Console.ReadLine().ToUpper();
    priimki[i] = vnosPriimka;
    
    Console.WriteLine();
   }
   
   //Izpis študentov
   for (int i = 0; i < 5; i++)
   {
    Console.WriteLine("{0}. {1} {2}", i+1, priimki[i], imena[i]);
   }
  }

  public static void KriptiranjePodatkov()
  {
   // Uporabnik vnese niz
   Console.Write("Vnesi niz: ");
   string vnos = Console.ReadLine();

   //definiramo tabelo in dodatno spremenljivko
   char[] transformiraniNiz = new char[vnos.Length];
   char novaCrka;
   
   //Zanka ki se sprehaja po vnosu
   for (int i = 0; i < vnos.Length; i++)
   {
    if (char.IsLetter(vnos[i])) // če je trenutni znak črka potem...
    {
     novaCrka = (char)(vnos[i] - 5); //od trenutne črke poišče novo črko ki je 5 mest stran 

     if (novaCrka < 'A') //če je vrednost manjša od A se vrne na konec abecede
     {
      novaCrka += (char)26; 
     }

     transformiraniNiz[i] = novaCrka; //novo črka se shrani v tabelo
    }
    else //če ni črka oz. je presledek ga ohranimo
    {
     transformiraniNiz[i] = ' ';
    }
   }

   //Izpis
   Console.Write("Transformiran niz: ");
   Console.WriteLine(transformiraniNiz);
  }
 }
}