using System;

namespace DTO
{
    public class FilmDTO
    {
        public string Title { get; set; }
        public string OriginalTitle { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public float VoteAverage { get; set; }
        public int VoteCount { get; set; }
        public int Runtime { get; set; }
        public string Posterpath { get; set; }
        public int Budget { get; set; }
        public string TagLine { get; set; }
        
        public StatusDTO Status { get; set; }

        public RatingDTO Rating { get; set; }

        public FilmDTO()
        {
        }
    }
}
