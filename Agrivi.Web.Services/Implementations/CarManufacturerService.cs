using Agrivi.Web.DataAccess.Interfaces;
using Agrivi.Web.Models.Common;
using Agrivi.Web.Models.Manufacturer;
using Agrivi.Web.Services.Interfaces;
using System.Threading.Tasks;

namespace Agrivi.Web.Services.Implementations
{
    public class CarManufacturerService : ICarManufacturerService
    {
        IManufacturerRepository manufacturerRepository;

        public CarManufacturerService(IManufacturerRepository manufacturerRepository)
        {
            this.manufacturerRepository = manufacturerRepository;
        }


        public async Task<Page<CarManufacturerDTO>> GetManufacturersAsync(
            int pageNumber = Page.FIRST,
            int pageSize = Page.DEFAULT_SIZE,
            string orderBy = null,
            string name = null)
        {
            return await manufacturerRepository.GetManufacturersAsync(
                pageNumber,
                pageSize,
                orderBy,
                name);
        }
        public async Task<CarManufacturerDTO> GetManufacturerByIdAsync(int id)
        {
            return await manufacturerRepository.GetManufacturerByIdAsync(id);
        }
        public async Task<CarManufacturerDTO> UpdateManufacturerAsync(
            CarManufacturerDTO manufacturer)
        {
            return await manufacturerRepository.UpdateManufacturerAsync(manufacturer);
        }

        public async Task<CarManufacturerDTO> CreateManufacturerAsync(CarManufacturerCreate manufacturer)
        {
            return await manufacturerRepository.CreateManufacturerAsync(manufacturer);
        }

        public async Task DeleteManufacturerAsync(int id)
        {
            await manufacturerRepository.DeleteManufacturerAsync(id);
        }
    }
}
