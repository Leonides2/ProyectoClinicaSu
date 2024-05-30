using Entidades;
using Microsoft.EntityFrameworkCore;
using Services.MyDbContext;

namespace Services.Citas
{
    public class CitaService : ISvCita
    {
        private readonly MyContext _context;

        public CitaService(MyContext context)
        {
            _context = context;
        }

        public List<Cita> GetCitas()
        {
            return _context.Citas.Include(c => c.Paciente)
                .Include(c => c.TipoCita)
                .Include(c => c.Sucursal)
                .ToList();
        }

        public Cita GetCitaById(int id)
        {
            return _context.Citas.Include(c => c.Paciente)
                .Include(c => c.TipoCita)
                .Include(c => c.Sucursal)
                .FirstOrDefault(c => c.Id == id);
        }

        public void AddCita(Cita cita)
        {
            _context.Citas.Add(cita);
            _context.SaveChanges();
        }

        public void UpdateCita(Cita cita)
        {
            _context.Citas.Update(cita);
            _context.SaveChanges();
        }

        public void DeleteCita(int id)
        {
            var cita = _context.Citas.FirstOrDefault(c => c.Id == id);
            if (cita != null)
            {
                _context.Citas.Remove(cita);
                _context.SaveChanges();
            }
        }
        public bool PuedeCancelarCita(int citaId)
        {
            var cita = GetCitaById(citaId);

            if (cita == null)
            {
                return false;
            }

            var fechaActual = DateTime.Now;
            var tiempoTranscurrido = fechaActual - cita.FechaHora;

            return tiempoTranscurrido.TotalHours <= 24;
        }

        public List<Cita> GetCitasByPacienteId(int idPaciente)
        {
            var list = _context.Citas.Where<Cita>(item => item.IdPaciente == idPaciente).ToList();
            return list;
        }
    }

}
