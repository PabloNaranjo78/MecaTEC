namespace BaseDatosAdmin.Base_de_datos.Proveido_Por
{
    public class Proveido_PorList : Entidad<Proveido_Por>
    {
        public Proveido_PorList() : base("Proveido_Por.json")
        {

        }

    }
    public class Proveido_Por
    {
        public string NombreRep { get; set; }
        public string MarcaRep { get; set; }
        public int Proveedor { get; set; }
    }
}
