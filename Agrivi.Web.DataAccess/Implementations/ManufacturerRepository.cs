using Agrivi.Web.DataAccess.Interfaces;
using Agrivi.Web.Helpers.Pagination;
using Agrivi.Web.Models.Common;
using Agrivi.Web.Models.Manufacturer;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agrivi.Web.DataAccess.Implementations
{
    public class ManufacturerRepository : IManufacturerRepository
    {
        private DataContext _db;
        private MapperConfiguration config;
        IMapper iMapper;

        public ManufacturerRepository(DataContext db)
        {
            _db = db;

            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CarManufacturer, CarManufacturerDTO>();
            });
            iMapper = config.CreateMapper();
        }

        public async Task<Page<CarManufacturerDTO>> GetManufacturersAsync(
            int pageNumber = Page.FIRST,
            int pageSize = Page.DEFAULT_SIZE,
            string orderBy = null,
            string name = null
            )
        {
            IEnumerable<CarManufacturer> carManufacturers = await _db.CarManufacturers.ToListAsync();
            IQueryable<CarManufacturerDTO> manufacturersQueryable = carManufacturers.AsQueryable().Select(x => MapToDTO(x));

            if (orderBy != null)
            {
                manufacturersQueryable = _OrderManufacturers(manufacturersQueryable, orderBy);
            }

            if (name != null)
            {
                manufacturersQueryable = manufacturersQueryable.Where(x => x.Name.ToLower().Contains(name.ToLower()));
            }

            return PaginationHelper.GetPage(manufacturersQueryable, pageNumber, pageSize);
        }

        private IQueryable<CarManufacturerDTO> _OrderManufacturers(IQueryable<CarManufacturerDTO> manufacturers, string orderBy)
        {
            switch (orderBy.ToLower())
            {
                case "name": return manufacturers.OrderBy(x => x.Name);
                case "-name": return manufacturers.OrderByDescending(x => x.Name);
                case "website": return manufacturers.OrderBy(x => x.Website);
                case "-website": return manufacturers.OrderByDescending(x => x.Website);
                default: return manufacturers;
            }
        }


        public async Task<CarManufacturerDTO> UpdateManufacturerAsync(CarManufacturerDTO data)
        {
            var manufacturer = await _db.CarManufacturers.FindAsync(data.Id);

            if (manufacturer == null)
                throw new Exception("Could not find the manufacturer with given ID.");

            manufacturer.Name = data.Name ?? manufacturer.Name;
            manufacturer.Website = data.Website ?? manufacturer.Website;

            var saved = await _db.SaveChangesAsync();

            if (saved <= 0)
                throw new Exception("Problem saving data.");

            return MapToDTO(manufacturer);
        }

        public async Task<CarManufacturerDTO> CreateManufacturerAsync(CarManufacturerCreate data)
        {
            var manufacturer = new CarManufacturer
            {
                Name = data.Name,
                Website = data.Website
            };

            _db.CarManufacturers.Add(manufacturer);
            var saved = await _db.SaveChangesAsync();

            if (saved <= 0)
                throw new Exception("Problem saving data.");

            return MapToDTO(manufacturer);
        }

        public async Task<CarManufacturerDTO> GetManufacturerByIdAsync(int id)
        {
            var manufacturer = await _db.CarManufacturers.FindAsync(id);
            return MapToDTO(manufacturer);
        }

        public async Task DeleteManufacturerAsync(int id)
        {
            var manufacturer = await _db.CarManufacturers.FindAsync(id);

            if (manufacturer == null)
                throw new Exception("Manufacturer of given ID not found");

            var models = await _db.CarModels.Where(x => x.ManufacturerId == id).ToListAsync();

            _db.CarModels.RemoveRange(models);
            _db.CarManufacturers.Remove(manufacturer);

            var saved = await _db.SaveChangesAsync();

            if (saved <= 0)
                throw new Exception("Problem saving data.");
        }

        private CarManufacturerDTO MapToDTO(CarManufacturer manufacturer)
        {
            return iMapper.Map<CarManufacturer, CarManufacturerDTO>(manufacturer);
        }
    }
}
