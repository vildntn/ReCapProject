using Business.Abstact;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstact;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if (car.DailyPrice > 0)
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);
            }
            return new ErrorResult(Messages.UnSuccessful);
        }

        public IDataResult<List<Car>> GetAll()
        {
         
            return new DataResult<List<Car>>(_carDal.GetAll(),Messages.CarListed,true);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new DataResult<List<CarDetailDto>>(_carDal.GetCarDetails(),Messages.CarListed,true);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new DataResult <List<Car >>( _carDal.GetAll(p => p.BrandId == id),Messages.CarListed,true);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new DataResult<List<Car>> (_carDal.GetAll(p => p.ColorId == id),Messages.CarListed,true);
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}
