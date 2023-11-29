using APIEPE.DATA.Repositorio;
using APIEPE.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIEPE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly IReserva _reservaRepository;
        public ReservaController(IReserva reservaRepository)
        {
            _reservaRepository = reservaRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllReserva()
        {
            return Ok(await _reservaRepository.GetAllReserva());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservaDetails(int id)
        {
            return Ok(await _reservaRepository.GetDetails(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateReserva([FromBody] Reserva reserva)
        {
            var created = await _reservaRepository.InsertReserva(reserva);

            if (reserva == null)
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
        public async Task<IActionResult> UpdateReserva([FromBody] Reserva reserva)
        {
            var created = await _reservaRepository.UpdateReserva(reserva);

            if (reserva == null)
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
            await _reservaRepository.DeleteReserva(new Reserva { idReserva = id });

            return NoContent();
        }
    }
}
