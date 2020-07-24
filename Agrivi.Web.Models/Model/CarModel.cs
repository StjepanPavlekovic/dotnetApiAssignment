using Agrivi.Web.Models.Manufacturer;

namespace Agrivi.Web.Models.Model
{
    public class CarModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int? Year { get; set; }
        public int? ManufacturerId { get; set; }
        public CarManufacturer Manufacturer { get; set; }
    }
}
