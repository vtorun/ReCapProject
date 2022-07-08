using Business.Abstract;
using DataAccess.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Constants;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            //var result = _rentalDal.Get(r => r.CarId == rental.CarId && r.ReturnDate == null);
            //if (result == null)
            //{
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.Added);
            //}
            //return new ErrorResult(Messages.NotAdded);
        }

        public IResult Delete(Rental rental)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<Rental>>(_rentalDal.GetAll());
            }
        }

        public IDataResult<List<Rental>> GetByCarId(int carId)
        {
            try
            {
                return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.CarId == carId));
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<Rental>>(Messages.NotGetAll);
            }
        }

        public IResult Update(Rental rental)
        {
            throw new NotImplementedException();
        }
    }
}
