namespace BaseDatosAdmin.Base_de_datos.Servicios_Cita
{
    /// <summary>
    /// Clase encargada de generar la instancia de lista, hereda de entidad y
    /// envía el tipo de clase con la cual se desea trabajar en la clase genérica Entidad
    /// </summary>
    public class Servicios_CitaList : Entidad<Servicios_Cita>
    {
        public Servicios_CitaList() : base("Servicios_Cita/Servicios_Cita.json")
        {

        }

    }
    /// <summary>
    /// Clase servicio_cita, posee los parámetros necesarios para crear las listas
    /// que se guardarán en la base de datos.
    /// </summary>
    public class Servicios_Cita
    {
        public Servicios_Cita(string servicio, int placa)
        {
            Servicio = servicio;
            Placa = placa;
        }

        public int Placa { get; set; }
        public string Servicio { get; set; }
    }
}
