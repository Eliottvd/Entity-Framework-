using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader f = new StreamReader(@"D:\GoogleDrive\Ecole\2019-2020\3e Indus\C#\Entity-Framework\movies_v2.txt");
            for (int i =0; i < 100; i++)
            {
                readAnddecodeline(f);
                Console.WriteLine("Decoding line " + i);
            }

        }

        private static bool readAnddecodeline(StreamReader f)
        {
            string line = f.ReadLine();
            if (line == null)
                return false;

            // Creation d'un objet film
            FilmParser filmtext = new FilmParser();
            Film film = filmtext.DecodeFilmText(line);

            SaveFilmToDataBase(film);

            return true;
        }

        private static void SaveFilmToDataBase(Film film)
        {
            using (var dal = new DALManager("FilmDB"))
            {
                dal.AddFilm(film);
            }
        }
    }
}
