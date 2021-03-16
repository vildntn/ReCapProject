using System;
using Entities.Concrete;
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Abstact;
using Core.Entities.Concreate;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            UserManager userManager = new UserManager(new EfUserDal());
            //User user1 = new User
            //{
            //    FirstName = "Ece2",
            //    LastName = "Önsöz",
            //};
            //userManager.Add(user1);

            AddCustomer(userManager);
            //RentalCar(rentalManager);

            //Brand addBrand = new Brand() { BrandName="Isuzu"};
            //Color addColor = new Color()
            //{
            //    ColorName = "Yeşil"
            //};
            //Rental addRental = new Rental()
            //{
            //    CarId = 7,
            //    CustomerId = 2,
            //    RentDate = DateTime.Now,
            //    ReturnDate =null
            //};
            //GetAllCar(carManager);




        }

        public static void GetAllCar(CarManager carManager)
        {
            foreach (var result in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(result.BrandName);
            }
                
        }
        public static void AddCustomer(UserManager userManager)
        {
            Console.WriteLine("Please enter your first name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Please enter your last name: ");
            string lastName = Console.ReadLine();

            User user2 = new User()
            {
                FirstName = firstName,
                LastName = lastName,
            };
            userManager.Add(user2);
            foreach (var result in userManager.GetAll().Data)
            {
                Console.WriteLine(result.FirstName+" "+result.LastName);

            } 
        }
        public static void RentalCar(RentalManager rentalManager)
        {
            Console.WriteLine("Car Id: ");
            int carId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Customer Id: ");
            int customerId = Convert.ToInt32(Console.ReadLine());

            Rental newRental = new Rental
            {
                CarId = carId,
                CustomerId = customerId,
                RentDate = DateTime.Now,
                ReturnDate = null,
            };
            Console.WriteLine(rentalManager.Add(newRental).Message);
        }
    }
}
