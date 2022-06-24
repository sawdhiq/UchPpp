using Microsoft.AspNetCore.Mvc;
using MailKit.Net.Smtp;
using MimeKit;
using UchPpp.DataAccess;
using UchPpp.Models;
using UchPpp.DataAccess.Repository.Irepository;

namespace UchPppProjects.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProjectController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Project> objProjectList = _unitOfWork.Project.GetAll();
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
                _unitOfWork.Project.Add(obj);
                _unitOfWork.Save();
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
            //var projectFromDb = _db.Projects.Find(id);
            var projectFromDbFirst = _unitOfWork.Project.GetFirstOrDefault(u=>u.Id==id);
           // var projectFromDbFirstSingle = _db.Projects.SingleOrDefault(u => u.Id == id);

            if(projectFromDbFirst==null)
            {
                return NotFound();
            }

            return View(projectFromDbFirst);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Project obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Project.Update(obj);
                _unitOfWork.Save();
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
            var projectFromDbFirst = _unitOfWork.Project.GetFirstOrDefault(u=>u.Id == id);
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
            var obj = _unitOfWork.Project.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
           
            
                _unitOfWork.Project.Remove(obj);
                _unitOfWork.Save();
            TempData["success"] = "Project Deleted Successfully";
            return RedirectToAction("Index");

        }
    }
}
