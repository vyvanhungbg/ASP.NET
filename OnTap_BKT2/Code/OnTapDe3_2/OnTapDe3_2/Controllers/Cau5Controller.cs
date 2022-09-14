using OnTapDe3_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnTapDe3_2.Controllers
{
    public class Cau5Controller : Controller
    {
        DeDB db = new DeDB();
        // GET: Cau5
        public ActionResult Index()
        {
            var list = new SelectList(db.Hangs, "Mahang", "Tenhang");
            ViewBag.Loai = list;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Hang hang)
        {
            var list = new SelectList(db.Hangs, "Mahang", "Tenhang");
            ViewBag.Loai = list;
            bool err = false;
            if (String.IsNullOrEmpty(hang.Mahang))
            {
                ViewBag.LoiMa = " Mã không đc để trống ";
                err = true;
            }

            if (String.IsNullOrEmpty(hang.Tenhang))
            {
                ViewBag.LoiTen = " Tên không đc để trống ";
                err = true;
            }

            if (String.IsNullOrEmpty(hang.Loai))
            {
                ViewBag.LoiLoai = " Loại không đc để trống ";
                err = true;
            }

            if (hang.Gia <0)
            {
                ViewBag.LoiGia = " Giá hàng không được âm ";
                err = true;
            }
            int check = db.Hangs.Where(h => h.Mahang == hang.Mahang).Count();
            if (check>=1)
            {
                ViewBag.LoiMa = " Trùng mã hàng ";
                err = true;
            }
            if (err)
            {
                return View("Index");
            }
            
            db.Hangs.Add(hang);
            db.SaveChanges();
            return RedirectToAction("Index", "Hangs");
        }
    }
}