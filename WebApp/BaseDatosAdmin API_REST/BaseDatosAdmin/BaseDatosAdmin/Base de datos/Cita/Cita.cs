namespace BaseDatosAdmin.Base_de_datos.Cita
{
    public class Cita
    {
        public int Placa { get; set; }
        public string FechaCita { get; set; }
        public int IDMecanico { get; set; }
        public int IDAyudante { get; set; }
        public string Sucursal { get; set; }
        public int IDCliente { get; set; }
    }
}
