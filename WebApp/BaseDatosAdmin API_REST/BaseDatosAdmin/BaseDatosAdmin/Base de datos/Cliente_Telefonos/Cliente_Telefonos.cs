namespace BaseDatosAdmin.Base_de_datos.Cliente_Telefonos
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
            this.idCliente = idCliente;
            this.telefono = telefono;
        }

        public int idCliente { get; set; }
        public int telefono { get; set; }
  
    }
}
