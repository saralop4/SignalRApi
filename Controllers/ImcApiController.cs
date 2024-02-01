using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRApi.Hubs;
using SignalRApiBLL.Servicios;
using SignalRApiDAL.Models;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImcApiController : ControllerBase
    {

        private readonly IHubContext<ImcHub> _hubContext;
        private readonly ServicioCalculoImc _servicioCalculoIMC;

        public ImcApiController(IHubContext<ImcHub> hubContext, ServicioCalculoImc servicioCalculoIMC)
        {
            _hubContext = hubContext;
            _servicioCalculoIMC = servicioCalculoIMC;
        }

        [HttpPost]
        public async Task<IActionResult> AddImc([FromBody] Persona persona)
        {
            var imc = _servicioCalculoIMC.CalcularIMC(persona);
            await _hubContext.Clients.All.SendAsync("ReceiveImc", imc);
            return Ok(new { mensaje = $"El imc es: {imc}" });
        }
    }
}

