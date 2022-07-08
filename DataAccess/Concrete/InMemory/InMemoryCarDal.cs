using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
            new Car() { CarId = 1,BrandId=1,ColorId=2,ModelYear=2022,DailyPrice=1000000 ,Description="Mercedes"},
            new Car() { CarId = 2,BrandId=2,ColorId=3,ModelYear=2015,DailyPrice=2000000 ,Description="AUDI"},
            new Car() { CarId = 3,BrandId=3,ColorId=1,ModelYear=2017,DailyPrice=3000000 ,Description="BMW"},
            new Car() { CarId = 4,BrandId=4,ColorId=4,ModelYear=2013,DailyPrice=5500000 ,Description="BUGATTI"},
            new Car() { CarId = 4,BrandId=5,ColorId=5,ModelYear=2018,DailyPrice=4800000 ,Description="PORCHE"},
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(p => p.CarId == id).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
