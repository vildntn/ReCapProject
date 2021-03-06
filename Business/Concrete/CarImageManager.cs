﻿using Business.Abstact;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstact;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;


        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckCarImageLimit(carImage));
            if (result != null)
            {
                return result;
            }
            var imageResult = FileHelper.Add(file);
            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }

            carImage.ImagePath = imageResult.Message;
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            FileHelper.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckCarImageLimit(carImage));
            if (result != null)
            {
                return result;
            }
            var imagePath = FileHelper.Update(file, _carImageDal.Get(c => c.CarId == carImage.CarId).ImagePath);
            if (!imagePath.Success)
            {
                return new ErrorResult(imagePath.Message);
            }
            carImage.ImagePath = imagePath.Message;
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarImageListed);
        }
        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == id));
        }

        private List<CarImage> CheckIfCarImageNotExist(int carId)
        {
            string path = @"\CarImages\rentacars.jpg".Replace("\\", "/");
            var result = _carImageDal.GetAll(c => c.CarId == carId);
            if (!result.Any())
            {
                return new List<CarImage> { new CarImage { CarId = carId, ImagePath = path , Date=DateTime.Now} };
                
            }
            return result;
        }


        private IResult CheckCarImageLimit(CarImage carImage)
        {

            var result = _carImageDal.GetAll(c => c.CarId == carImage.CarId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitet);
            }
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetImageByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNotExist(carId));
        }
    }
  
}
