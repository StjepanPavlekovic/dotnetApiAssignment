using Agrivi.Web.Models.Common;
using Agrivi.Web.Models.Model;
using System.Threading.Tasks;

namespace Agrivi.Web.Services.Interfaces
{
    public interface ICarModelService
    {
        Task<Page<CarModelDTO>> GetCarModelsAsync(
            int pageNumber = Page.FIRST,
            int pageSize = Page.DEFAULT_SIZE,
            string orderBy = null,
            string name = null,
            int? manufacturerId = null);
        Task<CarModelDTO> GetCarModelByIdAsync(int id);
        Task<CarModelDTO> CreateCarModelAsync(CarModelCreate data);
        Task<CarModelDTO> UpdateCarModelAsync(CarModelDTO data);
        Task DeleteCarModelAsync(int id);
    }
}
