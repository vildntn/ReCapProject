using System;
using Entities.Concrete;
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Abstact;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
            foreach (var car in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine($"{car.CarId}\t{colorManager.GetById(car.ColorId).ColorName}\t\t{brandManager.GetById(car.BrandId).BrandName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
            }
            foreach (var car in carManager.GetCarsByColorId(1))
            {
                Console.WriteLine($"{car.CarId}\t{colorManager.GetById(car.ColorId).ColorName}\t\t{brandManager.GetById(car.BrandId).BrandName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
            }
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.BrandName+" \t"+ car.ColorName+" \t"+car.DailyPrice+" \t"+ car.Description);
            }
        }
    }
}
