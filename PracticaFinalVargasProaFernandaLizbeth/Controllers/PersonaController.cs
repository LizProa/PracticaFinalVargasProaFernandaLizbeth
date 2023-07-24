using Microsoft.AspNetCore.Mvc;
using PracticaFinalVargasProaFernandaLizbeth.Models;
using Microsoft.EntityFrameworkCore;

namespace PracticaFinalVargasProaFernandaLizbeth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PersonaController : ControllerBase
    {

        private readonly ProyectoFinalVargasProaContext db;

        public PersonaController(ProyectoFinalVargasProaContext context)
        {
            db = context;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            List<PersonaItem> lista = await db.PersonaItems.OrderBy(c => c.Id).ToListAsync();

            return StatusCode(StatusCodes.Status200OK, lista);
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] PersonaItem request)
        {
            Console.WriteLine(request);
            await db.PersonaItems.AddAsync(request);
            await db.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] PersonaItem request)
        {
            db.PersonaItems.Update(request);
            await db.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            PersonaItem persona = db.PersonaItems.Find(id)!;
            if (persona != null)
            {
                db.PersonaItems.Remove(persona);
                await db.SaveChangesAsync();
            }
            return StatusCode(StatusCodes.Status200OK, "ok");
        }
    }
}
