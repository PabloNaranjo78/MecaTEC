namespace BaseDatosAdmin.Base_de_datos.Cliente_direcciones
{
    public class Cliente_DireccionesList : Entidad<Cliente_Direcciones>
    {
        public Cliente_DireccionesList() : base("Cliente_Direcciones/Cliente_Direcciones.json")
        {

        }

    }
    public class Cliente_Direcciones
    {
        public int IDCliente { get; set; }
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }
    }
}
