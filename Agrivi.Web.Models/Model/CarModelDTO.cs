using System.ComponentModel.DataAnnotations;

namespace Agrivi.Web.Models.Model
{
    public class CarModelDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        public int? Year { get; set; }
        [Required(ErrorMessage = "ManufacturerId is required.")]
        public int? ManufacturerId { get; set; }
    }
}
