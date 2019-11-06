using System;
using System.Collections.Generic;
using System.Configuration;
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
            using (var dal = new DALManager("FilmDB"))
            {
                var film = new Film() { Title = "Eliott découvre un gros concombre" };
                dal.AddFilm(film);

                var actor = new Actor() { Name = "Clara Morgane" };
                dal.AddActor(actor);
            }

        }
    }
}
