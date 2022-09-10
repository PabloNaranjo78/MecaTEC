namespace BaseDatosAdmin.Base_de_datos.Servicios_Cita
{
    public class Servicios_CitaList : Entidad<Servicios_Cita>
    {
        public Servicios_CitaList() : base("Servicios_Cita.json")
        {

        }

    }
    public class Servicios_Cita
    {
        public int Placa { get; set; }
        public string Servicio { get; set; }
    }
}
