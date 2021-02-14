using Business.Abstact;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Abstact;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void Add(Brand brand)
        {
            
            if (brand.BrandName.Length > 2)
            {
                _brandDal.Add(brand);
                Console.WriteLine("Araç markası eklendi.");
            }
            else
            {
                Console.WriteLine("Marka 2 karakterden büyük olmalıdır.");
            }
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public Brand GetById(int id)
        {
            return _brandDal.Get(b=>b.BrandId==id);
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
