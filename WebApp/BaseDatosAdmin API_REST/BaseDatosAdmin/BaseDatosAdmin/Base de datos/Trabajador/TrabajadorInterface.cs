namespace BaseDatosAdmin.Base_de_datos.Trabajador
{
    public class TrabajadorInterface
    {
        public int idTrabajador { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string fechaIngreso { get; set; }
        public string rol { get; set; }
        public string password { get; set; }
        public string fechaNacimiento { get; set; }
    }
}
