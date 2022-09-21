namespace BaseDatosAdmin.Base_de_datos.Trabajador
{
    /// <summary>
    /// Clase encargada de generar la instancia de lista, hereda de entidad y
    /// envía el tipo de clase con la cual se desea trabajar en la clase genérica Entidad
    /// </summary>
    public class TrabajadorList : Entidad<Trabajador>
    {
        public TrabajadorList (): base("Trabajador/Trabajador.json")
        {
            
        }

    }

    /// <summary>
    /// Clase trabajador, posee los parámetros necesarios para crear las listas
    /// que se guardarán en la base de datos.
    /// </summary>
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
