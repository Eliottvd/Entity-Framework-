using WebApp.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    
    public class Movie : FilmDTO
    {
        public string RuntimeString;
        public Movie(FilmDTO film)
        {
            FilmId = film.FilmId;
            Title = film.Title;
            OriginalTitle = film.OriginalTitle;
            ReleaseDate = film.ReleaseDate;
            Runtime = film.Runtime;
            Posterpath = film.Posterpath;
            Budget = film.Budget;
            TagLine = film.TagLine;
            Status = film.Status;
            Rating = film.Rating;
            TimeSpan ts = TimeSpan.FromMinutes(film.Runtime);
            RuntimeString = string.Format("{0}h{1}", ts.Hours, ts.Minutes);
        }

    }
}