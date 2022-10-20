using ApiConcessionaria.Context;
using ApiConcessionaria.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiConcessionaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculosController : ControllerBase
    {
        private readonly ApiConcessionariaContext _context;

        public VeiculosController(ApiConcessionariaContext context)
        {
            _context = context; 
        }

        [HttpGet]
        public ActionResult<IEnumerable<Veiculo>> Get()
        {
            try
            {
                var veiculos =  _context.Veiculos.AsNoTracking().ToList();
                if(veiculos is null)
                {
                    throw new Exception("Veículos não localizados!");
                }
                return veiculos;
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
             
        }

        [HttpGet("{id:int}", Name="ObterVeiculo")]
        public ActionResult<Veiculo> Get(int id)
        {
            try
            {
                var veiculo = _context.Veiculos.AsNoTracking().FirstOrDefault(v => v.VeiculoId == id);
                if (veiculo is null)
                {
                    throw new Exception("Não foi localizado o veículo de id: " + id.ToString());
                }
                return veiculo;                
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Veiculo veiculo)
        {
            try
            {
                if (!ModelState.IsValid || veiculo is null)
                {
                    return BadRequest(ModelState);
                }
                _context.Veiculos.Add(veiculo);
                _context.SaveChanges();

                return new CreatedAtRouteResult("ObterVeiculo", new { id = veiculo.VeiculoId }, veiculo);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, [FromBody] Veiculo veiculo)
        {
            try
            {
                if(id != veiculo.VeiculoId)
                {
                    throw new Exception("Id passado no parâmetro diferente do passado no body!");
                }
                _context.Entry(veiculo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return Ok(veiculo);
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
                var veiculo = _context.Veiculos.FirstOrDefault(v => v.VeiculoId == id);
                if(veiculo is null)
                {
                    throw new Exception("Não foi localizado o veículo de id: " + id.ToString());
                }
                _context.Veiculos.Remove(veiculo);
                _context.SaveChanges();
                return Ok(veiculo);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
