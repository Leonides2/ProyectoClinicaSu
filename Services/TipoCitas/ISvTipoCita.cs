using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.TipoCitas
{
    public interface ISvTipoCita
    {
        public List<TipoCita> GetTiposCita();
        public TipoCita GetTipoCitaById(int idTipoCita);

        public void AddTipoCita(TipoCita tipoCita);
        public void UpdateTipoCita( TipoCita tipoCita);
         public void DeleteTipoCita(int idTipoCita);
    }

}
