using Agrivi.Web.Models.Manufacturer;
using Agrivi.Web.Models.Model;
using System.Collections.Generic;
using System.Linq;

namespace Agrivi.Web.DataAccess
{
    public class Seed
    {
        public static void SeedData(DataContext context)
        {
            if (!context.CarManufacturers.Any())
            {
                var manufacturers = new List<CarManufacturer>
                {
                    new CarManufacturer
                    {
                        Name = "Audi",
                        Website = "https://www.audi.com/"
                    },
                    new CarManufacturer
                    {
                        Name = "Aston Martin",
                        Website = "https://www.astonmartin.com/"
                    },
                    new CarManufacturer
                    {
                        Name = "BMW",
                        Website = "https://www.bmw.com/"
                    },
                    new CarManufacturer
                    {
                        Name = "Cadillac",
                        Website = "https://www.cadillac.com/"
                    },
                    new CarManufacturer
                    {
                        Name = "Chrysler",
                        Website = "https://www.chrysler.com/"
                    },
                    new CarManufacturer
                    {
                        Name = "Dodge",
                        Website = "https://www.dodge.com/"
                    },
                    new CarManufacturer
                    {
                        Name = "Dacia",
                        Website = "https://www.dacia.hr/"
                    },
                    new CarManufacturer
                    {
                        Name = "Ferrari",
                        Website = "https://www.ferrari.com/"
                    },
                    new CarManufacturer
                    {
                        Name = "Honda",
                        Website = "https://www.honda.com/"
                    },
                    new CarManufacturer
                    {
                        Name = "Hyundai",
                        Website = "https://www.hyundai.com/"
                    },
                    new CarManufacturer
                    {
                        Name = "Lotus",
                        Website = "https://www.lotuscars.com/"
                    },
                    new CarManufacturer
                    {
                        Name = "Mazda",
                        Website = "https://www.mazda.com/"
                    },
                    new CarManufacturer
                    {
                        Name = "Nissan",
                        Website = "https://www.nissan-global.com/"
                    },
                    new CarManufacturer
                    {
                        Name = "Opel",
                        Website = "https://www.opel.com/"
                    },
                    new CarManufacturer
                    {
                        Name = "Suzuki",
                        Website = "https://www.globalsuzuki.com/"
                    }
                };

                var carModels = new List<CarModel>
                {
                    //Audi
                    new CarModel
                    {
                        ManufacturerId = 1,
                        Name = "R8",
                        Year = 2010
                    },
                    new CarModel
                    {
                        ManufacturerId = 1,
                        Name = "A6",
                        Year = 2010
                    },
                    //Aston Martin
                    new CarModel
                    {
                        ManufacturerId = 2,
                        Name = "DB9",
                        Year = 2006
                    },
                    //BMW
                    new CarModel
                    {
                        ManufacturerId = 3,
                        Name = "M3 GTR",
                        Year = 2001
                    },
                    new CarModel
                    {
                        ManufacturerId = 3,
                        Name = "X6",
                        Year = 2008
                    },
                    //Cadillac
                    new CarModel
                    {
                        ManufacturerId = 4,
                        Name = "CT5",
                        Year = 2020
                    },
                    //Chrysler
                    new CarModel
                    {
                        ManufacturerId = 5,
                        Name = "Voyager",
                        Year = 1988
                    },
                    //Dodge
                    new CarModel
                    {
                        ManufacturerId = 6,
                        Name = "Viper",
                        Year = 1996
                    },
                    //Dacia
                    new CarModel
                    {
                        ManufacturerId = 7,
                        Name = "Logan",
                        Year = 2004
                    },
                    //Ferrari
                    new CarModel
                    {
                        ManufacturerId = 8,
                        Name = "F40",
                        Year = 1992
                    },
                    //Honda
                    new CarModel
                    {
                        ManufacturerId = 9,
                        Name = "Civic Sedan",
                        Year = 2010
                    },
                    //Hyundai
                    new CarModel
                    {
                        ManufacturerId = 10,
                        Name = "i30",
                        Year = 2006
                    },
                    //Lotus
                    new CarModel
                    {
                        ManufacturerId = 11,
                        Name = "Elise",
                        Year = 1996
                    },
                    //Mazda
                    new CarModel
                    {
                        ManufacturerId = 12,
                        Name = "RX-8",
                        Year = 1999
                    },
                    new CarModel
                    {
                        ManufacturerId = 12,
                        Name = "MX-5",
                        Year = 2001
                    },
                    //Nissan
                    new CarModel
                    {
                        ManufacturerId = 13,
                        Name = "Skyline GTR",
                        Year = 2001
                    },
                    new CarModel
                    {
                        ManufacturerId = 13,
                        Name = "350z",
                        Year = 2002
                    },
                    //Opel
                    new CarModel
                    {
                        ManufacturerId = 14,
                        Name = "Zafira",
                        Year = 2006
                    },
                    new CarModel
                    {
                        ManufacturerId = 14,
                        Name = "Astra",
                        Year = 2008
                    },
                    new CarModel
                    {
                        ManufacturerId = 14,
                        Name = "Mokka",
                        Year = 2017
                    },
                    //Suzuki
                    new CarModel
                    {
                        ManufacturerId = 15,
                        Name = "Swift",
                        Year = 2019
                    }
                };
                context.CarManufacturers.AddRange(manufacturers);
                context.CarModels.AddRange(carModels);
                context.SaveChanges();
            }
        }
    }
}
