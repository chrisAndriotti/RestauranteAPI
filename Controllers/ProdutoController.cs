using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestauranteAPI.Data;
using RestauranteAPI.Models;


namespace RestauranteAPI.Controllers
{
    [ApiController]
    [Route("v1/produtos")]
    public class ProdutoController : ControllerBase
    {
        
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Produto>>> Get([FromServices] DataContext context)
        {
            //var produtos = await context.Produtos.Include(x => x.Categoria).ToListAsync();
            //return produtos;
            var produtos = await context.Produtos.ToListAsync();
            foreach(Produto produto in produtos){
                produto.Fornecedor = await context.Fornecedores.SingleAsync(x => x.Id == produto.FornecedorId);
                produto.Categoria = await context.Categorias.SingleAsync(x => x.Id == produto.CategoriaId);
            }
            return produtos;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Produto>> GetById([FromServices] DataContext context, int id)
        {
            //var produtos = await context.Produtos.Include(x => x.Categoria)
            //    .AsNoTracking() // Não cria proxy do obj para melhor desempenho
            //   .FirstOrDefaultAsync(x => x.Id == id);
            

            var produtos = await context.Produtos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            produtos.Fornecedor = await context.Fornecedores.SingleAsync(x => x.Id == produtos.FornecedorId);
            
            return produtos;

        }

        //Get no fornecedor
        // [HttpGet]
        // [Route("fornecedores/{id:int}")]
        // public async Task<ActionResult<List<Produto>>> GetByDealer([FromServices] DataContext context, int id)
        // {
        //     var produtos = await context.Produtos
        //         .Include(x => x.Fornecedor)
        //         .AsNoTracking()
        //         .Where(x => x.FornecedorId == id)
        //         .ToListAsync();
        //     return produtos;
        // }

        // //Get na categoria
        // [HttpGet]
        // [Route("categorias/{id:int}")]
        // public async Task<ActionResult<List<Produto>>> GetByCategory([FromServices] DataContext context, int id)
        // {
        //     var produtos = await context.Produtos
        //         .Include(x => x.Categoria)
        //         .AsNoTracking()
        //         .Where(x => x.CategoriaId == id)
        //         .ToListAsync();
        //     return produtos;
        // }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Produto>> Post(
        [FromServices] DataContext context,
        [FromBody] Produto model)
        {
            if (ModelState.IsValid)
            {
                context.Produtos.Add(model);
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
        public async Task<ActionResult<Produto>> Put(
        [FromServices] DataContext context,
        [FromBody] Produto model, int id)
        {
            var produtos = await context.Produtos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);  
            if(produtos == null){
                return BadRequest(ModelState);
            }       
            else{
                produtos.Nome = model.Nome;
                produtos.Preco = model.Preco;
                produtos.Quantidade = model.Quantidade;
                produtos.CategoriaId = model.CategoriaId;
                produtos.FornecedorId = model.FornecedorId;
                context.Update(produtos);               
                await context.SaveChangesAsync();
            }
            return produtos;
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Produto>> Delete([FromServices] DataContext context, int id)
        {
            var produtos = await context.Produtos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);  
            if(produtos == null){
                return BadRequest(ModelState);
            }       
            else{
                context.Remove(produtos);
                await context.SaveChangesAsync();
            }
            return produtos;
        }
    }
}

