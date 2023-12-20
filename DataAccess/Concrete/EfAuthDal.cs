using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfAuthDal : EfEntityRepositoryBase<AppUser, PetnabizDatabaseContext>
    {
    }
}
