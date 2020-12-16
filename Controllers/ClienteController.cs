using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestauranteAPI.Data;
using RestauranteAPI.Models;


namespace RestauranteAPI.Controllers
{
    [ApiController]
    [Route("v1/clientes")]
    public class ClienteController : ControllerBase
    {

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Cliente>>> Get([FromServices] DataContext context)
        {
            var clientes = await context.Clientes.ToListAsync();
            return clientes;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Cliente>> GetById([FromServices] DataContext context, int id)
        {
            var cliente = await context.Clientes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return cliente;

        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Cliente>> Post(
        [FromServices] DataContext context,
        [FromBody] Cliente model)
        {
            if (ModelState.IsValid)
            {
                context.Clientes.Add(model);
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
        public async Task<ActionResult<Cliente>> Put(
        [FromServices] DataContext context,
        [FromBody] Cliente model, int id)
        {
            var cliente = await context.Clientes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);  
            if(cliente == null){
                return BadRequest(ModelState);
            }       
            else{
                cliente.Nome = model.Nome;
                cliente.Telefone = model.Telefone;
                context.Update(cliente);
                await context.SaveChangesAsync();
            }
            return cliente;
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Cliente>> Delete([FromServices] DataContext context, int id)
        {
            var cliente = await context.Clientes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);  
            if(cliente == null){
                return BadRequest(ModelState);
            }       
            else{
                context.Remove(cliente);
                await context.SaveChangesAsync();
            }
            return cliente;
        }
    }
}
