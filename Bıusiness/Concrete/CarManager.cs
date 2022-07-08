using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if (car.Description.Length > 2 && car.DailyPrice > 0)

            {
                _carDal.Add(car);
                return new SuccessResult("Ürün Eklendi");
            }

            else
            {
                return new ErrorResult(Messages.CarAdded);
            }
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new Result(true);
        }

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

        public IDataResult<List<Car>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.CarId == carId));
        }

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

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id));
        }

        public IDataResult<List<Car>> GetCarsByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max));
        }

        public IResult Update(Car car)
        {
            //yeni bilgiler
            _carDal.Update(car);
            return new Result(true);
        }
    }
}
