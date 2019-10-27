using System;
using System.Collections.Generic;
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

            using (var ctx = new FilmCtx())
            {
                var film = new Film() { FilmID = 1, Title = "DaniLecx" };

                ctx.Films.Add(film);
                ctx.SaveChanges();
            }

            Console.ReadLine();
        }
    }
}
