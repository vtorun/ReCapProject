using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            try
            {
                _customerDal.Add(customer);
                return new SuccessResult(Messages.Added);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.NotAdded);
            }
        }

        public IResult Delete(Customer customer)
        {
            try
            {
                _customerDal.Delete(customer);
                return new SuccessResult(Messages.Deleted);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.NotDeleted);
            }
        }

        public IDataResult<List<Customer>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<Customer>>(Messages.NotGetAll);
            }
        }

        public IDataResult<List<Customer>> GetByCustomerId(int customerId)
        {
            try
            {
                return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(c => c.UserId == customerId));
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<Customer>>(Messages.NotGetAll);
            }
        }

        public IResult Update(Customer customer)
        {
            try
            {
                _customerDal.Update(customer);
                return new SuccessResult(Messages.Updated);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.Updated);
            }
        }
    }
}
