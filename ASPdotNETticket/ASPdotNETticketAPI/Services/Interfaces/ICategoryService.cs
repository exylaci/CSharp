using ASPdotNETticketAPI.Dtos.Categories;

namespace ASPdotNETticketAPI.Services.Interfaces;

public interface ICategoryService
{
    Task<List<CategoryDto>> GetAllAsync();
}