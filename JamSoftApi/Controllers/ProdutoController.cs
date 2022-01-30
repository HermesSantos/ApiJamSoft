using System;
using System.Threading.Tasks;
using JamSoftApi.Data;
using JamSoftApi.Models;
using JamSoftApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JamSoftApi.Controllers
{
    [ApiController]
    [Route(template:"api")]
    public class ProdutoController : ControllerBase
    {
        [HttpGet]
        [Route(template: "produtos")]
         public async Task<IActionResult> GetAsync(
             [FromServices] AppDbContext context)
        {
            var produtos = await context.Produtos.
            AsNoTracking().ToListAsync();
            return Ok(produtos);

        }
         [HttpGet]
         [Route(template: "produtos/{id}")]
         public async Task<IActionResult> GetByIdAsync(
             [FromServices] AppDbContext context, [FromRoute] int id)
        {
            var produto = await context.Produtos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            return produto == null ? NotFound() : Ok(produto);

        }

         [HttpPost]
         [Route(template:"produtos")]
         public async Task<IActionResult> PostAsync(
            [FromServices] AppDbContext context,
            [FromBody] CreateProduto model)
            {
                if (!ModelState.IsValid)
                return BadRequest();

                var NovoProduto = new ProdutoModel
                {
                    Nome = model.Nome,
                    Valor_Unitario = model.Valor_Unitario,
                    Qtd_Estoque = model.Qtd_Estoque
                };
                 try
                {
                    await context.Produtos.AddAsync(NovoProduto);
                    await context.SaveChangesAsync();
                    return Created($"api/produtos/{NovoProduto.Id}", NovoProduto);
                }
                catch (Exception)
                    {
                        return BadRequest();
                    }
        }  
    }
}