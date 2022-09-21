namespace BaseDatosAdmin.Base_de_datos.Servicios_Sucursal
{
    /// <summary>
    /// Clase encargada de generar la instancia de lista, hereda de entidad y
    /// envía el tipo de clase con la cual se desea trabajar en la clase genérica Entidad
    /// </summary>
    public class Servicios_SucursalList : Entidad<Servicios_Sucursal>
    {
        public Servicios_SucursalList() : base("Servicios_Sucursal/Servicios_Sucursal.json")
        {

        }

    }
    /// <summary>
    /// Clase Servicios_Sucursal, posee los parámetros necesarios para crear las listas
    /// que se guardarán en la base de datos.
    /// </summary>
    public class Servicios_Sucursal
    {
        public Servicios_Sucursal(string servicio, string sucursal)
        {
            Servicio = servicio;
            Sucursal = sucursal;
        }

        public string Servicio { get; set; }
        public string Sucursal { get; set; }
    }
}
