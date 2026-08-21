using FirstApi.DTOs.Products;
using FirstApi.Models;

namespace FirstApi.DTOs.Categories
{
    public record GetCategoryDto(int Id, string Name, IReadOnlyCollection<GetProductItemDto> ProductDtos)
    {
    }
    
}
