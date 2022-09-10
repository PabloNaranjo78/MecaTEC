namespace BaseDatosAdmin.Base_de_datos.Servicio
{
    public class ServicioList : Entidad<Servicio>
    {
        public ServicioList() : base("Servicio.json")
        {

        }

    }
    public class Servicio
    {
        public string NombreServ { get; set; }
        public string Duracion { get; set; }
        public string Precio { get; set; }
        public string Costo { get; set; }
    }
}
