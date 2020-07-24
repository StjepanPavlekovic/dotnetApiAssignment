using Agrivi.Web.DataAccess.Interfaces;
using Agrivi.Web.Models.Common;
using Agrivi.Web.Models.Model;
using Agrivi.Web.Services.Interfaces;
using System.Threading.Tasks;

namespace Agrivi.Web.Services.Implementations
{
    public class CarModelService : ICarModelService
    {
        ICarModelRepository carModelRepository;

        public CarModelService(ICarModelRepository carModelRepository)
        {
            this.carModelRepository = carModelRepository;
        }

        public async Task<CarModelDTO> CreateCarModelAsync(CarModelCreate data)
        {
            return await carModelRepository.CreateCarModelAsync(data);
        }

        public async Task DeleteCarModelAsync(int id)
        {
            await carModelRepository.DeleteCarModelAsync(id);
        }

        public async Task<Page<CarModelDTO>> GetCarModelsAsync(
            int pageNumber = Page.FIRST, 
            int pageSize = Page.DEFAULT_SIZE, 
            string orderBy = null, 
            string name = null, 
            int? manufacturerId = null)
        {
            return await carModelRepository.GetCarModelsAsync(
                pageNumber,
                pageSize,
                orderBy,
                name,
                manufacturerId
                );
        }

        public async Task<CarModelDTO> GetCarModelByIdAsync(int id)
        {
            return await carModelRepository.GetCarModelByIdAsync(id);
        }

        public async Task<CarModelDTO> UpdateCarModelAsync(CarModelDTO data)
        {
            return await carModelRepository.UpdateCarModelAsync(data);
        }
    }
}
