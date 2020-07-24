using Agrivi.Web.Models.Common;
using Agrivi.Web.Models.Manufacturer;
using Agrivi.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Agrivi.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturersController : ControllerBase
    {
        private readonly ICarManufacturerService carManufacturerService;

        public ManufacturersController(ICarManufacturerService carManufacturerService)
        {
            this.carManufacturerService = carManufacturerService;
        }

        /// <summary>
        /// Fetch a list of all manufacturers. Sort keys: "name, -name, website, -website"
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<Page<CarManufacturerDTO>>> GetManufacturersAsync(
            int pageNumber = Page.FIRST,
            int pageSize = Page.DEFAULT_SIZE,
            string orderBy = null,
            string name = null
            )
        {
            try
            {
                var res = await carManufacturerService.GetManufacturersAsync(
                    pageNumber,
                    pageSize,
                    orderBy,
                    name);

                return Ok(res);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Fetch a specific manufacturer
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<CarManufacturerDTO>> GetManufacturerByIdAsync(int id)
        {
            try
            {
                var res = await carManufacturerService.GetManufacturerByIdAsync(id);
                return Ok(res);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Creates a new manufacturer with provided data
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<CarManufacturerDTO>> CreateManufacturerAsync(
            CarManufacturerCreate manufacturer)
        {
            try
            {
                var res = await carManufacturerService.CreateManufacturerAsync(manufacturer);
                return Ok(res);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Updates an existing manufacturer using provided data
        /// </summary>
        [HttpPut]
        public async Task<ActionResult<CarManufacturerDTO>> UpdateManufacturerAsync(
            CarManufacturerDTO manufacturer)
        {
            try
            {
                var res = await carManufacturerService.UpdateManufacturerAsync(manufacturer);
                return Ok(res);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Deletes specific manufacturer and all related car models
        /// </summary>
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteManufacturerAsync(int id)
        {
            try
            {
                await carManufacturerService.DeleteManufacturerAsync(id);
                return Ok();
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}