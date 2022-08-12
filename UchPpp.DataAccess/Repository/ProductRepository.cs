using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UchPpp.DataAccess.Repository.Irepository;
using UchPpp.Models;

namespace UchPpp.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private PppDbContext _db;
        public ProductRepository(PppDbContext db) : base(db)    
        {
            _db = db;   
        }
        void IProductRepository.Save()
        {
            _db.SaveChanges();
        }

        public void Update(Product obj)
        {
            var objFromDb = _db.Products.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Title = obj.Title;
                objFromDb.Description = obj.Description;    
                objFromDb.Price = obj.Price;
                objFromDb .Price50 = obj.Price50;
                objFromDb.ListPrice = obj.ListPrice;
                objFromDb.Price100 = obj.Price100;
                objFromDb.ISBN = obj.ISBN;
                objFromDb.Author = obj.Author;
                objFromDb.PojectId = obj.PojectId;
                objFromDb.CoverTypeId = obj.CoverTypeId;
                if(obj.ImageUrl != null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }
            }
        }

       
    }
}
