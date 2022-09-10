namespace BaseDatosAdmin.Base_de_datos.Admin_Sucursal
{
    public class Admin_SucursalList : Entidad<Admin_Sucursal>
    {
        public Admin_SucursalList() : base("Admin_Sucursal.json")
        {

        }

    }
    public class Admin_Sucursal
    {
        public int IDTrabajador { get; set; }
        public string Sucursal { get; set; }
    }
}
