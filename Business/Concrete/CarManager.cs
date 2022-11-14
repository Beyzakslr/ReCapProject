

using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.CCS;





namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Car car)
        {

            

            _carDal.Add(car);
            
            return new Result(true, "Araba eklendi");
        }

        public IResult Delete(Car car)
        {
            IResult result = BusinessRules.Run(CheckCardIdExist(car.CarId));

            if (result != null)
            {
                return result;
            }

            _carDal.Delete(car);
            return new SuccessResult(Messages.CarAdded);
        }

        //[CacheAspect]
        //[PerformanceAspect(5)]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(), Messages.CarListed);
           
        }

        public IDataResult<List<Car>> GetById(int carId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.CarId == carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailDtos()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailDtos());
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByCarId(int carId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByColorAndByBrand(int colorId, int brandId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int Brandid)
        {
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(c => c.BrandId == Brandid),Messages.CarListedByBrand);
        }      

        public IDataResult<List<Car>> GetCarsByColorId(int Colorid)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == Colorid),Messages.CarListedByColor);
        }

        
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            IResult result = BusinessRules.Run(CheckCardIdExist(car.CarId));

            if (result != null)
            {
                return result;
            }

            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        private IResult[] CheckCardIdExist(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
