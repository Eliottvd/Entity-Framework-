using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ActorDTO
    {
        public int ActorId { get; set; }
        public string Name { get; set; }

        public ActorDTO() { }
        public ActorDTO(string[] acteurdetail)
        {
            ActorId = Int32.Parse(acteurdetail[0]);
            Name = acteurdetail[1];
            CharacterActors = new List<CharacterActorsDTO>();
        }

    }
}
