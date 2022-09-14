using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnTapDe3_2.Models;

namespace OnTapDe3_2.Controllers
{
    public class HangsController : Controller
    {
        private DeDB db = new DeDB();

        // GET: Hangs
        public ActionResult Index(string start, string end)
        {

            int sum = 0;
            if (!String.IsNullOrEmpty(start) && !String.IsNullOrEmpty(end))
            {
                var hang = db.Hangs.ToList().Where(h => h.Gia >= int.Parse(start) && h.Gia <= int.Parse(end)).ToList();
                
                foreach(var h in hang)
                {
                    sum += (int)h.Gia;
                }
                ViewBag.Tong = sum;
                return View(hang);
            }
            else { 
            
                var hang = db.Hangs.Select(h=>h).ToList();
                foreach (var h in hang)
                {
                    sum += (int)h.Gia;
                }
                ViewBag.Tong = sum;
                return View(hang);
            }
        }

        // GET: Hangs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hang hang = db.Hangs.Find(id);
            if (hang == null)
            {
                return HttpNotFound();
            }
            return View(hang);
        }

        // GET: Hangs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Mahang,Tenhang,Loai,Gia")] Hang hang)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Hangs.Add(hang);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    ViewBag.Error = "Lỗi thêm , kiểm tra lại mã hàng đã tồn tại";
                    return View(hang);
                }
                
            }

            return View(hang);
        }

        // GET: Hangs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hang hang = db.Hangs.Find(id);
            if (hang == null)
            {
                return HttpNotFound();
            }
            return View(hang);
        }

        // POST: Hangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Mahang,Tenhang,Loai,Gia")] Hang hang)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(hang).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }catch(Exception ex)
                {
                    ViewBag.Error = "Lỗi sửa ";
                    return View(hang);
                }
            }
            return View(hang);
        }

        // GET: Hangs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hang hang = db.Hangs.Find(id);
            if (hang == null)
            {
                return HttpNotFound();
            }
            return View(hang);
        }

        // POST: Hangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Hang hang = db.Hangs.Find(id);
            try
            {
                db.Hangs.Remove(hang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }catch(Exception ex)
            {
                ViewBag.Error = "Lỗi xóa";
                return View(hang);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
