using Business.Abstact;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstact;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        public IDataResult<List<Color>> GetAll()
        {
            return new DataResult<List<Color>>(_colorDal.GetAll(),Messages.ColorListed,true);
        }

        public IDataResult<Color> GetById(int id)
        {
            return new DataResult<Color>(_colorDal.Get(c=>c.ColorId==id),Messages.ColorListed,true);
        }
    }
}
