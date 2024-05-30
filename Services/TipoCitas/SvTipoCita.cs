using Entidades;
using Services.MyDbContext;


namespace Services.TipoCitas
{
    public class TipoCitaService : ISvTipoCita
    {
        private readonly MyContext _context;

        public TipoCitaService(MyContext context)
        {
            _context = context;
        }

        public List<TipoCita> GetTiposCita()
        {
            return _context.TipoCitas.ToList();
        }

        public TipoCita GetTipoCitaById(int id)
        {
            return _context.TipoCitas.FirstOrDefault(t => t.Id == id);
        }

        public void AddTipoCita(TipoCita tipoCita)
        {
            _context.TipoCitas.Add(tipoCita);
            _context.SaveChanges();
        }

        public void UpdateTipoCita(TipoCita tipoCita)
        {
            _context.TipoCitas.Update(tipoCita);
            _context.SaveChanges();
        }

        public void DeleteTipoCita(int id)
        {
            var tipoCita = _context.TipoCitas.FirstOrDefault(t => t.Id == id);
            if (tipoCita != null)
            {
                _context.TipoCitas.Remove(tipoCita);
                _context.SaveChanges();
            }
        }
    }

}
