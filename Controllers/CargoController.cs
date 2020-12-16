using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestauranteAPI.Data;
using RestauranteAPI.Models;


namespace RestauranteAPI.Controllers
{
    [ApiController]
    [Route("v1/cargos")]
    public class CargosController : ControllerBase
    {

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Cargo>>> Get([FromServices] DataContext context)
        {
            var cargos = await context.Cargos.ToListAsync();
            return cargos;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Cargo>> GetById([FromServices] DataContext context, int id)
        {
            var cargo = await context.Cargos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return cargo;

        }

        [HttpPost]
        [Route("")]
            public async Task<ActionResult<Cargo>> Post(
            [FromServices] DataContext context,
            [FromBody] Cargo model)
        {
            if (ModelState.IsValid)
            {
                context.Cargos.Add(model);
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
        public async Task<ActionResult<Cargo>> Put(
        [FromServices] DataContext context,
        [FromBody] Cargo model, int id)
        {
            var cargo = await context.Cargos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);  
            if(cargo == null){
                return BadRequest(ModelState);
            }       
            else{
                cargo.Nome = model.Nome;
                cargo.Salario = model.Salario;
                context.Update(cargo);
                await context.SaveChangesAsync();
            }
            return cargo;
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Cargo>> Delete([FromServices] DataContext context, int id)
        {
            var cargo = await context.Cargos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);  
            if(cargo == null){
                return BadRequest(ModelState);
            }       
            else{
                context.Remove(cargo);
                await context.SaveChangesAsync();
            }
            return cargo;
        }
    }
}
