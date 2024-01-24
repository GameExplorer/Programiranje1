/*
 * Izjavljam, da sem nalogo opravil samostojno in da sem njen avtor. Zavedam se, da v primeru,
 * če izjava prvega stavka ni resnična, kršim disciplinska pravila.
 */
namespace Vaje4
{
    class Program
    {
        public static void Main(String[] args)
        {
            // BREAK AND CONTINUE
            
            //Operacije();

            //MnozenjeDoSto();

            Presledki();

            //Razmnozi();
        }

        public static void Operacije()
        {

            int vsota = 0;
            int stevec = 0;

            while (stevec < 10)
            {
                
                if (stevec < 5)
                {
                    //Uporabniške številke
                    Console.Write("Vnesi 5 celih števil: ");
                    int stevilka = Int32.Parse(Console.ReadLine());

                    //stevilka je soda, pozitivna in ni mnogokratnik števila 10
                    if (stevilka % 2 == 0 && stevilka > 0 && stevilka % 10 != 0 ) vsota += stevilka;
                    // številka je liha in pozitivna, nobeno liho število ni mnogokratnik 10, ta pogoj je odveč
                    else if (stevilka % 2 != 0 && stevilka > 0) vsota -= stevilka;

                    Console.WriteLine("Vsota je {0}", vsota); //sprotno preverjanje, vsota DELA pravilno
                    
                    stevec++;
                    continue; //nazaj na pogoj 
                }

                /* //Pomozni izpis
                Console.WriteLine();
                Console.WriteLine("Vsota uporabnikovih cifer " + vsota);
                Console.WriteLine();
                */
                
                //Random številke
                Random rnd = new Random();
                int rndStevilke = rnd.Next(-100, 101);
                rndStevilke = rnd.Next(-100, 101);

                //ista logika kot pri uporabniških številih
                if (rndStevilke % 2 == 0 && rndStevilke > 0 && rndStevilke % 10 != 0) vsota += rndStevilke;
                else if (rndStevilke % 2 != 0 && rndStevilke > 0) vsota -= rndStevilke;

                //Console.WriteLine("Naključna številka " + rndStevilke);
                
                Console.WriteLine("Vsota števil je {0} ", vsota);

                stevec++;
            }
            
        }

        public static void MnozenjeDoSto()
        {
            Console.Write("Vnesi realno število: ");

            double vnos = Double.Parse(Console.ReadLine());
            double stevilkaZaIpis = vnos;

            int stevec = 0;

            //če ni pozitivno, konec izvajanja programa
            if (vnos < 0)
            {
                Environment.Exit(1); 
            }

            while (true) //zanka se vendo izvede tudi za število večje od 100
            {
                // torej izračuna tudi, če je večje od 100 ampak v if stavku potem števec odštejemo tako, da je 
                // izpis pravilen
                vnos *= 1.1;
                //Console.WriteLine(vnos);
                stevec++;
                
                if (vnos > 100) //odštejemo števec da dobimo zadnje število, ki ni preseglo 100 in končamo zanko
                {
                    stevec--;
                    break;
                }
                
               
            }
            //Console.WriteLine(vnos);
            Console.WriteLine("Vašo številko {0} je bilo potrebno {1} pomnožiti z 1.1 da ste prišli do 100", stevilkaZaIpis, stevec);
        }

        // TODO
        public static void Presledki()
        {
            Console.Write("Vnesi niz");
            string vnos = Console.ReadLine();
            Console.WriteLine(vnos);
            string noviStavek = "";

            for (int i = 0; i < vnos.Length; i++) 
            {
               
            }

            Console.WriteLine(vnos);
        }

        public static void Razmnozi()
        {
            Console.Write("Vnesi niz: ");
            string vnos = Console.ReadLine();
            
            Console.Write("Vnesi kolikokrat bi razmnožil niz: ");
            int stevilka = Int32.Parse(Console.ReadLine());

            string novNiz = "";

            //sprehod po nizu
            for (int i = 0; i < vnos.Length; i++)
            {
                var ponovitev = Enumerable.Repeat(vnos[i], stevilka); //uporabim Enumerable za ponavljanje vsake črke
                //namesto var-a lahko lahko napišem IEnumerable<char> je samo za boljši pregled
                Console.Write(string.Join("", ponovitev)); //združimo v en niz
            }

           
        }
    }
}