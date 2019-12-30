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
        }

    }
}