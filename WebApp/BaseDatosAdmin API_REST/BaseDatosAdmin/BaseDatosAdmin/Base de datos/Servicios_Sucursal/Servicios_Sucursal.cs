namespace BaseDatosAdmin.Base_de_datos.Servicios_Sucursal
{

    public class Servicios_SucursalList : Entidad<Servicios_Sucursal>
    {
        public Servicios_SucursalList() : base("Servicios_Sucursal/Servicios_Sucursal.json")
        {

        }

    }
    public class Servicios_Sucursal
    {
        public string Servicio { get; set; }
        public string Sucursal { get; set; }
    }
}
