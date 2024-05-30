using Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Citas;

namespace ProyectoClinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitasController : ControllerBase
    {
        private readonly ISvCita _citasService;


        public CitasController(ISvCita citasService)
        {
            _citasService = citasService;
        }


        [Authorize(Policy = "Admin")]
        [HttpGet]
        public List<Cita> GetCitas()
        {
            var citas_request = _citasService.GetCitas();

            if (citas_request == null)
            {
                return null;
            }

            return citas_request;
        }

        [Authorize(Policy = "Admin")]
        [HttpGet("{id}")]
        public Cita GetCitaById(int idCita)
        {
            var cita =  _citasService.GetCitaById(idCita);

            if (cita == null)
            {
                return null;
            }

            return cita;
        }

        [HttpGet]
        [Route("/CitasPaciente")]
        public List<Cita> GetCitasByPacienteId(int idPaciente)
        {
            var cita = _citasService.GetCitasByPacienteId(idPaciente);

            if (cita == null)
            {
                return null;
            }

            return cita;
        }

        [Authorize(Policy = "User")]
        [HttpPut("{id}")]
        public void UpdateCita(Cita cita)
        {
            try
            {
                _citasService.UpdateCita(cita);
            }
            catch (Exception e)
            {
                throw new Exception("Error: can't update cita", e);
            }

        }

        [Authorize(Policy = "User")]
        [HttpPost]
        public void AddCita(Cita cita)
        {
            try {
                _citasService.AddCita(cita);
            }catch(Exception e){
                throw new Exception("Error: can't added cita", e);
            }
        }

        [Authorize(Policy = "Admin")]
        [HttpDelete("{id}")]
        public void DeleteCita(int idCita)
        {
            if (_citasService.PuedeCancelarCita(idCita))
            {
                try
                {
                    _citasService.DeleteCita(idCita);
                }
                catch (Exception e)
                {
                    throw new Exception("Error: can't delete cita", e);
                }

            } else { throw new Exception(); }



            
        }
    }
}
