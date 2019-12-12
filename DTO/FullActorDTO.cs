using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class FullActorDTO : ActorDTO
    {
        public List<String> Films { get; set; }
        public List<String> Characters { get; set; }
        public FullActorDTO()
        {

        }

        public FullActorDTO(ActorDTO actor)
        {
            this.ActorId = actor.ActorId;
            this.Name = actor.Name;
        }
    }
}
