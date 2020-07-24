using Agrivi.Web.Models.Model;
using System.Collections.Generic;

namespace Agrivi.Web.Models.Manufacturer
{
    public class CarManufacturer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }
        public List<CarModel> CarModels { get; set; }
    }
}
