using System;
using System.Collections.Generic;
using Entities.Concrete;
using System.Text;
using Core.Utilities.Results;

namespace Business.Abstact
{
    interface IColorService
    {
        IDataResult<List<Color>> GetAll();

        IDataResult<Color> GetById(int id);

    }
}
