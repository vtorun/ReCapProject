using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Core.Aspects.Autofac.Validation;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }



        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.Deleted);
        }

        [SecuredOperation("car.add,admin,user")]
        public IDataResult<List<Color>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<Color>>(_colorDal.GetAll());
            }
        }

        public IDataResult<List<Color>> GetByColorId(int colorId)
        {
            try
            {
                return new SuccessDataResult<List<Color>>(_colorDal.GetAll(c => c.ColorId == colorId));
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<Color>>(_colorDal.GetAll(c => c.ColorId == colorId));
            }
        }



        [ValidationAspect(typeof(ColorValidator))]
        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Messages.Updated);
        }


    }
}
