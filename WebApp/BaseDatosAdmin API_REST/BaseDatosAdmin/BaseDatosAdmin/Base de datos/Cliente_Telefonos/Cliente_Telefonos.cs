﻿namespace BaseDatosAdmin.Base_de_datos.Cliente_Telefonos
{
    public class Cliente_TelefonosList : Entidad<Cliente_Telefonos>
    {
        public Cliente_TelefonosList() : base("Cliente_Telefonos/Cliente_Telefonos.json")
        {

        }

    }
    public class Cliente_Telefonos
    {
        public Cliente_Telefonos(int idCliente, int telefono)
        {
            IDCliente = idCliente;
            Telefono = telefono;
        }

        public int IDCliente { get; set; }
        public int Telefono { get; set; }
  
    }
}