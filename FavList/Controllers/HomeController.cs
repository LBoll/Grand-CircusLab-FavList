using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FavList.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //This will take care of the action:
        // /Home/AddToFavList?Name=songname
        public ActionResult AddToFavList(string Name)
        {
            //setup the session
            if (Session["FavList"] == null)
            {
                Session.Add("FavList", new List<string>());
            }
            

            //Fetch the list from the session
            List<string> FavList = (List<string>)Session["FavList"];

            if (!FavList.Contains(Name))
            {
                FavList.Add(Name);// added the song to the fav list
            }
            //Save list back in session
            Session["FavList"] = FavList;

            ViewBag.FavList = FavList;//Sending the favlist to the view

            return View("About");

        }
    }
}