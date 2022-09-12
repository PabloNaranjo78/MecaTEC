namespace BaseDatosAdmin.Base_de_datos.Sucursal
{
    public class SucursalList : Entidad<Sucursal>
    {
        public SucursalList() : base("Sucursal/Sucursal.json")
        {

        }

    }
    public class Sucursal
    {
        public Sucursal(string nombreSuc, string fechaApert, int telefono, string provincia, string canton, string distrito)
        {
            NombreSuc = nombreSuc;
            FechaApert = fechaApert;
            Telefono = telefono;
            Provincia = provincia;
            Canton = canton;
            Distrito = distrito;
        }

        public string NombreSuc { set; get; }
        public string FechaApert { set; get; }
        public int Telefono { set; get; }
        public string Provincia { set; get; }
        public string Canton { set; get; }
        public string Distrito { set; get; }

    }
}
