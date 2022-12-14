namespace BaseDatosAdmin.Base_de_datos.Repuestos_Modelos
{

    public class Repuestos_ModelosList : Entidad<Repuestos_Modelos>
    {
        public Repuestos_ModelosList() : base("Repuestos_Modelos/Repuestos_Modelos.json")
        {

        }

    }
    public class Repuestos_Modelos
    {
        public string NombreRep { get; set; }
        public string MarcaRep { get; set; }
        public string Modelo { get; set; }
    }
}
