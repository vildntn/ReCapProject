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
    public class FakeCreditCardManager : IFakeCreditCardService
    {
        IFakeCreditCardDal _fakeCreditCardDal;

        public FakeCreditCardManager(IFakeCreditCardDal fakeCreditCardDal)
        {
            _fakeCreditCardDal = fakeCreditCardDal;
        }

        public IResult Add(FakeCreditCard fakeCreditCard)
        {
            _fakeCreditCardDal.Add(fakeCreditCard);
            return new SuccessResult();

        }

        public IResult Delete(FakeCreditCard fakeCreditCard)
        {
            _fakeCreditCardDal.Delete(fakeCreditCard);
            return new SuccessResult();
        }

        public IDataResult<List<FakeCreditCard>> GetAll()
        {
            return new SuccessDataResult<List<FakeCreditCard>>(_fakeCreditCardDal.GetAll());
        }

        public IResult IsCreditCardExist(FakeCreditCard fakeCreditCard)
        {
            throw new NotImplementedException();
        }

        public IResult Update(FakeCreditCard fakeCreditCard)
        {
            _fakeCreditCardDal.Update(fakeCreditCard);
            return new SuccessResult();
        }
    }
}
