using CodeBai9.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeBai9.Controllers
{
    public class TinTucController : Controller
    {
        // GET: TinTuc
        TinTucDB db = new TinTucDB();
        public ActionResult Index()
        {
            var list = db.Tintucs.Select(h => h).ToList();
            return View(list);
        }

        public ActionResult Details(int id)
        {
            var item = db.Tintucs.Where(h => h.IdTin == id).First();
            return View(item);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.IDLoai = new SelectList(db.Theloaitins.Select(h=>h), "IDLoai", "Tentheloai");
            var item = db.Tintucs.Where(h => h.IdTin == id).First();
            return View(item);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.IDLoai = new SelectList(db.Theloaitins.Select(h => h), "IDLoai", "Tentheloai");
        
            return View();
        }


       


        [HttpPost]
        public ActionResult Create(FormCollection f,Tintuc tintuc)
        {
            ViewBag.IDLoai = new SelectList(db.Theloaitins.Select(h => h), "IDLoai", "Tentheloai");
            bool err = false;
            if(String.IsNullOrEmpty(tintuc.Tieudetin))
            {
                ViewBag.LoiTieuDeTin = "Tiêu đề không được để trống";
                err = true;
            }

            if (String.IsNullOrEmpty(tintuc.Noidungtin))
            {
                ViewBag.LoiNoiDung = "Nội dung không được để trống";
                err = true;
                
            }

            if(err)
                return this.Create();

            db.Tintucs.Add(tintuc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult Edit(int id, Tintuc tintuc)
        {
            var mTinTuc = db.Tintucs.Where(h => h.IdTin == id).First();
            ViewBag.IDLoai = new SelectList(db.Theloaitins.Select(h => h), "IDLoai", "Tentheloai");
            mTinTuc.Tieudetin = tintuc.Tieudetin;
            UpdateModel(tintuc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            var tintuc = db.Tintucs.Where(h => h.IdTin == id).First();
            return View(tintuc);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection f)
        {
            var tintuc = db.Tintucs.Where(h => h.IdTin == id).First();
            db.Tintucs.Remove(tintuc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}