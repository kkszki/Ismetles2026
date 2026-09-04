using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ismetles2026.Models
{
    public class Latnivalo
    {
        private Dictionary<string, int> ar;
        private string[,] nyitvatartas;
        private int id;
        private string megnevezes;
        private string cim;

        public Latnivalo(Dictionary<string, int> ar, string[,] nyitvatartas, int id, string megnevezes, string cim)
        {
            this.ar = ar;
            this.nyitvatartas = nyitvatartas;
            this.id = id;
            this.megnevezes = megnevezes;
            this.cim = cim;
        }


        public int Id { get { return id; } }
        public string Megnevezes { get => megnevezes; set => megnevezes = value; }
        public string Cim { get => cim; set => cim = value; }


        public int Ar(string kategoria)

        {

            if (ar.ContainsKey(kategoria))
            {
                return ar[kategoria];
            }
            else
            {
                return -1;
            }
        }

        public void Belepok(int db)
        {
            for (int i = 0; i < db; i++)
            {
                Console.Write("Belépő kategóriája: ");
                string kategoria = Console.ReadLine();

                Console.Write("Ára: ");
                int arErtek = int.Parse(Console.ReadLine());

                ar[kategoria] = arErtek;
            }

        }

        public string Nyitvatartas(DateTime datum)
        {
            int nap = (int)datum.DayOfWeek - 1;

            if (nap == -1)
            {
                nap = 6;
            }
              if (nyitvatartas[nap, 0] == "Zárva")
            {
                return "Zárva";
            }
            return $"{nyitvatartas[nap, 0]}-{nyitvatartas[nap, 1]}";
        }

        public int ArVisszaado()
        {
            return ar.Values.Max();
        }
        public string KategoriaMondo()
        {
            return ar.First(x => x.Value == ar.Values.Max()).Key;
        }

    }
}
