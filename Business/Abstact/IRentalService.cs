using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstact
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<RentalDetailDto>> GetRentalDetails();


        IResult Add(Rental rental);
        IResult Delete(Rental rental);
        IResult Update(Rental rental);
        IDataResult<Rental> GetById(int id);
        IResult CheckIfCarUsage(Rental rental);
        IResult CheckIfMinFindexScoreEnough(int customerId);
    }
}
