using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class Character
    {
        public int CharacterId { get; set; }
        public string CharacterName { get; set; }


        public virtual ICollection<CharacterActors> CharacterActors { get; set; }
    }
}
