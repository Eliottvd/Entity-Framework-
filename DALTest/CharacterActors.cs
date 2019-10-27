using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DALTest
{
    class CharacterActors
    {
        [Key, Column(Order = 0)]
        public int CharacterId { get; set; }
        [Key, Column(Order = 1)]
        public int ActorId { get; set; }
        [Key, Column(Order = 2)]
        public int FilmId { get; set; }

        public virtual Character Character { get; set; }
        public virtual Actor Actor { get; set; }
        public virtual Film Film { get; set; }


        public CharacterActors(Film f, Character c, Actor a)
        {
            Character = c;
            Film = f;
            Actor = a;
        }

    }
}
