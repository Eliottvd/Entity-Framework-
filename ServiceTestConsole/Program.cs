using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfService;

namespace ServiceTestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Service1 ser = new Service1();
            List<FilmDTO> a = ser.FindListFilmByPartialActorName("Wil");
            foreach (FilmDTO f in a)
            {
                Console.WriteLine(f.toString());
            }

            Console.ReadKey();
        }
    }
}
