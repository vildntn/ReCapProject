using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstact
{
    interface ICarService
    {
        List<Car> GetAll();
        List<Car> GetCarsByBrandId(int id);
        List<Car> GetCarsByColorId(int id);
        void Add(Car car);
        void Update();
        List<CarDetailDto> GetCarDetails();





    }
}
