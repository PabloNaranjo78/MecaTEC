namespace BaseDatosAdmin.Base_de_datos.Cliente_Direcciones
{
    /// <summary>
    /// Clase utilizada para obtener los datos envíados por el frontend
    /// </summary>
    public class ClienteDireccionesInterface
    {
        public int idCliente { get; set; }
        public string provincia { get; set; }
        public string canton { get; set; }
        public string distrito { get; set; }
    }
}
