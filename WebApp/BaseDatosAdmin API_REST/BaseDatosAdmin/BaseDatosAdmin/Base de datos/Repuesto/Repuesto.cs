namespace BaseDatosAdmin.Base_de_datos.Repuesto
{
    public class RepuestoList : Entidad<Repuesto>
    {
        public RepuestoList() : base("Repuesto/Repuesto.json")
        {

        }

    }
    public class Repuesto
    {
        public string NombreRep { get; set; }
        public string MarcaRep { get; set; }
        public int Precio { get; set; }
        public int Costo { get; set; }
        public int AgregadoPor { get; set; }
    }
}
