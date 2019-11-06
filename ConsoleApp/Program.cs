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
            DALManager dal = new DALManager("FilmDB");
            var film = new Film() { FilmID = 1, Title = "DaniLecx" };
            dal.AddFilm(film);
            //using (var ctx = new FilmCtx("bdfilmscsharp"))
            //{
                
            //    var film = new Film() { FilmID = 1, Title = "DaniLecx" };
            //    ctx.Films.Add(film);
            //    ctx.SaveChanges();


            //    Console.Write("Student saved successfully!");
            //    Console.Write("Student", ctx.Films.ToList());
            //}

        }
    }
}
