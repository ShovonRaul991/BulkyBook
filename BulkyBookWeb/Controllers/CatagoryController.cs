using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CatagoryController : Controller
    {
        
        private readonly ApplicationDbContext _context;

        public CatagoryController(ApplicationDbContext db)
        {
            _context = db;
        }
        
        public IActionResult Index()
        {
            IEnumerable<Catagories> CatagoryList = _context.Catagories.ToList();
            return View(CatagoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Catagories obj)
        {
            if (ModelState.IsValid)
            {
                _context.Catagories.Add(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(obj);
            
        }

        public IActionResult Edit(int? id)
        {
            if(id==null || id==0)
            {
               return NotFound(); 
            }
            var CatagorySelected = _context.Catagories.Find(id);
            if(CatagorySelected == null)
            {
                return NotFound();
            }
            return View(CatagorySelected);

        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Catagories obj)
        {
            if (ModelState.IsValid)
            {
                _context.Catagories.Update(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(obj);

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var CatagorySelected = _context.Catagories.Find(id);
            if (CatagorySelected == null)
            {
                return NotFound();
            }
            return View(CatagorySelected);

        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var CatagorySelected = _context.Catagories.Find(id);
            if(CatagorySelected == null)
            {
                return NotFound();
            }
            _context.Catagories.Remove(CatagorySelected);
            _context.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}
