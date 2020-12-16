using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestauranteAPI.Data;
using RestauranteAPI.Models;


namespace RestauranteAPI.Controllers
{
    [ApiController]
    [Route("v1/fornecedores")]
    public class FornecedorController : ControllerBase
    {

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Fornecedor>>> Get([FromServices] DataContext context)
        {
            var fornecedores = await context.Fornecedores.ToListAsync();
            return fornecedores;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Fornecedor>> GetById([FromServices] DataContext context, int id)
        {
            var fornecedores = await context.Fornecedores.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return fornecedores;

        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Fornecedor>> Post(
        [FromServices] DataContext context,
        [FromBody] Fornecedor model)
        {
            if (ModelState.IsValid)
            {
                context.Fornecedores.Add(model);
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
        public async Task<ActionResult<Fornecedor>> Put(
        [FromServices] DataContext context,
        [FromBody] Fornecedor model, int id)
        {
            var fornecedor = await context.Fornecedores.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);  
            if(fornecedor == null){
                return BadRequest(ModelState);
            }       
            else{
                fornecedor.Nome = model.Nome;
                fornecedor.Telefone = model.Telefone;
                context.Update(fornecedor);
                await context.SaveChangesAsync();
            }
            return fornecedor;
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Fornecedor>> Delete([FromServices] DataContext context, int id)
        {
            var fornecedor = await context.Fornecedores.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);  
            if(fornecedor == null){
                return BadRequest(ModelState);
            }       
            else{
                context.Remove(fornecedor);
                await context.SaveChangesAsync();
            }
            return fornecedor;
        }
    }
}
