
namespace Predavanje7
{
    class StudentOcena
    {
        public string ime;
        public int tocke;
        
        public void Izpis()
        {
            Console.Write("ime: {0}, točke: {1}, ", ime, tocke);
        }
        
    }
    class Predavanje
    {
        public static void Main(String[] args)
        {
            //program zajame rezultate kolokvija. Nato izračuna povprečno število tčk
            //na koncu izpiše vse študente, ki imajo nadpovprečno število točk.

            StudentOcena[] ocene = Vnos();

            double povprecje = Povprecje(ocene);
            
            //Izpis študentov
            IzpiseNadpovprecne(ocene, povprecje);
        }

        //Metoda extractana z Riderjem
        private static void IzpiseNadpovprecne(StudentOcena[] ocene, double povprecje)
        {
            for (int i = 0; i < ocene.Length; i++)
            {
                if(ocene[i].tocke > povprecje) ocene[i].Izpis();
            }
        }

        //Metoda extractana z Riderjem
        private static StudentOcena[] Vnos()
        {
            StudentOcena[] ocene = new StudentOcena[0];

            while (true)
            {
                StudentOcena novaOcena = new StudentOcena();
                Console.Write("Ime: ");
                string vnosStudenta = Console.ReadLine();

                novaOcena.ime = vnosStudenta;

                if (novaOcena.ime == "") break;

                Console.Write("Vnesi točke: ");
                int vnosTock = Int32.Parse(Console.ReadLine());

                novaOcena.tocke = vnosTock;

                Array.Resize(ref ocene, ocene.Length + 1);
                
                ocene[ocene.Length - 1] = novaOcena;
            }

            return ocene;
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
        
    }
}