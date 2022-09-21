namespace BaseDatosAdmin.Base_de_datos.Cliente
{
    /// <summary>
    /// Clase utilizada para obtener los datos envíados por el frontend
    /// </summary>
    public class ClienteInterface
    {
        public int idCliente { get; set; }
        public string usuario { get; set; }
        public string contraseña { get; set; }
        public string infoContacto { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }
    }
}
