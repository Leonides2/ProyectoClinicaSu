using Entidades;
using Services.MyDbContext;


namespace Services.Rols
{
    public class RolService : ISvRol
    {
        private readonly MyContext _context;

        public RolService(MyContext context)
        {
            _context = context;
        }

        public List<Rol> GetRoles()
        {
            return _context.Roles.ToList();
        }

        public Rol GetRolById(int id)
        {
            return _context.Roles.FirstOrDefault(r => r.Id == id);
        }

        public void AddRol(Rol rol)
        {
            _context.Roles.Add(rol);
            _context.SaveChanges();
        }

        public void UpdateRol(Rol rol)
        {
            _context.Roles.Update(rol);
            _context.SaveChanges();
        }

        public void DeleteRol(int idRol)
        {
            var rol = _context.Roles.FirstOrDefault(r => r.Id == idRol);
            if (rol != null)
            {
                _context.Roles.Remove(rol);
                _context.SaveChanges();
            }
        }
    }

}
