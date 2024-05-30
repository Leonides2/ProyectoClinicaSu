using Entidades;


namespace Services.Sucursales
{
    public interface ISvSucursal
    {
        public List<Sucursal> GetSucursales();
        public Sucursal GetSucursalById(int idSucursal);

       public void AddSucursal(Sucursal sucursal);
        public void UpdateSucursal(Sucursal sucursal);
        public void DeleteSucursal(int idSucursal);
    }

}
