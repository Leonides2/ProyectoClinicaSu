using Entidades;


namespace Services.Pacientes
{
    public interface ISvPaciente
    {
        public List<Paciente> GetPacientes();
        public Paciente GetPacienteById(int idPaciente);

        //WRITES
        public void AddPaciente(Paciente paciente);
        public void UpdatePaciente(Paciente paciente);
        public void DeletePaciente(int idPaciente);
    }

}
