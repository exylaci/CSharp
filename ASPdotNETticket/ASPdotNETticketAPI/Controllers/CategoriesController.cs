using ASPdotNETticketAPI.Data;
using ASPdotNETticketAPI.Dtos.Categories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPdotNETticketAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase  //Ahhoz hogy tudjuk milyen kategóriák vannak egyáltalán, le kell kérdezni őket az adatbázisból
{
    private readonly AppDbContext dbContext;

    public CategoriesController(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAll()
    {
        List<CategoryDto> categories = await dbContext.Categories
            .OrderBy(c => c.Name)
            .Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description
            }).ToListAsync();
        return Ok(categories);
    }
}