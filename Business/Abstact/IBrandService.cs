using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstact
{
    interface IBrandService
    {
        List<Brand> GetAll();

        Brand GetById(int id);
        void Add(Brand brand);
        void Update();

    }
}
