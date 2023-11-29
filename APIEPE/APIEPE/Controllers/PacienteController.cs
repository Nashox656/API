using APIEPE.DATA.Repositorio;
using APIEPE.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIEPE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPaciente _pacienteRepository;
        public PacienteController (IPaciente pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPaciente()
        {
            return Ok(await _pacienteRepository.GetAllPaciente());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPacienteDetails(int id)
        {
            return Ok(await _pacienteRepository.GetDetails(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreatePaciente([FromBody] Paciente paciente)
        {
            var created = await _pacienteRepository.InsertPaciente(paciente);

            if (paciente == null)
            {
                return BadRequest();

            }
            else if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                return Created("created", created);
            }

        }
        [HttpPut]
        public async Task<IActionResult> UpdateMedico([FromBody] Paciente paciente)
        {
            var created = await _pacienteRepository.UpdatePaciente(paciente);

            if (paciente == null)
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
        public async Task<IActionResult> DeletePaciente(int id)
        {
            await _pacienteRepository.DeletePaciente(new Paciente { idPaciente = id });

            return NoContent();
        }
    }
}
