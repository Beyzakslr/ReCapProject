﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car {CarId=1, BrandId=1, ColorId=1, DailyPrice=1500, ModelYear=2012, Description="Ototmatik, Benzin"},
            new Car { CarId = 2, BrandId = 5, ColorId = 6, DailyPrice = 1400, ModelYear = 2010, Description = "manuel, dizel" },
            new Car { CarId = 3, BrandId = 3, ColorId = 5, DailyPrice = 1300, ModelYear = 2009, Description = "Ototmatik, Benzin" },
            new Car { CarId = 4, BrandId = 2, ColorId = 2, DailyPrice = 1200, ModelYear = 2008, Description = "manuel, dizel" },
            new Car { CarId = 5, BrandId = 1, ColorId = 4, DailyPrice = 1000, ModelYear = 2005, Description = "Ototmatik, Benzin" }

            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.CarId = carToUpdate.CarId;
            carToUpdate.ColorId = carToUpdate.ColorId;
            carToUpdate.BrandId = carToUpdate.BrandId;
        }


        public List<Car> GetAllByColor(int colorId)
        {
            return _cars.Where(c => c.ColorId == colorId).ToList();
        }

        public List<Car> GetAllByColor()
        {
            throw new NotImplementedException();
        }
    }

}