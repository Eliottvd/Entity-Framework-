using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Rating
    {
        public int RatingId { get; set; }
        public string Type { get; set; }

        public Rating() { }

        public Rating(string ratingType)
        {
            Type = ratingType;
            Film = new List<Film>();
        }

        public virtual ICollection<Film> Film { get; set; }
    }
}
