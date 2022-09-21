namespace BaseDatosAdmin.Base_de_datos.Cliente
{
    /// <summary>
    /// Clase encargada de generar la instancia de lista, hereda de entidad y
    /// envía el tipo de clase con la cual se desea trabajar en la clase genérica Entidad
    /// </summary>
    public class ClienteList : Entidad<Cliente>
    {
        public ClienteList() : base("Cliente/Cliente.json")
        {

        }

    }
    /// <summary>
    /// Clase cliente, posee los parámetros necesarios para crear las listas
    /// que se guardarán en la base de datos.
    /// </summary>
    public class Cliente
    {
        public Cliente(int _iDCliente, string _usuario, string _constraseña, 
            string _infoContacto, string _nombre, string _email)
        {
            this.idCliente = _iDCliente;
            this.usuario = _usuario;
            this.contraseña = _constraseña;
            this.infoContacto = _infoContacto;
            this.nombre = _nombre;
            this.email = _email;
        }

        public int idCliente { get; set; }
        public string usuario { get; set; }
        public string contraseña { get; set; }
        public string infoContacto { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }
    }
}
