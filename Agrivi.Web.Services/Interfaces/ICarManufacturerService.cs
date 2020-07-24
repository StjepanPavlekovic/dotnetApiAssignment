using Agrivi.Web.Models.Common;
using Agrivi.Web.Models.Manufacturer;
using System.Threading.Tasks;

namespace Agrivi.Web.Services.Interfaces
{
    public interface ICarManufacturerService
    {
        Task<Page<CarManufacturerDTO>> GetManufacturersAsync(
            int pageNumber = Page.FIRST,
            int pageSize = Page.DEFAULT_SIZE,
            string orderBy = null,
            string name = null);
        Task<CarManufacturerDTO> GetManufacturerByIdAsync(int id);
        Task<CarManufacturerDTO> UpdateManufacturerAsync(CarManufacturerDTO manufacturer);
        Task<CarManufacturerDTO> CreateManufacturerAsync(CarManufacturerCreate manufacturer);
        Task DeleteManufacturerAsync(int id);

    }
}
