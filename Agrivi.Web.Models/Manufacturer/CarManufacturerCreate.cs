using System.ComponentModel.DataAnnotations;

namespace Agrivi.Web.Models.Manufacturer
{
    public class CarManufacturerCreate
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        public string Website { get; set; }
    }
}
