using NoteApp.BusinessLayer;
using NoteApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace NoteApp.WebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //Test Commands

            //BusinessLayer.Test test = new BusinessLayer.Test();
            //test.CommentTest();

            //Listing notes by category
            //if (TempData["mod"] != null)
            //{
            //    return View(TempData["mod"] as List<Note>);
            //}

            //Listing All Notes
            NoteManager nm = new NoteManager();

            
            return View(nm.GetAllNotes());
        }

        public ActionResult ByCategory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CategoryManager cm = new CategoryManager();
            Category cat = cm.GetCategoryById(id.Value);

            if (cat == null)
            {
                return HttpNotFound();
                //return RedirectToAction("Index,"Home");
            }

            return View("Index",cat.Notes);
        }
    }
}