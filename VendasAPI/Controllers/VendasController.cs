using Microsoft.AspNetCore.Mvc;
using VendasAPI.Domain.Entities;
using VendasAPI.Domain.Services;

namespace VendasAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendasController : ControllerBase
    {
        private readonly IVendaService _vendaService;

        public VendasController(IVendaService vendaService)
        {
            _vendaService = vendaService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Venda>> GetVendas()
        {
            return Ok(_vendaService.GetAllVendas());
        }

        [HttpGet("{id}")]
        public ActionResult<Venda> GetVenda(int id)
        {
            var venda = _vendaService.GetVendaById(id);
            if (venda == null) return NotFound();
            return Ok(venda);
        }

        [HttpPost]
        public ActionResult AddVenda(Venda venda)
        {
            _vendaService.AddVenda(venda);
            return CreatedAtAction(nameof(GetVenda), new { id = venda.Id }, venda);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateVenda(int id, Venda venda)
        {
            if (id != venda.Id) return BadRequest();
            _vendaService.UpdateVenda(venda);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteVenda(int id)
        {
            _vendaService.DeleteVenda(id);
            return NoContent();
        }
    }
}
