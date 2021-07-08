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
            //CarManager carManager = new CarManager(new EfCarDal());

            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine("{0} / {1} / {2}" , car.CarId, car.DailyPrice ,car.Description);
            //}

            //ADUTest();

            // CarTest();

            //BrandTest();

        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var Brand in brandManager.GetAll())
            {
                Console.WriteLine(Brand.BrandName);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var Car in carManager.GetCarDetailDtos())
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
