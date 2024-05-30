using Entidades;
using Services.MyDbContext;

namespace Services.Pacientes
{
    public class PacienteService : ISvPaciente
    {
        private readonly MyContext _context;

        public PacienteService(MyContext context)
        {
            _context = context;
        }

        public List<Paciente> GetPacientes()
        {
            return _context.Pacientes.ToList();
        }

        public Paciente GetPacienteById(int id)
        {
            return _context.Pacientes.FirstOrDefault(p => p.Id == id);
        }

        public void AddPaciente(Paciente paciente)
        {
            _context.Pacientes.Add(paciente);
            _context.SaveChanges();
        }

        public void UpdatePaciente(Paciente paciente)
        {

            _context.Pacientes.Update(paciente);
            _context.SaveChanges();
        }

        public void DeletePaciente(int id)
        {
            var paciente = _context.Pacientes.FirstOrDefault(p => p.Id == id);
            if (paciente != null)
            {
                _context.Pacientes.Remove(paciente);
                _context.SaveChanges();
            }
        }
    }
}
