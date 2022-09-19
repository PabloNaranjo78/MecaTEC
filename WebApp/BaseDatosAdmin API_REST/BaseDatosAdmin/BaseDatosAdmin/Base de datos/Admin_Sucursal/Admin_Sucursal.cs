namespace BaseDatosAdmin.Base_de_datos.Admin_Sucursal
{
    public class Admin_SucursalList : Entidad<Admin_Sucursal>
    {
        public Admin_SucursalList() : base("Admin_Sucursal/Admin_Sucursal.json")
        {

        }

    }
    public class Admin_Sucursal
    {
        public Admin_Sucursal(int idTrabajador, string sucursal, string fechaInicio)
        {
            IDTrabajador = idTrabajador;
            Sucursal = sucursal;
            FechaInicio = fechaInicio;
        }

        public int IDTrabajador { get; set; }
        public string Sucursal { get; set; }

        public string FechaInicio { get; set; }
    }
}
