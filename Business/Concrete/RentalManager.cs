using Business.Abstact;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstact;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
        
    {
        IRentalDal _rentalDal;
        ICustomerService _customerService;

        public RentalManager(IRentalDal rentalDal, ICustomerService customerService )
        {
            _rentalDal = rentalDal;
            _customerService = customerService;
        }

        public IResult Add(Rental rental)
        {
            //var result = BusinessRules.Run(CheckIfCarUsage(rental));

          var result = BusinessRules.Run(CheckIfMinFindexScoreEnough(rental.CustomerId));
            if (result ==null)
            {
                return new ErrorResult(result.Message);
            }

            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
             

        }
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalListed);
        }

        public IDataResult<Rental> GetById(int id)
        {
           
            return new SuccessDataResult<Rental>(_rentalDal.Get(r=>r.RentId==id),Messages.RentalListed);
        }

        

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(), Messages.RentalListed);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }


        public IResult CheckIfCarUsage(Rental rental)
        {
            var result = _rentalDal.Get(r => r.CarId == rental.CarId && r.ReturnDate==null);
            if (result==null)
            {
               
                return new SuccessResult();

            }
            
            return new ErrorResult(Messages.RentalUnSuccessful);
        }

        public IResult CheckIfMinFindexScoreEnough(int customerId)
        {
            var result = _customerService.GetById(customerId);
            var newResult = _rentalDal.GetRentalDetails(r => r.MinFindexScore <= result.Data.MinFindexScore).SingleOrDefault();
            if (newResult!=null)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.InsufficientFindeexScore);

        }


    }
}
