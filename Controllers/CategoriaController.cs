using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestauranteAPI.Data;
using RestauranteAPI.Models;


namespace RestauranteAPI.Controllers
{
    [ApiController]
    [Route("v1/categorias")]
    public class CategoriaController : ControllerBase
    {

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Categoria>>> Get([FromServices] DataContext context)
        {
            var categorias = await context.Categorias.ToListAsync();
            return categorias;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Categoria>> GetById([FromServices] DataContext context, int id)
        {
            var categoria = await context.Categorias.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return categoria;

        }

        [HttpPost]
        [Route("")]
            public async Task<ActionResult<Categoria>> Post(
            [FromServices] DataContext context,
            [FromBody] Categoria model)
        {
            if (ModelState.IsValid)
            {
                context.Categorias.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Categoria>> Put(
        [FromServices] DataContext context,
        [FromBody] Categoria model, int id)
        {
            var categoria = await context.Categorias.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);  
            if(categoria == null){
                return BadRequest(ModelState);
            }       
            else{
                categoria.Nome = model.Nome;
                context.Update(categoria);
                await context.SaveChangesAsync();
            }
            return categoria;
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Categoria>> Delete([FromServices] DataContext context, int id)
        {
            var categoria = await context.Categorias.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);  
            if(categoria == null){
                return BadRequest(ModelState);
            }       
            else{
                context.Remove(categoria);
                await context.SaveChangesAsync();
            }
            return categoria;
        }
    }
}
