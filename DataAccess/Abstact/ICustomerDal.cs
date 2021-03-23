using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstact
{
    public interface ICustomerDal:IEntityRepository<Customer>
    {
       List<CustomerDetailDto> GetCustomerDetails();
    }
}
