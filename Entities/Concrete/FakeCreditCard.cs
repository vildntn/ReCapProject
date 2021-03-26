using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class FakeCreditCard:IEntity
    {
        public int Id { get; set; }
        public string NameOnTheCard { get; set; }
        public string Expiration { get; set; }
        public string CardNumber { get; set; }
        public int CardCvv { get; set; }
        public decimal Money { get; set; }

    }
}
