﻿namespace BaseDatosAdmin.Base_de_datos.Cliente
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
            IDCliente = iDCliente;
            Usuario = usuario;
            Constraseña = constraseña;
            InfoContacto = infoContacto;
            Nombre = nombre;
            this.email = email;
        }

        public int IDCliente { get; set; }
        public string Usuario { get; set; }
        public string Constraseña { get; set; }
        public string InfoContacto { get; set; }
        public string Nombre { get; set; }
        public string email { get; set; }
    }
}