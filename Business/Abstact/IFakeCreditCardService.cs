using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstact
{
    public interface IFakeCreditCardService
    {
        IResult Add(FakeCreditCard fakeCreditCard);
        IResult Update(FakeCreditCard fakeCreditCard);
        IResult Delete(FakeCreditCard fakeCreditCard);

        IDataResult<List<FakeCreditCard>> GetAll();
    
        IDataResult<FakeCreditCard> GetById(int id);

    }
}
