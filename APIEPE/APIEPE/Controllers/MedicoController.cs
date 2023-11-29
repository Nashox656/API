using APIEPE.DATA.Repositorio;
using APIEPE.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIEPE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly IMedicoRepository _medicoReposiroty;

        public MedicoController(IMedicoRepository medicoReposiroty)
        {
            _medicoReposiroty = medicoReposiroty;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMedicos()
        {
            return Ok(await _medicoReposiroty.GetAllMedicos());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMedicoDetails(int id)
        {
            return Ok(await _medicoReposiroty.GetDetails(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateMedico([FromBody]Medico medico)
        {
            var created = await _medicoReposiroty.InsertMedico(medico);
            
            if (medico == null)
            {
                return BadRequest();

            }else if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                return Created("created", created);
            }

        }
        [HttpPut]
        public async Task<IActionResult> UpdateMedico([FromBody] Medico medico)
        {
            var created = await _medicoReposiroty.UpdateMedico(medico);

            if (medico == null)
            {
                return BadRequest();

            }
            else if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                return NoContent();
            }

        }
        [HttpDelete]
        public async Task<IActionResult> DeleteMedico(int id)
        {
            await _medicoReposiroty.DeleteMedico(new Medico { Id = id });

            return NoContent();
        }
    }
}
