namespace BaseDatosAdmin.Base_de_datos.Factura
{
    public class FacturaList : Entidad<Factura>
    {
        public FacturaList() : base("Factura/Factura.json")
        {

        }

    }
    public class Factura
    {
        public Factura(int placa, int numFactura)
        {
            Placa = placa;
            NumFactura = numFactura;
        }

        public int Placa { set; get; }
        public int NumFactura { set; get; }

    }
}
