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
    public class PaymentManager : IPaymentService
    {
        ICreditCardDal _creditCard;

        public PaymentManager(ICreditCardDal creditCard)
        {
            _creditCard = creditCard;
        }

        public IResult IsCreditCardExist(CreditCard creditCard)
        {
            //var result = _creditCard.Get(
            //    f => f.NameOnTheCard == creditCard.NameOnTheCard &&
            //    f.CardNumber == creditCard.CardNumber &&
            //    f.CardCvv == creditCard.CardCvv &&
            //    f.ExpirationMonth == creditCard.ExpirationMonth &&
            //    f.ExpirationYear == creditCard.ExpirationYear);
            //if (result != null)
            //{
            //    return new SuccessResult(Messages.SuccessfulPayment);
            //}
            //return new ErrorResult(Messages.WrongCreditCardInformation);
            return new SuccessResult(Messages.SuccessfulPayment);

        }

    }
}
