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
        
        public string Status { get; set; }

        public string Rating { get; set; }

        public FilmDTO()
        {
        }

        public String toString()
        {
            return "\nTitle : " + Title
                    + "\nOriginal title : " + OriginalTitle
                    + "\nRelease date : " + ReleaseDate
                    + "\nVoteAverage : " + VoteAverage
                    + "\nVoteCount : " + VoteCount
                    + "\nRuntime : " + Runtime
                    + "\nPosterpath : " + Posterpath
                    + "\nTagLine : " + TagLine
                    + "\nStatus : " + Status
                    + "\nRating : " + Rating + "\n-----------------------------\n"
                    ;
        }
    }
}
