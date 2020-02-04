using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.ServiceReference1;

namespace WebApp.Models
{
    
    public class listActors
    {
        public List<Actor> list;
        public listActors(List<ActorDTO> actorDTOs)
        {
            list = new List<Actor>();
            foreach(ActorDTO act in actorDTOs)
            {
                list.Add(new Actor
                {
                    ActorId = act.ActorId,
                    Name = act.Name
                });
            }
        }

        public List<string> listActorsNames
        {
            get
            {
                List<string> listNames = new List<string>();
                foreach (Actor act in list)
                {
                    listNames.Add(act.Name);
                }

                return listNames;
            }
        }
    }
}