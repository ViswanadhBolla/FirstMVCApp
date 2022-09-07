using Microsoft.AspNetCore.Mvc;
using FirstMVCApp.Models;
using Microsoft.AspNetCore.Http;

namespace FirstMVCApp.Controllers
{
    public class PenController : Controller
    {
        public static Pen p = new Pen();
        public static List<Pen> pens = Pen.getAllPens();

        public string msg()
        {
            return "welcome";
        }

        public ContentResult message()
        {
            return Content("Welcome");
        }
        
        
        public ViewResult PenDetails ()
        {
            p.PenId = 101;
            p.PenName = "Parker";
            p.Price = 9000;
            return View(p);
        }


        public IActionResult PendetailsList()
        {
            
            return View(pens);
        }

        public IActionResult AddNewPen()
        {
            return View();
        }

        [HttpPost]

        public IActionResult AddNewPen(Pen p)
        {
            pens.Add(p);
            return RedirectToAction("PendetailsList");
        }

        public IActionResult Details(int id)
        {
            p = pens.Where(x => x.PenId == id).SingleOrDefault();
            return View(p);
        }

        public IActionResult Edit(int id)
        {
            HttpContext.Session.SetString("pid",id.ToString());
            p = pens.Where(x => x.PenId == id).SingleOrDefault();
            return View(p);
        }

        [HttpPost]

        public IActionResult Edit(Pen p)
        {
            string pid = HttpContext.Session.GetString("pid");
            int id = Convert.ToInt32(pid);
            p.PenId = id;
            Pen oldpen = pens.Where(pens => pens.PenId == id).SingleOrDefault();
            //oldpen.PenName = p.PenName;
            //oldpen.Price = p.Price;
            pens.Remove(oldpen);
            pens.Add(p);
            return RedirectToAction("PendetailsList");
        }

        public IActionResult Delete(int id)
        {
            p = pens.Where(x => x.PenId == id).SingleOrDefault();
            return View(p);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            
            p = pens.Where(pens => pens.PenId == id).SingleOrDefault();
            pens.Remove(p);
            return RedirectToAction("PendetailsList");
        }

    }
}
