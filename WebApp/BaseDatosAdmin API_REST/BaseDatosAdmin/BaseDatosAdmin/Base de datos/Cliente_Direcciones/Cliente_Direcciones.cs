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
