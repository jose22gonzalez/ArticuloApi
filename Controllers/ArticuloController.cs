using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArticuloApi.Models;
using ArticuloApi.Data;


namespace ArticuloApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        private readonly Contexto _contexto;

        public ArticuloController(Contexto contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Articulos>> > GetArticulos()
        {
            return await _contexto.Articulos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Articulos>> GetArticulos(int id)
        {
            var articulos = await _contexto.Articulos.FindAsync(id);

            if(articulos == null)
            {
                return NotFound();
            }

            return articulos;
        } 

        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticulos(int id, Articulos articulos)
        {
            if(id != articulos.ArticuloId)
            {
                return BadRequest();
            }

            _contexto.Entry(articulos).State = EntityState.Modified;

            try
            {
                await _contexto.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if (!ExisteArticulo(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Articulos>> PostArticulos(Articulos articulos)
        {
            _contexto.Articulos.Add(articulos);
            await _contexto.SaveChangesAsync();

            return CreatedAtAction("GetArticulos", new {id = articulos.ArticuloId}, articulos);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticulos(int id)
        {
            var articulos = await _contexto.Articulos.FindAsync(id);
            if (articulos == null)
            {
                return NotFound();
            }

            _contexto.Articulos.Remove(articulos);
            await _contexto.SaveChangesAsync();

            return NoContent();
        }

        private bool ExisteArticulo(int id)
        {
            return _contexto.Articulos.Any(a => a.ArticuloId == id);
        }
    }
}
