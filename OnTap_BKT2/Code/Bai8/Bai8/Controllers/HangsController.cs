using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bai8.Models;

namespace Bai8.Controllers
{
    public class HangsController : Controller
    {
        private FShopDB db = new FShopDB();
        private static bool orderNameValue = false;
        private static bool orderPriceValue = false;
        // GET: Hangs
        public ActionResult Index(string orderName, string orderPrice, string search)
        {
           
            var hangs = db.Hangs.Select(h => h);
            if(!String.IsNullOrEmpty(search))
            {
                hangs = hangs.Where(h => h.TenHang.Contains(search));
            }    
            if (!String.IsNullOrEmpty(orderName))
            {
                if (bool.Parse(orderName) != orderNameValue)
                {
                    orderNameValue = bool.Parse(orderName);

                    if (!orderNameValue)
                        hangs.OrderByDescending(h => h.TenHang);
                    else
                        hangs = hangs.OrderBy(h => h.TenHang);
                }
                
            }
            ViewBag.SapTheoTen = orderNameValue;

            

            // giá
            if (!String.IsNullOrEmpty(orderPrice))
            {
                if (orderPriceValue != bool.Parse(orderPrice))
                {
                    orderPriceValue = bool.Parse(orderPrice);

                    if (!orderPriceValue)
                        hangs.OrderByDescending(h => h.Gia);
                    else
                        hangs = hangs.OrderBy(h => h.Gia);
                }   
               
            }
            ViewBag.SapTheoGia = orderPriceValue;
           



            return View(hangs.ToList());
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
            ViewBag.MaNCC = new SelectList(db.Nha_CC, "MaNCC", "TenNCC");
            return View();
        }

        // POST: Hangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHang,MaNCC,TenHang,Gia,LuongCo,MoTa,ChietKhau,HinhAnh")] Hang hang)
        {
            ViewBag.MaNCC = new SelectList(db.Nha_CC, "MaNCC", "TenNCC", hang.MaNCC);
            try
            {
                if (ModelState.IsValid)
                {
                    var f = Request.Files["ImageFile"];
                    Console.WriteLine(f.ToString());
                    if(f != null && f.ContentLength > 0)
                    {
                        string fileName = System.IO.Path.GetFileName(f.FileName);
                        string upload = Server.MapPath("~/wwwroot/WineImages/"+ fileName);
                        f.SaveAs(upload);
                        hang.HinhAnh = fileName;
                    }    
                    db.Hangs.Add(hang);
                    db.SaveChanges();
                    
                }
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.Error = "Lỗi thêm dữ liệu " + ex.Message;
                return View(hang);
            }

            
            
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
            ViewBag.MaNCC = new SelectList(db.Nha_CC, "MaNCC", "TenNCC", hang.MaNCC);
            return View(hang);
        }

        // POST: Hangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHang,MaNCC,TenHang,Gia,LuongCo,MoTa,ChietKhau,HinhAnh")] Hang hang)
        {
            ViewBag.MaNCC = new SelectList(db.Nha_CC, "MaNCC", "TenNCC", hang.MaNCC);
            try
            {
                if (ModelState.IsValid)
                {

                   
                    var f = Request.Files["ImageFile"];
                    if (f != null && f.ContentLength > 0)
                    {
                        string FileName = System.IO.Path.GetFileName(f.FileName);
                        string UploadPath = Server.MapPath("~/wwwroot/WineImages/" + FileName);
                        f.SaveAs(UploadPath);
                        hang.HinhAnh = FileName;
                    }

                    db.Entry(hang).State = EntityState.Modified;
                    db.SaveChanges();
                   
                }
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.Error = "Có lỗi khi sửa";
                return View(hang);
            }
           
            
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
            }
            catch(Exception ex)
            {
                ViewBag.Error = "Có lỗi khi xóa";
                return View("Delete", hang);
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
