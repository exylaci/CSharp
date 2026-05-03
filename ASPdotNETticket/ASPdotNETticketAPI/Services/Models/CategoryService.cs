using ASPdotNETticketAPI.Data;
using ASPdotNETticketAPI.Dtos.Categories;
using ASPdotNETticketAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ASPdotNETticketAPI.Services.Models;

public class CategoryService : ICategoryService
{
    private readonly AppDbContext dbContext; //A koontroller réteg nem közvetlenül az adatbázissal dolgozik, hanem pl ezen a szervizen keresztűl éri el

    public CategoryService(AppDbContext dbContext) //konstruktorban kapja meg függőségként az adatbázis eléréshez a kapcsolatot
    {
        this.dbContext = dbContext;
    }

    public async Task<List<CategoryDto>> GetAllAsync()
    {
        return await dbContext
            .Categories
            .OrderBy(c => c.Name)
            .Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description
            })
            .ToListAsync();
    }
}