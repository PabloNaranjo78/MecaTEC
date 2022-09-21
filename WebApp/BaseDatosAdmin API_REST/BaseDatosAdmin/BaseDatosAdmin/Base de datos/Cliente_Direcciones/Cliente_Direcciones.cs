namespace BaseDatosAdmin.Base_de_datos.Cliente_direcciones
{
    /// <summary>
    /// Clase encargada de generar la instancia de lista, hereda de entidad y
    /// envía el tipo de clase con la cual se desea trabajar en la clase genérica Entidad
    /// </summary>
    public class Cliente_DireccionesList : Entidad<Cliente_Direcciones>
    {
        public Cliente_DireccionesList() : base("Cliente_Direcciones/Cliente_Direcciones.json")
        {

        }

    }
    /// <summary>
    /// Clase cliente_direcciones, posee los parámetros necesarios para crear las listas
    /// que se guardarán en la base de datos.
    /// </summary>
    public class Cliente_Direcciones
    {
        public Cliente_Direcciones(int iDCliente, string provincia, string canton, string distrito)
        {
            this.idCliente = iDCliente;
            this.provincia = provincia;
            this.canton = canton;
            this.distrito = distrito;
        }

        public int idCliente { get; set; }
        public string provincia { get; set; }
        public string canton { get; set; }
        public string distrito { get; set; }
    }
}
