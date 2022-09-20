namespace BaseDatosAdmin.Base_de_datos.Cita
{
    public class CitaList : Entidad<Cita>
    {
        public CitaList() : base("Cita/Cita.json")
        {

        }

    }
    public class Cita
    {
        public Cita(int placa, string fechaCita, int iDMecanico, int iDAyudante, string sucursal, int iDCliente)
        {
            this.placa = placa;
            this.fechaCita = fechaCita;
            idMecanico = iDMecanico;
            idAyudante = iDAyudante;
            this.sucursal = sucursal;
            idCliente = iDCliente;
        }

        public int placa { get; set; }
        public string fechaCita { get; set; }
        public int idMecanico { get; set; }
        public int idAyudante { get; set; }
        public string sucursal { get; set; }
        public int idCliente { get; set; }
    }
}
