

namespace FirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoryService _categoryService;

        public CategoriesController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }



        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _categoryService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            return Ok(await _categoryService.GetByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm]PostCategoryDto categoryDto)
        {
            await _categoryService.CreateAsync(categoryDto);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromForm] PostCategoryDto categoryDto, int? id)
        {
            await _categoryService.UpdateAsync(id, categoryDto);
            return NoContent();

            //return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            await _categoryService.DeleteAsync(id);
            return NoContent();
        }

        //[HttpDelete("{id}/soft")]
        //public async Task<IActionResult> SoftDelete(int? id)
        //{
        //    if (id is null || id < 1) return BadRequest();

        //    Category? existed = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

        //    if (existed is null) return NotFound();

        //    //_context.Categories.Remove(existed);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}
    }
}
