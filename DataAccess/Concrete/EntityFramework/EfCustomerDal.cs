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
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCapContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from customer in context.Customers
                             join user in context.Users
                             on customer.UserId equals user.UserId
                             select new CustomerDetailDto
                             {
                                 Id = customer.CustomerId,
                                 CustomerName = $@"{user.FirstName}{user.LastName}",
                                 CompanyName=customer.CompanyName
                             };
                  return result.ToList();
            }
        }
    }
}
