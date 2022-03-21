﻿using AppCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DAL.Dto.Car
{
    public class AddCarDto : IDto
    {
        public string CarName { get; set; }
        public string ModelName { get; set; }
        public string Color { get; set; }
        public int BranhcId { get; set; }
    }
}
