using Core.DataAccess.EntitiyFramework;
using DataAccess.Abstact;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal:EfEntityRepositoryBase<Rental,ReCapContext>,IRentalDal
    {

    }
}
