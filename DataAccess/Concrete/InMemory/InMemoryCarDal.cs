using DataAccess.Abstact;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>() {
            new Car{ CarId = 1, BrandId = 1, ColorId = 1, DailyPrice = 1500, Description = "Mercedes", ModelYear = "2010" },
            new Car{ CarId = 2, BrandId = 2, ColorId = 1, DailyPrice = 1000, Description = "Range Rover", ModelYear = "2014" },
            new Car { CarId = 3, BrandId = 3, ColorId = 3, DailyPrice = 400, Description = "Bmw", ModelYear = "2011" },
            new Car{ CarId = 4, BrandId = 2, ColorId = 4, DailyPrice = 350, Description = "Audi", ModelYear = "2012" } };
        }
    
       
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToRemoved = _cars.SingleOrDefault(c=> c.CarId == car.CarId);

            _cars.Remove(carToRemoved);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int Id)
        {
            return _cars.Where(c => c.CarId == Id).ToList();
        }

        public Car GetById(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdated = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdated.Description = car.Description;
            carToUpdated.DailyPrice = car.DailyPrice;

        }

    }
}
