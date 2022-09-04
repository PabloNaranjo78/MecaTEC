namespace BaseDatosAdmin.Base_de_datos.Trabajador
{

    public class TrabajadorList
    {
        public List <Trabajador> trabajadores { get; set; }
    }

    public class Trabajador
    {
        public int NumeroCedula { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string FechaIngreso { get; set; }
        public string Rol { get; set; }
        public string Password { get; set; }
        public string FechaNacimiento { get; set; }
        public Administrador Administrador { get; set; }
    }


    public class Administrador
    {
        public bool Administra { get; set; }
        public object? Sucursal { get; set; }
    }
}
