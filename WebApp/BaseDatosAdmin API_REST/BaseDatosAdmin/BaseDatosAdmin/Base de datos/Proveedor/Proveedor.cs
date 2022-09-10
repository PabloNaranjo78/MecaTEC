namespace BaseDatosAdmin.Base_de_datos.Proveedor
{
    public class ProveedorList : Entidad<Proveedor>
    {
        public ProveedorList() : base("Proveedor.json")
        {

        }

    }
    public class Proveedor
    {
        public int CedulaJur { set; get; }
        public string Nombre { set; get; }
        public string Email { set; get; }
        public int Contacto { set; get; }
        public string Provincia { set; get; }
        public string Canton { set; get; }
        public string Distrito { set; get; }
    }
}
