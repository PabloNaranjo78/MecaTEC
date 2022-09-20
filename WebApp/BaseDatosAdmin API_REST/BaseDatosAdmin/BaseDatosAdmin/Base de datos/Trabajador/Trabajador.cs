namespace BaseDatosAdmin.Base_de_datos.Trabajador
{
    public class TrabajadorList : Entidad<Trabajador>
    {
        public TrabajadorList (): base("Trabajador/Trabajador.json")
        {
            
        }

    }

    public class Trabajador
    {
        public int idTrabajador { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string fechaIngreso { get; set; }
        public string rol { get; set; }
        public string password { get; set; }
        public string fechaNacimiento { get; set; }

        public Trabajador (int _numeroCedula, string _nombre, string _apellidos,
            string _fechaIngreso, string _rol, string _password, string _fechaNacimiento)
        {
            idTrabajador = _numeroCedula;
            nombre = _nombre;
            apellidos = _apellidos;
            fechaIngreso = _fechaIngreso;
            rol = _rol;
            password = _password;
            fechaNacimiento = _fechaNacimiento;
        }

       
        
    }

}
