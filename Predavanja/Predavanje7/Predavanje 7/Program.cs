
namespace Predavanje7
{
    class StudentOcena
    {
        public string ime;
        public int tocke;
        
        public void Izpis()
        {
            Console.WriteLine("ime: {0}, točke: {1} ", ime, tocke);
        }
        
    }
    class Predavanje
    {
        public static void Main(String[] args)
        {
            //program zajame rezultate kolokvija. Nato izračuna povprečno število točk
            //na koncu izpiše vse študente, ki imajo nadpovprečno število točk.

            StudentOcena[] ocene = Vnos();

            double povprecje = Povprecje(ocene);
            
            //Izpis študentov
            IzpiseNadpovprecne(ocene, povprecje);
        }
        
        //Metode extractane z Riderjem
        private static StudentOcena[] Vnos()
        {
            StudentOcena[] ocene = new StudentOcena[0]; //tabela študentov

            while (true)
            {
                StudentOcena novaOcena = new StudentOcena(); //vnašamo ime študenta ...
                Console.Write("Ime: ");
                string vnosStudenta = Console.ReadLine();

                novaOcena.ime = vnosStudenta;

                if (novaOcena.ime == "") break; //dokler ne vnesemo prazen niz vnašamo

                Console.Write("Vnesi točke: "); //vnesemo točke
                int vnosTock = Int32.Parse(Console.ReadLine());

                novaOcena.tocke = vnosTock; //vnesene točke in jih shranimo 

                Array.Resize(ref ocene, ocene.Length + 1); //povečamo tabelo
                
                ocene[ocene.Length - 1] = novaOcena; //na zadnjem mestu dodamo študenta in njegove točke
            }

            return ocene; //vrnemo tabelo z imeni in točkami študentov
        }

        public static double Povprecje(StudentOcena[] ocene)
        {
            double vsota = 0;
            for (int i = 0; i < ocene.Length; i++)
            {
                vsota += ocene[i].tocke;
            }

            return vsota / ocene.Length;
        }
        
        private static void IzpiseNadpovprecne(StudentOcena[] ocene, double povprecje)
        {
            for (int i = 0; i < ocene.Length; i++)
            {
                if(ocene[i].tocke > povprecje) ocene[i].Izpis();
            }
        }
    }
}