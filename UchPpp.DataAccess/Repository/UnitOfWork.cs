using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UchPpp.DataAccess.Repository.Irepository;

namespace UchPpp.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private PppDbContext _db;
        public UnitOfWork(PppDbContext db) 
        {
            _db = db;
            Project = new ProjectRepository(_db);
            CoverType = new CoverTypeRepository(_db);
        }
        public IProjectRepository Project { get; private set; }
        public ICoverTypeRepository CoverType { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
