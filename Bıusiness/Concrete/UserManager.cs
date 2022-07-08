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
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            try
            {
                return new SuccessResult(Messages.Added);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.NotAdded);
            }
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            try
            {
                return new SuccessResult(Messages.Deleted);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.NotDeleted);
            }
        }

        public IDataResult<List<User>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<User>>(_userDal.GetAll());
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<User>>(_userDal.GetAll());
            }
        }

        public IDataResult<List<User>> GetByUserId(int userId)
        {
            try
            {
                return new SuccessDataResult<List<User>>(_userDal.GetAll(u => u.UserId == userId));
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<User>>(_userDal.GetAll(u => u.UserId == userId));
            }
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            try
            {
                return new SuccessResult(Messages.Updated);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.NotUpdated);
            }
        }
    }
}
