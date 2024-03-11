
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Predavanje9
{
    class Student
    {
        public string Ime { get; set; }
        public string Predmet { get; set; }
        public int Ocena { get; set; }

    }

    class Formula
    {
        public string Ime { get; set; }
        public string Priimek { get; set; }
        public int LetoOsvojitveNaslova { get; set; }
        public int SteviloZmag { get; set; }
    }
    
    class Program
    {
        public static void Main(String[] args)
        {
            //SERIALIZACIJA
            Student student = new Student
            {
                Ime = "Mika",
                Predmet = "Programiranje",
                Ocena = 9,
            };

            string vrstica = string.Concat(student.Ime, ";", student.Predmet, ";", student.Ocena);
            Console.WriteLine(vrstica);

            vrstica = JsonSerializer.Serialize(vrstica);
            Console.WriteLine(vrstica);

            //DESERIALIZACIJA
            string vrstica2 = "Mika;Programiranje;9";
            string[] niz = vrstica2.Split(";");

            //Student student3 = JsonSerializer.Deserialize<Student>(vrstica2);

            for (int i = 0; i < niz.Length; i++)
            {
                Console.WriteLine(niz[i]);
            }

            Student student2 = new Student
            {
                Ime = niz[0],
                Predmet = niz[1],
                Ocena = Int32.Parse(niz[2]),
            };

            Formula voznik = new Formula
            {
                Ime = "Max",
                Priimek = "Verstappen",
                LetoOsvojitveNaslova = 2023,
                SteviloZmag = 19,
            };

            string zmagovalec = string.Concat(voznik.Ime, ";", voznik.Priimek, ";", voznik.LetoOsvojitveNaslova, ";",
                voznik.SteviloZmag);
            string tmp = zmagovalec;
            Console.WriteLine(zmagovalec);

            zmagovalec = JsonSerializer.Serialize(zmagovalec);
            Console.WriteLine(zmagovalec);
            Console.WriteLine();
            
            string[] podatki = tmp.Split(";");

            for (int i = 0; i < podatki.Length; i++)
            {
                Console.WriteLine(podatki[i]);
            }
            
            
            //DATOTEKE BRANJE IN ZAPISOVANJE
            
            //preberemo vse vrstice v datoteki
            string[] vrstice4 = File.ReadAllLines("/home/melioads/Documents/GitHub/Programiranje1/Predavanja/Predavanje9/Predavanje9/ocene.txt");

            //Nastavim dolzino tabelo objekta Studenti, za dolzino vrstic
            Student[] studenti = new Student[vrstice4.Length];

            //gremo po vseh indeksih
            for (int i = 0; i < studenti.Length; i++)
            {
                //vsako vrstico splitamo po ; da dobimo podatke
                string[] podatki2 = vrstice4[i].Split(";");
                
                //po temu splitu smo naredili studenta... DESERIALIZACIJA
                studenti[i] = new Student{
                    Ime = podatki2[0],
                    Predmet = podatki2[1],
                    Ocena = Int32.Parse(podatki2[2]),
                }; 
            }

            //Zapiše v datoteko 
            File.WriteAllText("/home/melioads/Documents/GitHub/Programiranje1/Predavanja/Predavanje9/Predavanje9/ocena.json", JsonSerializer.Serialize(podatki));
        }
    }
}