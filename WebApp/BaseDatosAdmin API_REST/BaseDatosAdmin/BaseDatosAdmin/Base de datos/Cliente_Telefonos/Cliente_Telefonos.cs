namespace BaseDatosAdmin.Base_de_datos.Cliente_Telefonos
{
    /// <summary>
    /// Clase encargada de generar la instancia de lista, hereda de entidad y
    /// envía el tipo de clase con la cual se desea trabajar en la clase genérica Entidad
    /// </summary>
    public class Cliente_TelefonosList : Entidad<Cliente_Telefonos>
    {
        public Cliente_TelefonosList() : base("Cliente_Telefonos/Cliente_Telefonos.json")
        {

        }

    }
    /// <summary>
    /// Clase cliente_telefonos, posee los parámetros necesarios para crear las listas
    /// que se guardarán en la base de datos.
    /// </summary>
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
