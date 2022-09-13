namespace BaseDatosAdmin.Base_de_datos.Servicio
{
    public class ServicioList : Entidad<Servicio>
    {
        public ServicioList() : base("Servicio/Servicio.json")
        {

        }

    }
    public class Servicio
    {
        public Servicio(string nombreServ, string duracion, int precio, int costo)
        {
            NombreServ = nombreServ;
            Duracion = duracion;
            Precio = precio;
            Costo = costo;
        }

        public string NombreServ { get; set; }
        public string Duracion { get; set; }
        public int Precio { get; set; }
        public int Costo { get; set; }
    }
}
