using Microsoft.AspNetCore.Mvc;
using MailKit.Net.Smtp;
using MimeKit;
using UchPpp.DataAccess;
using UchPpp.Models;

namespace UchPppProjects.Controllers
{
    public class ProjectController : Controller
    {
        private readonly PppDbContext _db;

        public ProjectController(PppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Project> objProjectList = _db.Projects;
             return View(objProjectList);
        }
        //GET
        public IActionResult Create()
        {
           
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Project obj)
        {
            
            if (ModelState.IsValid)
            {
                _db.Projects.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Project Added Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
            
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if(id==null || id==0)
            {
                return NotFound();
            }
            var projectFromDb = _db.Projects.Find(id);
            //var projectFromDbFirst = _db.Projects.FirstOrDefault(u=>u.Id==id);
           // var projectFromDbFirstSingle = _db.Projects.SingleOrDefault(u => u.Id == id);

            if(projectFromDb==null)
            {
                return NotFound();
            }

            return View(projectFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Project obj)
        {

            if (ModelState.IsValid)
            {
                _db.Projects.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Project Updated Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var projectFromDb = _db.Projects.Find(id);
            var projectFromDbFirst = _db.Projects.FirstOrDefault(u=>u.ProjectName=="id");
            // var projectFromDbFirstSingle = _db.Projects.SingleOrDefault(u => u.Id == id);

            if (projectFromDbFirst == null)
            {
                return NotFound();
            }

            return View(projectFromDbFirst);
        }
        //POST
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Projects.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
           
            
                _db.Projects.Remove(obj);
                _db.SaveChanges();
            TempData["success"] = "Project Deleted Successfully";
            return RedirectToAction("Index");

        }
    }
}
