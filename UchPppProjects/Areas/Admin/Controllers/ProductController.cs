using Microsoft.AspNetCore.Mvc;
using MailKit.Net.Smtp;
using MimeKit;
using UchPpp.DataAccess;
using UchPpp.Models;
using UchPpp.DataAccess.Repository.Irepository;

namespace UchPppProjects.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<CoverType> objCoverType = _unitOfWork.CoverType.GetAll();
             return View(objCoverType);
        }
        
        //GET
        public IActionResult Upsert(int? id)
        {
            Product product = new();
            if(id==null || id==0)
            { 
                //create
                return View(product);
            }
            else
            {
                //update
            }
          

            return View(product);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Project obj)
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
