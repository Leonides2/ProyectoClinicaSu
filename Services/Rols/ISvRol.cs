using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Rols
{
    public interface ISvRol
    {
       public List<Rol> GetRoles();

       public Rol GetRolById(int idRol);

       public void AddRol(Rol rol);
       public void UpdateRol(Rol rol);
       public void DeleteRol(int idRol);
    }

}
