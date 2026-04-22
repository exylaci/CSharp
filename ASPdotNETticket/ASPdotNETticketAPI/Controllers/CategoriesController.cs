using ASPdotNETticketAPI.Data;
using ASPdotNETticketAPI.Dtos.Categories;
using ASPdotNETticketAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPdotNETticketAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase //Ahhoz hogy tudjuk milyen kategóriák vannak egyáltalán, le kell kérdezni őket az adatbázisból
{
    //A kontrollerben semmi keresnivalója nincs az adatbázisnak. Ez csak a HTTP szintel foglalkozik, ezt kezeli. Az Adatbázist a Szervíz réteg kezeli.

    private readonly ICategoryService categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        this.categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAll()
    {
        List<CategoryDto> categories = await categoryService.GetAllAsync();
        return Ok(categories);
    }
}