using Business.Abstact;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstact;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CreditCardManager : ICreditCardService
    {
        ICreditCardDal _creditCard;

        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCard = creditCardDal;
        }

        public IResult Add(CreditCard creditCardDal)
        {
            _creditCard.Add(creditCardDal);
            return new SuccessResult(Messages.fakeCreditCard);

        }

        public IResult Delete(CreditCard creditCardDal)
        {
            _creditCard.Delete(creditCardDal);
            return new SuccessResult();
        }

        public IDataResult<List<CreditCard>> GetAll()
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCard.GetAll());
        }

        public IDataResult<CreditCard> GetById(int id)
        {
            return new SuccessDataResult<CreditCard>(_creditCard.Get(f => f.Id == id));
        }

        public IResult Update(CreditCard creditCardDal)
        {
            _creditCard.Update(creditCardDal);
            return new SuccessResult();
        }

       
    }
}
