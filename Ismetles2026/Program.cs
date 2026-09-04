using Ismetles2026.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ismetles2026
{
    internal class Program
    {
        private static List<Latnivalo> latnivalok = new List<Latnivalo>();
        static void Main(string[] args)
        {
            latnivalok.Add(new Latnivalo(new Dictionary<string, int>() { { "teljes árú", 3000 }, { "kedvezményes", 1500 } },
     new string[7, 2] {{"Zárva", "Zárva" },
                      {"10:00", "18:00" },
                      {"10:00", "18:00" },
                      {"10:00", "18:00" },
                      {"10:00", "18:00" },
                      {"10:00", "18:00" },
                      {"10:00", "18:00" }},
     1,
     "JPM Vasarely Múzeum",
     "Pécs, Káptalan utca 3."));
            latnivalok.Add(new Latnivalo(new Dictionary<string, int>() { { "teljes árú", 3000 }, { "kedvezményes", 1500 } },
                new string[7, 2] {{"Zárva", "Zárva" },
                      {"10:00", "18:00" },
                      {"10:00", "18:00" },
                      {"10:00", "18:00" },
                      {"10:00", "18:00" },
                      {"10:00", "18:00" },
                      {"10:00", "18:00" }},
                2,
                "JPM Csontváry Múzeum",
                "Pécs, Janus Pannonius utca 11."));

            latnivalok.Add(new Latnivalo(new Dictionary<string, int>() { { "teljes árú", 2000 }, { "kedvezményes", 1000 } },
                new string[7, 2] {{"Zárva", "Zárva" },
                      {"10:00", "18:00" },
                      {"10:00", "18:00" },
                      {"10:00", "18:00" },
                      {"10:00", "18:00" },
                      {"10:00", "18:00" },
                      {"10:00", "18:00" }},
                3,
                "JPM Zsolnay Múzeum",
                "Pécs, Káptalan utca 2."));

            latnivalok.Add(new Latnivalo(new Dictionary<string, int>() { { "teljes árú", 3000 }, { "kedvezményes", 1500 } },
                new string[7, 2] {{"Zárva", "Zárva" },
                      {"10:00", "18:00" },
                      {"10:00", "18:00" },
                      {"10:00", "18:00" },
                      {"10:00", "18:00" },
                      {"10:00", "18:00" },
                      {"10:00", "18:00" }},
                4,
                "JPM Múzeum Galéria",
                "Pécs, Káptalan utca 4."));

            latnivalok.Add(new Latnivalo(new Dictionary<string, int>() { { "teljes árú", 5600 }, { "kedvezményes", 5000 } },
                new string[7, 2] {{"9:00", "17:00" },
                      {"9:00", "17:00" },
                      {"9:00", "17:00" },
                      {"9:00", "17:00" },
                      {"9:00", "19:00" },
                      {"9:00", "17:00" },
                      {"13:00", "17:00" }},
                5,
                "Dzsámi",
                "Pécs, Káptalan utca 4."));




            Console.WriteLine("Adatok felvitele!");
            Console.Write("Látnivaló azonosítója: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Látnivaló megnevezése: ");
            string megnevezes = Console.ReadLine();

            Console.Write("Látnivaló címe: ");
            string cim = Console.ReadLine();

          
            Dictionary<string, int> ar = new Dictionary<string, int>();

            Console.Write("Hányféle belépő van? ");
            int db = int.Parse(Console.ReadLine());

            for (int i = 0; i < db; i++)
            {
                Console.Write("Belépő kategóriája: ");
                string kategoria = Console.ReadLine();

                Console.Write("Belépő ára: ");
                int arErtek = int.Parse(Console.ReadLine());

                ar[kategoria] = arErtek;
            }

            string[,] nyitvatartas = new string[7, 2];

            string[] napok =
            {
                "Hétfő",
                "Kedd",
                "Szerda",
                "Csütörtök",
                "Péntek",
                "Szombat",
                "Vasárnap"
            };

            for (int i = 0; i < 7; i++)
            {
                Console.Write($"{napok[i]} nyitása (óó:pp vagy Zárva): ");
                nyitvatartas[i, 0] = Console.ReadLine();

                if (nyitvatartas[i, 0] == "Zárva")
                {
                    nyitvatartas[i, 1] = "Zárva";
                }
                else
                {
                    Console.Write($"{napok[i]} zárása (óó:pp): ");
                    nyitvatartas[i, 1] = Console.ReadLine();
                }
            }

        
            latnivalok.Add(new Latnivalo(
                ar,
                nyitvatartas,
                id,
                megnevezes,
                cim
            ));

            Console.WriteLine("A látnivaló sikeresen eltárolva!");




            // 5. feladt


            Console.WriteLine(latnivalok[0].Nyitvatartas(DateTime.Today));


            // 6. feladat

            Latnivalo legdragabb = latnivalok
    .OrderByDescending(v => v.ArVisszaado())
    .First();

            Console.WriteLine(legdragabb.Megnevezes);
            Console.WriteLine(legdragabb.ArVisszaado());

            //7. feladat
            Latnivalo legolcsobb = latnivalok
                .Where(v => v.Ar("diák") != -1)
                .OrderBy(v => v.Ar("diák"))
                .First();

            Console.WriteLine(legolcsobb.Megnevezes);
            Console.WriteLine(legolcsobb.Ar("diák"));


        }
    }
}
