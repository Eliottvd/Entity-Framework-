using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;
using WebApp.ServiceReference1;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class MovieController : Controller
    {
        private Service1Client serv = new Service1Client();
        // GET: Movie
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Actors(string actName)
        {
            List<ActorDTO> actorDTOs = serv.FindListActorByPartialActorName(actName, 0, 10);
            listActors tmp = new listActors(actorDTOs);

            return View(tmp);
        }

        public ActionResult Details(string actName)
        {
            List<ActorDTO> actorDTOs = serv.FindListActorByPartialActorName(actName,0,10);
            ActorDTO act = actorDTOs.First();
            List<FilmDTO> filmDTOs = serv.GetListFilmsByIdActor(act.ActorId);
            FilmDTO tmp = filmDTOs.First();
            WebApp.Models.Movie MovModel = new Models.Movie(tmp);
            return View(MovModel);
        }
    }
}