using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.ServiceReference1;

namespace WebApp.Models
{
    public class listMovies
    {
        public List<Movie> listFilm { get; set; }
        public listMovies(List<FilmDTO> filmDTOs)
        {
            listFilm = new List<Movie>();
            foreach(FilmDTO film in filmDTOs)
            {
                listFilm.Add(new Movie(film));
            }
        }

       
    }
}