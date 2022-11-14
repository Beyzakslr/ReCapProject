using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Linq;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal:EfEntityRepositoryBase<Rental,ReCapProjectContext>,IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetailsDtos()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from ca in context.Cars
                             join b in context.Brands
                             on ca.BrandId equals b.BrandId
                             join re in context.Rentals
                             on ca.CarId equals re.CarId
                             join co in context.Colors
                             on ca.ColorId equals co.ColorId
                             from u in context.Users
                             join cu in context.Customers
                             on u.UserId equals cu.UserId
                             select new RentalDetailDto
                             {
                                 CarId = ca.CarId,
                                 BrandId = b.BrandId,
                                 ColorName = co.ColorName,
                                 BrandName = b.BrandName,
                                 ModelName = ca.ModelName,
                                 RentalId = re.RentalId,
                                 RentDate = re.RentDate,
                                 ReturnDate = re.ReturnDate,
                                 CustomerName = u.FirstName,
                                 CustomerLastname = u.LastName

                             };
                return result.ToList();
            }
        }

    }
}
