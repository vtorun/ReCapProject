using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Core.Aspects.Autofac.Validation;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult("Ürün Eklendi");
        }


        [SecuredOperation("car.delete,admin")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult("Ürün Silindi");
        }
        [SecuredOperation("car.getall,admin")]
        public IDataResult<List<Car>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<Car>>(_carDal.GetAll());
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<Car>>(_carDal.GetAll());
            }

        }
        [SecuredOperation("car.getall,admin")]
        public IDataResult<List<Car>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.CarId == carId));
        }
        [SecuredOperation("car.getall,admin")]
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            //try
            //{
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
            //}
            //catch (Exception)
            //{

            //    return new ErrorDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
            //}

        }
        [SecuredOperation("car.getall,admin")]
        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id));
        }
        [SecuredOperation("car.getall,admin")]
        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id));
        }
        [SecuredOperation("car.getall,admin")]
        public IDataResult<List<Car>> GetCarsByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max));
        }


        [SecuredOperation("car.update,admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            //yeni bilgiler
            _carDal.Update(car);
            return new Result(true);
        }
    }
}
