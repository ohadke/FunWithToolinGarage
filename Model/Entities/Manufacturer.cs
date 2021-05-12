﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsAndManufacturers2.Model.Entities
{
    public record Manufacturer(
        string Name, 
        string Country,
        int Year
        );
}
