﻿using NoteApp.BusinessLayer;
using NoteApp.Entities;
using NoteApp.WebApp.ViewModels;
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

            
            return View(nm.GetAllNotes().OrderByDescending(x=>x.ModifiedOn).ToList());
            //return View(nm.GetAllNotes().OrderByDescending(x => x.ModifiedOn).ToList());

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

            return View("Index",cat.Notes.OrderByDescending(x=>x.ModifiedOn).ToList());
        }

        public ActionResult MostLiked()
        {
            NoteManager nm = new NoteManager();
            return View("Index",nm.GetAllNotes().OrderByDescending(x => x.LikeCount).ToList());
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Login()
        {
            //Giriş kontrolü ve yönlendirme
            //Session'a kullanıcı bilgi saklama
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {

            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            //kullanıcı username kontrlü
            //kullanıcı e posta kontrolü
            //kayıt işlemi
            //aktivasyon e postası gönderimi

            if (ModelState.IsValid)
            {
                bool hasError = false;

                if (model.Username == "aaa")
                {
                    ModelState.AddModelError("", "Kullanıcı adı kullanılıyor.");
                    hasError = true;
                }

                if (hasError == true)
                {
                    return View(model);
                }

                return RedirectToAction("RegisterOk");
            }

            return View(model);
        }

        public ActionResult UserActivate(Guid activate_id)
        {
            //Kullanıcı aktivasyonu sağlanacak
            return View();
        }

        public ActionResult Logout()
        {
            return View();
        }

        public ActionResult RegisterOk()
        {
            return View();
        }
    }
}