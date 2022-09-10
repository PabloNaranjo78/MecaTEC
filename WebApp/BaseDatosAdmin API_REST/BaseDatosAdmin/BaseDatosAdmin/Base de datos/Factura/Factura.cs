namespace BaseDatosAdmin.Base_de_datos.Factura
{
    public class FacturaList : Entidad<Factura>
    {
        public FacturaList() : base("Factura.json")
        {

        }

    }
    public class Factura
    {
        public int Placa { set; get; }
        public int NumFactura { set; get; }

    }
}
