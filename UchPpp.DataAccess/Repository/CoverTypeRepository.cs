using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UchPpp.DataAccess.Repository.Irepository;
using UchPpp.Models;

namespace UchPpp.DataAccess.Repository
{
    public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
        private PppDbContext _db;
        public CoverTypeRepository(PppDbContext db) : base(db)    
        {
            _db = db;   
        }
        void ICoverTypeRepository.Save()
        {
            _db.SaveChanges();
        }

        public void Update(CoverType obj)
        {
            _db.CoverTypes.Update(obj);
        }

       
    }
}
