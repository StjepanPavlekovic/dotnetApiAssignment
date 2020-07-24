using Agrivi.Web.Models.Common;
using Agrivi.Web.Models.Manufacturer;
using System.Threading.Tasks;

namespace Agrivi.Web.DataAccess.Interfaces
{
    public interface IManufacturerRepository
    {
        Task<Page<CarManufacturerDTO>> GetManufacturersAsync(
            int pageNumber = Page.FIRST,
            int pageSize = Page.DEFAULT_SIZE,
            string orderBy = null,
            string name = null);
        Task<CarManufacturerDTO> GetManufacturerByIdAsync(int id);

        Task<CarManufacturerDTO> UpdateManufacturerAsync(CarManufacturerDTO data);

        Task<CarManufacturerDTO> CreateManufacturerAsync(CarManufacturerCreate data);
        Task DeleteManufacturerAsync(int id);
    }
}
