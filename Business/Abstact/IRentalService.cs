using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstact
{
    public interface IRentalService
    {
        List<Rental> GetAll();

        Rental GetById(int id);
        void Add(Rental rental);
        void Delete(Rental rental);
        void Update();
    }
}
