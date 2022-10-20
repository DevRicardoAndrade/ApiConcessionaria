using ApiConcessionaria.Context;
using ApiConcessionaria.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiConcessionaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FabricantesController : ControllerBase
    {

        private readonly ApiConcessionariaContext _context;

        public FabricantesController(ApiConcessionariaContext context)
        {
            _context = context;
        }
        [HttpGet("FabricantesProdutos")]
        public ActionResult<IEnumerable<Fabricante>> GetFabricantesProdutos()
        {
            try
            {
                var fabricantes = _context.Fabricantes.Include(v => v.Veiculos).AsNoTracking().ToList();
                if (fabricantes is null)
                {
                    throw new Exception("Fabricantes não localizados!");
                }
                return fabricantes;
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }
        [HttpGet]
        public ActionResult<IEnumerable<Fabricante>> Get()
        {
            try
            {
                var fabricantes = _context.Fabricantes.AsNoTracking().ToList();
                if (fabricantes is null)
                {
                    throw new Exception("Fabricantes não localizados!");
                }
                return fabricantes;
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpGet("{id:int}", Name = "ObterFabricante")]
        public ActionResult<Fabricante> Get(int id)
        {
            try
            {
                var fabricante = _context.Fabricantes.AsNoTracking().FirstOrDefault(f => f.FabricanteId == id);
                if (fabricante is null)
                {
                    throw new Exception("Não foi localizado o fabricante de id: " + id.ToString());
                }
                return fabricante;
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Fabricante fabricante)
        {
            try
            {
                if (!ModelState.IsValid || fabricante is null)
                {
                    return BadRequest(ModelState);
                }
                _context.Fabricantes.Add(fabricante);
                _context.SaveChanges();

                return new CreatedAtRouteResult("ObterFabricante", new { id = fabricante.FabricanteId }, fabricante);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, [FromBody] Fabricante fabricante)
        {
            try
            {
                if (id != fabricante.FabricanteId)
                {
                    throw new Exception("Id passado no parâmetro diferente do passado no body!");
                }
                _context.Entry(fabricante).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return Ok(fabricante);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                var fabricante = _context.Fabricantes.FirstOrDefault(f => f.FabricanteId == id);
                if (fabricante is null)
                {
                    throw new Exception("Não foi localizado o veículo de id: " + id.ToString());
                }
                _context.Fabricantes.Remove(fabricante);
                _context.SaveChanges();
                return Ok(fabricante);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
