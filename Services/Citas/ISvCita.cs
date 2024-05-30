using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Citas
{
    public interface ISvCita
    {
        public List<Cita> GetCitas();
        public List<Cita> GetCitasByPacienteId(int idPaciente);
        public Cita GetCitaById(int idCita);

        public void AddCita(Cita cita);
        public void UpdateCita(Cita cita);
        public bool PuedeCancelarCita(int idCita);
        public void DeleteCita(int idCita);
    }


}
