using Business.Abstract;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {

        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(CarImage carImage)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<CarImage> GetByImageId(int imageId)
        {
            throw new NotImplementedException();
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            throw new NotImplementedException();
        }
    }
}
