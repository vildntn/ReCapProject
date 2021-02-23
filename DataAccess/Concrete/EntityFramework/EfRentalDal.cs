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
                var result = from cu in context.Customers
                             join r in context.Rentals
                             on cu.CustomerId equals r.CustomerId
                             join u in context.Users
                             on cu.UserId equals u.UserId
                             join ca in context.Cars
                             on r.CarId equals ca.CarId
                             join br in context.Brands
                             on ca.BrandId equals br.BrandId
                             select new RentalDetailDto
                             {
                                Id = r.RentId,
                                BrandName =br.BrandName,
                                CustomerName=u.FirstName+" "+ u.LastName,
                                RentDate=r.RentDate,
                                ReturnDate= (DateTime)r.ReturnDate
                            
                             };
                return result.ToList();
            }

        }

    }
}
