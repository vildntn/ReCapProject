using Business.Abstact;
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
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.CarId == id));
        }

        private IDataResult<List<CarImage>> CheckIfCarImageNotExist(int id)
        {
            string path = "\\wwwroot\\CarImages\\RentACar.png";
            var result = _carImageDal.GetAll(c => c.Id == id).Any();
            if (!result)
            {
                List<CarImage> defaultCarImage = new List<CarImage> { new CarImage { CarId = id, ImagePath = path, Date = DateTime.Now } };
                return new SuccessDataResult<List<CarImage>>(defaultCarImage);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == id));
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


    }
  
}
