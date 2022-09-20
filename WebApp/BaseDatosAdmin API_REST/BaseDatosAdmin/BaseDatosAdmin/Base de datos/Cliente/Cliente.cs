namespace BaseDatosAdmin.Base_de_datos.Cliente
{
    public class ClienteList : Entidad<Cliente>
    {
        public ClienteList() : base("Cliente/Cliente.json")
        {

        }

    }
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
