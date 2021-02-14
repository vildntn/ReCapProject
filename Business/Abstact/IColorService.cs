using System;
using System.Collections.Generic;
using Entities.Concrete;
using System.Text;

namespace Business.Abstact
{
    interface IColorService
    {
        List<Color> GetAll();

        Color GetById(int id);

    }
}
