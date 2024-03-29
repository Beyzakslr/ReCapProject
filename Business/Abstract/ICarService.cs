﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetById(int CarId);
        IDataResult<List<Car>> GetCarsByBrandId(int Brandid);
        IDataResult<List<Car>> GetCarsByColorId(int Colorid);
        IDataResult<List<CarDetailDto>> GetCarDetailDtos();

        IDataResult<List<CarDetailDto>> GetCarDetailsByCarId(int carId);

        IDataResult<List<CarDetailDto>> GetCarDetailsByColorAndByBrand(int colorId, int brandId);

    }
}
