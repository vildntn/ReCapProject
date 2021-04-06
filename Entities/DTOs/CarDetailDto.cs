﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailDto :IDto
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public int CarId { get; set; }
        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public int MinFindexScore { get; set; }
        public string ModelYear { get; set; }
    }
}
