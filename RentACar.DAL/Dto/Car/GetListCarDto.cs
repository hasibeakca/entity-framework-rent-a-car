﻿using AppCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DAL.Dto.Car
{
    public class GetListCarDto : IDto
    {
        public int Id { get; set; }
        public string CarName { get; set; }
        public string ModelName { get; set; }
        public string Color { get; set; }
        public string BranchName { get; set; }
    }
}
