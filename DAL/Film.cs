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
        public DateTime? ReleaseDate { get; set; }
        public int VoteAverage { get; set; }
        public int Runtime { get; set; }
        public string Posterpath { get; set; }

        public Film()
        {
            Comments = new List<Comment>();
            CharacterActors = new List<CharacterActors>();
            Genres = new List<Genre>();
            Actors = new List<Actor>();
        }


        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<CharacterActors> CharacterActors { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<Actor> Actors { get; set; }
    }
}
