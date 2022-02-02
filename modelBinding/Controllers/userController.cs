using modelBinding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace modelBinding.Controllers
{
    public class userController : Controller
    {
        kullaniciEntities db = new kullaniciEntities();
        // GET: user
        public ActionResult Index()
        {
            var model = new userViewIndexModel
            {
                Users = db.usertablo.ToList()

            };
            return View(model);
        }

        public ActionResult Insert()
        {
            return View();
        }

        #region Using Request Object
        [HttpPost]
        public RedirectToRouteResult UserInsert()
        {
            var firstname = Request.Form["firstname"];
            var lastname = Request.Form["lastname"];
            var birthdate = Convert.ToDateTime(Request.Form["birtdate"]);
            db.usertablo.Add(new usertablo { firstname=firstname,lastname=lastname,birtdate=birthdate });
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion
    }
}