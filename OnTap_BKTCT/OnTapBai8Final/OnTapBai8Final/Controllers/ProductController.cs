using OnTapBai8Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnTapBai8Final.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        private static bool sortValue = false;

        WineStoreDB db = new WineStoreDB();
        public ActionResult Index(string start, string end, string find, string sort)
        {
            if(!String.IsNullOrEmpty(start) && !String.IsNullOrEmpty(end))
            {
                int mstart = int.Parse(start);
                int mend = int.Parse(end);
                return View(db.Products.Select(h => h).Where(h=>h.Price > mstart && h.Price < mend).ToList());
            }
            if (!String.IsNullOrEmpty(find))
            {
                return View(db.Products.Select(h => h).Where(h => h.ProductName.Contains(find) || find.Contains(h.ProductName)).ToList());
            
            }
           
            if (!String.IsNullOrEmpty(sort))
            {
                sortValue = !bool.Parse(sort);
               
            }
            ViewBag.Sort = sortValue;
            if (sortValue)
                return View(db.Products.Select(h => h).OrderByDescending(h => h.Price).ToList());
            var list = db.Products.Select(h => h).OrderBy(h=> h.Price).ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.CatalogyID = new SelectList(db.Catalogies, "CatalogyID", "CatalogyName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product, FormCollection f)
        {
            ViewBag.CatalogyID = new SelectList(db.Catalogies, "CatalogyID", "CatalogyName");
            try
            {
                bool error = false;
                bool check = db.Products.Where(h => h.ProductID == product.ProductID).Any();
                if (product.ProductID <= 0)
                {
                    ViewBag.LoiMa = "Mã trống ! và mã >0";
                    error = true;
                }

                if (check)
                {
                    ViewBag.LoiMa = "Mã trùng";
                    error = true;
                }

                if (String.IsNullOrEmpty(product.ProductName))
                {
                    ViewBag.LoiTen = "Tên trống !" + product.Price;
                    error = true;
                }


                if (product.Price <= 0)
                {
                    ViewBag.LoiGia = "Giá không được trống hoặc <0 !";
                    error = true;
                }

                if (error)
                {
                    return View();
                }
                else
                {
                    db.Products.Add(product);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }


            }
            catch(Exception ex)
            {
                ViewBag.Loi = "Có lỗi khi thêm "+ex.Message;
                return View();
            }
            
        }

        public ActionResult Detail(int id)
        {
            var hang = db.Products.Where(h => h.ProductID == id).First();
            return View(hang);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var hang = db.Products.Where(h => h.ProductID == id).First();
            ViewBag.CatalogyID = new SelectList(db.Catalogies, "CatalogyID", "CatalogyName", hang.CatalogyID);
           
            return View(hang);
        }

        [HttpPost]
        public ActionResult Edit(int id,Product product, FormCollection f)
        {
            ViewBag.CatalogyID = new SelectList(db.Catalogies, "CatalogyID", "CatalogyName", product.CatalogyID);
            try
            {
                bool error = false;
              

                if (String.IsNullOrEmpty(product.ProductName))
                {
                    ViewBag.LoiTen = "Tên trống !" + product.Price;
                    error = true;
                }


                if (product.Price <= 0)
                {
                    ViewBag.LoiGia = "Giá không được trống hoặc <0 !";
                    error = true;
                }

                if (error)
                {
                    return this.Edit(id);
                }
                else
                {
                    var tmp = db.Products.Find(product.ProductID);
                  
                    UpdateModel(tmp);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }


            }
            catch (Exception ex)
            {
                ViewBag.Loi = "Có lỗi khi thêm " + ex.Message;
                return this.Edit(id);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            ViewBag.CatalogyID = new SelectList(db.Catalogies, "CatalogyID", "CatalogyName");
            var hang = db.Products.Where(h => h.ProductID == id).First();
            return View(hang);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection f)
        {
            ViewBag.CatalogyID = new SelectList(db.Catalogies, "CatalogyID", "CatalogyName");
            var hang = db.Products.Where(h => h.ProductID == id).First();
            db.Products.Remove(hang);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}