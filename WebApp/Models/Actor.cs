using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.ServiceReference1;

namespace WebApp.Models
{
    public class Actor : FullActorDTO
    {
        public Actor() { }
        public Actor(FullActorDTO act)
        {
            ActorId = act.ActorId;
            Name = act.Name;
            Films = act.Films;
            Characters = act.Characters;
            Comments = act.Comments;
        }
    }
}