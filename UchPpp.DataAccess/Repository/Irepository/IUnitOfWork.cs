using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UchPpp.DataAccess.Repository.Irepository
{
    public interface IUnitOfWork
    {
        IProjectRepository Project { get; }
        ICoverTypeRepository CoverType { get; }
        void Save();
    }
}
