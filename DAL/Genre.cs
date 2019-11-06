using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Genre
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GenreId { get; set; }
        public string Name { get; set; }


        public Genre(string text)
        {
            string[] genredetail;
            Char[] delimiterChars = { '\u2024' };
            genredetail = text.Split(delimiterChars);
            GenreId = Int32.Parse(genredetail[0]);
            Name = genredetail[1];
        }
        public virtual ICollection<Film> Film { get; set; }
    }
}
