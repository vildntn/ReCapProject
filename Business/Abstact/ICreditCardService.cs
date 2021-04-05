using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstact
{
    public interface ICreditCardService
    {
        IResult Add(CreditCard CreditCard);
        IResult Update(CreditCard CreditCard);
        IResult Delete(CreditCard CreditCard);

        IDataResult<List<CreditCard>> GetAll();
    
        IDataResult<CreditCard> GetById(int id);
        IResult IsCreditCardExist(CreditCard creditCard);

    }
}
