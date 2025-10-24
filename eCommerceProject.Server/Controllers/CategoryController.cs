using eCommerceProject.Application.DTOs.Category;
using eCommerceProject.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(ICategoryService service) : ControllerBase
    {
        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            var data = await service.GetAllAsync();
            return data.Any() ? Ok(data) : NotFound(data);
        }
        [HttpGet("Single/{id}")]
        public async Task<IActionResult> GetSingle(Guid id)
        {
            var data = await service.GetByIdAsync(id);
            return data is not null ? Ok(data) : NotFound(data);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateCategory dto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var result = await service.CreateAsync(dto);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateCategory dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await service.UpdateAsync(dto);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await service.DeleteAsync(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
