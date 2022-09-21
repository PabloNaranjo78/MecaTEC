namespace BaseDatosAdmin.Base_de_datos.Servicio
{
    /// <summary>
    /// Clase encargada de generar la instancia de lista, hereda de entidad y
    /// envía el tipo de clase con la cual se desea trabajar en la clase genérica Entidad
    /// </summary>
    public class ServicioList : Entidad<Servicio>
    {
        public ServicioList() : base("Servicio/Servicio.json")
        {

        }

    }
    /// <summary>
    /// Clase servicio, posee los parámetros necesarios para crear las listas
    /// que se guardarán en la base de datos.
    /// </summary>
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
