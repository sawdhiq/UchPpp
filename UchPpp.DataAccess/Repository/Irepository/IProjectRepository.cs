using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UchPpp.Models;

namespace UchPpp.DataAccess.Repository.Irepository
{
    public interface IProjectRepository : IRepository<Project>
    {
        void Update(Project obj);
        void Save();
    }
}
