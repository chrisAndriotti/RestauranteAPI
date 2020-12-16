using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestauranteAPI.Data;
using RestauranteAPI.Models;


namespace RestauranteAPI.Controllers
{
    [ApiController]
    [Route("v1/funcionarios")]
    public class FuncionariosController : ControllerBase
    {

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Funcionario>>> Get([FromServices] DataContext context)
        {
            var funcionarios = await context.Funcionarios.ToListAsync();
            foreach(Funcionario funcionario in funcionarios){
                funcionario.Cargo = await context.Cargos.SingleAsync(x => x.Id == funcionario.CargoId);
            }
            return funcionarios;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Funcionario>> GetById([FromServices] DataContext context, int id)
        {
            var funcionario = await context.Funcionarios.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return funcionario;

        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Funcionario>> Post(
        [FromServices] DataContext context,
        [FromBody] Funcionario model)
        {
            if (ModelState.IsValid)
            {
                context.Funcionarios.Add(model);
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
        public async Task<ActionResult<Funcionario>> Put(
        [FromServices] DataContext context,
        [FromBody] Funcionario model, int id)
        {
            var funcionario = await context.Funcionarios.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);  
            if(funcionario == null){
                return BadRequest(ModelState);
            }       
            else{
                funcionario.Nome = model.Nome;
                funcionario.Telefone = model.Telefone;
                context.Update(funcionario);
                await context.SaveChangesAsync();
            }
            return funcionario;
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Funcionario>> Delete([FromServices] DataContext context, int id)
        {
            var funcionario = await context.Funcionarios.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);  
            if(funcionario == null){
                return BadRequest(ModelState);
            }       
            else{
                context.Remove(funcionario);
                await context.SaveChangesAsync();
            }
            return funcionario;
        }
    }
}
