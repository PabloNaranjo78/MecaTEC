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
        public Cliente(int iDCliente, string usuario, string constraseña, string infoContacto, string nombre, string email)
        {
            idCliente = iDCliente;
            this.usuario = usuario;
            contraseña = constraseña;
            this.infoContacto = infoContacto;
            this.nombre = nombre;
            this.email = email;
        }

        public int idCliente { get; set; }
        public string usuario { get; set; }
        public string contraseña { get; set; }
        public string infoContacto { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }
    }
}
