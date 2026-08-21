
namespace FirstApi.Services.Implementations
{
    public class CategoryService
    {
        private readonly IAppDbContext _context;

        public CategoryService(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<IReadOnlyCollection<GetItemCategoryDto>> GetAllAsync()
        {
            return await _context.Categories
               .Select(c => new GetItemCategoryDto(c.Id, c.Name))
               .ToListAsync();
        }

        public async Task<GetCategoryDto?> GetByIdAsync(int? id)
        {
            Category category = await _getCategoryAsync(id);

            return new GetCategoryDto
            (
                category.Id,
                category.Name,
                category.Products.Select(p => new GetProductItemDto
                (
                    p.Id,
                    p.Name,
                    p.Price
                )).ToList()
            ); 
        }
        public async Task CreateAsync(PostCategoryDto categoryDto)
        {
            Category category = new Category
            {
                Name = categoryDto.Name
            };
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(int? id, PostCategoryDto categoryDto)
        {
           

            Category? existed = await _getCategoryAsync(id);

            existed.Name = categoryDto.Name;

            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int? id)
        {
            Category? existed = await _getCategoryAsync(id);
            _context.Categories.Remove(existed);
            await _context.SaveChangesAsync();
        }

        private async Task<Category> _getCategoryAsync(int? id)
        {
            if (id is null || id < 1) throw new Exception("Bad Request");

            Category? category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if (category == null) throw new Exception("Not Found");

            return category;
        }
    }
}
