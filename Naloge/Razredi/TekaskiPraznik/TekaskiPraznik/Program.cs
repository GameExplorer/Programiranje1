using Podatek;

//PRIJAVA NA TEK IN IZPIS PODATKOV O TEKAČU TER O NJEGOVEM TEKU
//Program prejme podatke o tekaču (ime, priimke, letnicaRojstva). Štartna številka se samodejno generira je random (v konstruktorju
//Izpis podatkov o tem tekaču (izpiše njegovo ime, priimek, letnicoRojstva in njegovo štartno številko)

//IZRAČUN IN IZPIS PODATKOV O TEKU
//Tekač nato izbere progo (10K, 21K, 42K) in vnese čas, ki ga je potreboval da je pretekel izbrano razdaljo v minutah ali v hh:MM:ss
//(če gre za 21K ali 42K) (uporabimo double)
//Na podlagi izbrane proge nato izračunamo povprečen tempo na kilometer.
//Formula za izračun tempa/km = čas (min) / razdaljo (km) .. ta podatek nato pretvorimo v smiselen čas npr.
//če je rezultat 4,777 min/km pretvorimo to tako da decimalna števila pomnožimo z 60 in dobimo na koncu 4:46/km
//poleg tega izpiše v katero cono spada (njegov skupni čas) (A,B,C,D)

//DODATNO
//Izpiše še 10 tekmovalcev (tabela tekmovalcev z naključnimi podatki o imenu, priimku in štartni št.) za to progo in njihove čase (random) 
//in na podlagi časa smiselno uvrsti našega tekača

namespace TekaskiPraznik
{
    class Program
    {
        public static void Main(String[] args)
        {
            Console.WriteLine("Pozdravljeni na tekaškem prazniku!");
            Console.WriteLine("Za sodelovanje izpolnite sledeči obrazec");
            Console.WriteLine("Na obrazec -->");
            Console.ReadKey();
            Console.Clear();

            //VNOS PODATKOV
            Console.WriteLine("Vnesi svoje podatke");
            Console.Write("Vnesi ime: ");
            string ime = Console.ReadLine();
            
            Console.Write("Vnesi priimek: ");
            string priimek = Console.ReadLine();
            
            Console.Write("Vnesi letnico rojstva: ");
            int letnicaRojstva = Int32.Parse(Console.ReadLine());
            
            Tekac tekac = new Tekac(ime, priimek, letnicaRojstva);
            
            //Izpis podatkov
            tekac.Izpis();

            //Izbira proge 10K, 21K, 42K
            Console.WriteLine("Izberi progo (10K - deset, 21K - polmaraton, 42K - maraton)");
            Console.Write("Izbira: ");
            string vnosProge = Console.ReadLine();
            

        }
    }
}