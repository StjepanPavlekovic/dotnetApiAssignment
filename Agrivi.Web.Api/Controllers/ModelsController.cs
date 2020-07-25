using Agrivi.Web.Models.Common;
using Agrivi.Web.Models.Model;
using Agrivi.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Agrivi.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : ControllerBase
    {
        private readonly ICarModelService carModelService;

        public ModelsController(ICarModelService carModelService)
        {
            this.carModelService = carModelService;
        }

        /// <summary>
        /// Fetch a list of all models. Sort keys: "name, -name, year, -year"
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<Page<CarModelDTO>>> GetCarModelsAsync(
            int pageNumber = Page.FIRST,
            int pageSize = Page.DEFAULT_SIZE,
            string orderBy = null,
            string name = null,
            int? manufacturerId = null
            )
        {
            try
            {
                var res = await carModelService.GetCarModelsAsync(
                    pageNumber,
                    pageSize,
                    orderBy,
                    name,
                    manufacturerId);

                return Ok(res);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Fetch a specific car model
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<CarModelDTO>> GetCarModelByIdAsync(int id)
        {
            try
            {
                var res = await carModelService.GetCarModelByIdAsync(id);
                return Ok(res);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Create a new model
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<CarModelDTO>> CreateCarModelAsync(CarModelCreate data)
        {
            try
            {
                var res = await carModelService.CreateCarModelAsync(data);
                return Ok(res);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Update the existing model using provided data
        /// </summary>
        [HttpPut]
        public async Task<ActionResult<CarModelDTO>> UpdateCarModelAsync(CarModelDTO data)
        {
            try
            {
                var res = await carModelService.UpdateCarModelAsync(data);
                return Ok(res);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Delete a specific model
        /// </summary>
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteCarModelAsync(int id)
        {
            try
            {
                await carModelService.DeleteCarModelAsync(id);
                return Ok();
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}