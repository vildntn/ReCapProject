using Core.DataAccess.EntitiyFramework;
using DataAccess.Abstact;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal:EfEntityRepositoryBase<Rental,ReCapContext>,IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using(ReCapContext context=new ReCapContext())
            {
                var result = from u in context.Users
                             join cu in context.Customers
                             on u.UserId equals cu.UserId
                             join r in context.Rentals
                             on cu.CustomerId equals r.CustomerId
                             from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             select new RentalDetailDto
                             {
                                 BrandName=b.BrandName,
                                 Id=r.RentId,
                                CustomerName=u.FirstName+" "+ u.LastName,
                                RentDate=r.RentDate,
                                ReturnDate= (DateTime)r.ReturnDate
                            
                             };
                return result.ToList();
            }

        }

    }
}
