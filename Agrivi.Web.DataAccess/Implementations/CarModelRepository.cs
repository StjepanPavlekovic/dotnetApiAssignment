using Agrivi.Web.DataAccess.Interfaces;
using Agrivi.Web.Helpers.Pagination;
using Agrivi.Web.Models.Common;
using Agrivi.Web.Models.Manufacturer;
using Agrivi.Web.Models.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agrivi.Web.DataAccess.Implementations
{
    public class CarModelRepository : ICarModelRepository
    {
        private DataContext _db;
        private MapperConfiguration config;
        IMapper iMapper;

        public CarModelRepository(DataContext db)
        {
            _db = db;

            config = new MapperConfiguration(cfg => {
                cfg.CreateMap<CarModel, CarModelDTO>();
            });
            iMapper = config.CreateMapper();
        }

        public async Task<Page<CarModelDTO>> GetCarModelsAsync(
            int pageNumber = Page.FIRST,
            int pageSize = Page.DEFAULT_SIZE,
            string orderBy = null,
            string name = null,
            int? manufacturerId = null
            )
        {
            IEnumerable<CarModel> carModels = await _db.CarModels.ToListAsync();
            IQueryable<CarModelDTO> modelsQueryable;
            if (manufacturerId != null)
            {
                modelsQueryable = carModels.AsQueryable().Where(x => x.ManufacturerId == manufacturerId).Select(y => MapToDTO(y));
            }
            else
            {
                modelsQueryable = carModels.AsQueryable().Select(x => MapToDTO(x));
            }

            if (orderBy != null)
            {
                modelsQueryable = _OrderCarModels(modelsQueryable, orderBy);
            }

            if (name != null)
            {
                modelsQueryable = modelsQueryable.Where(x => x.Name.ToLower().Contains(name.ToLower()));
            }

            return PaginationHelper.GetPage(modelsQueryable, pageNumber, pageSize);
        }

        public async Task<CarModelDTO> GetCarModelByIdAsync(int id)
        {
            var model = await _db.CarModels.FindAsync(id);
            return MapToDTO(model);
        }

        public async Task<CarModelDTO> CreateCarModelAsync(CarModelCreate data)
        {
            var model = new CarModel
            {
                Name = data.Name,
                Year = data.Year,
                ManufacturerId = data.ManufacturerId
            };

            _db.CarModels.Add(model);
            var saved = await _db.SaveChangesAsync();

            if (saved <= 0)
                throw new Exception("Problem saving data.");

            return MapToDTO(model);
        }

        public async Task<CarModelDTO> UpdateCarModelAsync(CarModelDTO data)
        {
            var model = await _db.CarModels.FindAsync(data.Id);

            model.Name = data.Name ?? model.Name;
            model.Year = data.Year ?? model.Year;
            model.ManufacturerId = data.ManufacturerId ?? model.ManufacturerId;

            var saved = await _db.SaveChangesAsync();

            if (saved <= 0)
                throw new Exception("Problem saving data");

            return MapToDTO(model);
        }

        public async Task DeleteCarModelAsync(int id)
        {
            var model = await _db.CarModels.FindAsync(id);
            _db.CarModels.Remove(model);

            var saved = await _db.SaveChangesAsync();

            if (saved <= 0)
                throw new Exception("Problem saving data");
        }

        private IQueryable<CarModelDTO> _OrderCarModels(IQueryable<CarModelDTO> carModels, string orderBy)
        {
            switch (orderBy.ToLower())
            {
                case "name": return carModels.OrderBy(x => x.Name);
                case "-name": return carModels.OrderByDescending(x => x.Name);
                case "year": return carModels.OrderBy(x => x.Year);
                case "-year": return carModels.OrderByDescending(x => x.Year);
                default: return carModels;
            }
        }

        private CarModelDTO MapToDTO(CarModel carModel)
        {
            return iMapper.Map<CarModel, CarModelDTO>(carModel);
        }
    }
}
