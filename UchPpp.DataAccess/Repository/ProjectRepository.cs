using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UchPpp.DataAccess.Repository.Irepository;
using UchPpp.Models;

namespace UchPpp.DataAccess.Repository
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        private PppDbContext _db;
        public ProjectRepository(PppDbContext db) : base(db)    
        {
            _db = db;   
        }
        void IProjectRepository.Save()
        {
            _db.SaveChanges();
        }

        public void Update(Project obj)
        {
            _db.Projects.Update(obj);
        }

       
    }
}
