using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Director
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DirectorId { get; set; }
        public string DirectorName { get; set; }

        public Director(string text)
        {
            string[] directordetail;
            Char[] delimiterChars = { '\u2024' };
            directordetail = text.Split(delimiterChars);
            DirectorId = Int32.Parse(directordetail[0]);
            DirectorName = directordetail[1];
            Film = new List<Film>();
        }
        public virtual ICollection<Film> Film { get; set; }
    }
}
