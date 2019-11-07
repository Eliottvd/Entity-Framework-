using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Film
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FilmId { get; set; }
        public string Title { get; set; }
        public string OriginalTitle { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public float VoteAverage { get; set; }
        public int VoteCount { get; set; }
        public int Runtime { get; set; }
        public string Posterpath { get; set; }
        public int Budget { get; set; }
        public string TagLine { get; set; }
        
        public int StatusId { get; set; }
        public Status Status { get; set; }

        public int RatingId { get; set; }
        public Rating Rating { get; set; }

        public Film()
        {
            Comments = new List<Comment>();
            CharacterActors = new List<CharacterActors>();
            Genres = new List<Genre>();
            Directors = new List<Director>();
        }


        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<CharacterActors> CharacterActors { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<Director> Directors { get; set; }
    }
}
