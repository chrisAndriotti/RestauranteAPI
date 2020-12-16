using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestauranteAPI.Data;
using RestauranteAPI.Models;


namespace RestauranteAPI.Controllers
{
    [ApiController]
    [Route("v1/vendas")]
    public class VendasController : ControllerBase
    {

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Venda>>> Get([FromServices] DataContext context)
        {
            var vendas = await context.Vendas.ToListAsync();
            return vendas;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Venda>> GetById([FromServices] DataContext context, int id)
        {
            var venda = await context.Vendas.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return venda;

        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Venda>> Post(
        [FromServices] DataContext context,
        [FromBody] Venda model)
        {
            if (ModelState.IsValid)
            {
                context.Vendas.Add(model);
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
        public async Task<ActionResult<Venda>> Put(
        [FromServices] DataContext context,
        [FromBody] Venda model, int id)
        {
            var venda = await context.Vendas.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);  
            if(venda == null){
                return BadRequest(ModelState);
            }       
            else{
                venda.FuncionarioId = model.FuncionarioId;
                venda.ProdutoId = model.ProdutoId;
                venda.ClienteId = model.ClienteId;
                context.Update(venda);
                await context.SaveChangesAsync();
            }
            return venda;
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Cliente>> Delete([FromServices] DataContext context, int id)
        {
            var venda = await context.Clientes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);  
            if(venda == null){
                return BadRequest(ModelState);
            }       
            else{
                context.Remove(venda);
                await context.SaveChangesAsync();
            }
            return venda;
        }
    }
}
