using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsAndManufacturers2.Model
{
    public record Car(
            int Year,
            string Make,
            string Model,
            double Displacement,
            int Cylinders,
            int CityFe,
            int HighwayFe,
            int CombinedFe,
            Guid Id
        );
    
}
