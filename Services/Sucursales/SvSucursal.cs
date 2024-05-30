using Entidades;
using Services.MyDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Sucursales
{
    public class SucursalService : ISvSucursal
    {
        private readonly MyContext _context;

        public SucursalService(MyContext context)
        {
            _context = context;
        }

        public List<Sucursal> GetSucursales()
        {
            return _context.Sucursales.ToList();
        }

        public Sucursal GetSucursalById(int id)
        {
            return _context.Sucursales.FirstOrDefault(s => s.Id == id);
        }

        public void AddSucursal(Sucursal sucursal)
        {
            _context.Sucursales.Add(sucursal);
            _context.SaveChanges();
        }

        public void UpdateSucursal(Sucursal sucursal)
        {
            _context.Sucursales.Update(sucursal);
            _context.SaveChanges();
        }

        public void DeleteSucursal(int id)
        {
            var sucursal = _context.Sucursales.FirstOrDefault(s => s.Id == id);
            if (sucursal != null)
            {
                _context.Sucursales.Remove(sucursal);
                _context.SaveChanges();
            }
        }
    }

}
