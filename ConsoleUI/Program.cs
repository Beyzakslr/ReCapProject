using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test();

            //ADUTest();

            // CarTest();

            //BrandTest();

            //CustomerTest();

            //ColorTest();

            //UserTest();

            //RentalTest();



        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetAll();

            if (result.Success == true)
            {
                foreach (var rental in result.Data)
                {
                    Console.WriteLine(rental.RentalId + " : " + rental.CarId + " : " + rental.CustomerId + " : " + rental.RentDate + " : " + rental.ReturnDate);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Add(new User { Email = "eng@hotmail.com", FirstName = "Engin", LastName = "Demiroğ", Passaword = "44444" });
            userManager.Add(new User { Email = "szy@hotmail.com", FirstName = "Sezai", LastName = "Karakoç", Passaword = "123" });
            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine(user.FirstName);
            }
        }

        private static void NewMethod()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine("{0} / {1} / {2}", car.CarId, car.DailyPrice, car.Description);
            }
        }

        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(new Customer

            {
                UserId = 3,
                CompanyName = "DTMB"
            });
            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine(customer.CompanyName);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { ColorName = "Purple" });
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }
        }


        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var Brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(Brand.BrandName);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var Car in carManager.GetCarDetailDtos().Data)
            {
                Console.WriteLine(Car.BrandName + "/" + Car.ColorName);
            }
        }

        private static CarManager ADUTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car
            {

                BrandId = 5,
                ColorId = 6,
                ModelYear = 2013,
                DailyPrice = 1500,
                Description = "İstanbul"
            });

            carManager.Delete(new Car { CarId = 14 });
            carManager.Update(new Car
            {
                BrandId = 5,
                CarId = 13,
                ColorId = 2,
                DailyPrice = 1800,
                ModelYear = 2015,
                Description = "İzmir"


            });
            return carManager;
        }
    }
}
