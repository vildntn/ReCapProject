using Business.Abstact;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Abstact;
using Core.Utilities.Results;
using Business.Constants;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            
            if (brand.BrandName.Length > 2)
            {
                _brandDal.Add(brand);
                return new SuccessResult(Messages.BrandAdded);
            }
            return new ErrorResult(Messages.BrandNameInvalid);
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new DataResult<List<Brand>>(_brandDal.GetAll(),Messages.BrandListed,true);
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new DataResult<Brand>(_brandDal.Get(b=>b.BrandId==id),Messages.BrandListed,true);
        }

        public IResult Update(Brand brand)
        {
            throw new NotImplementedException();
        }
    }
}
