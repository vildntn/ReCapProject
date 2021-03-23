using Core.DataAccess.EntitiyFramework;
using DataAccess.Abstact;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>,ICarDal
      {
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (ReCapContext context=new ReCapContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join o in context.Colors
                             on c.ColorId equals o.ColorId
                             //join im in context.CarImages
                             //on c.CarId equals im.CarId
                             select new CarDetailDto
                             {
                                 BrandId=b.BrandId,
                                 CarId=c.CarId,
                                 ColorId=o.ColorId,
                                 BrandName = b.BrandName,
                                 ColorName = o.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ImagePath = (from a in context.CarImages where a.CarId == c.CarId select a.ImagePath).FirstOrDefault(),
                                 ModelYear=c.ModelYear
                                 
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();

            }
        }
      
    }
}
