namespace BaseDatosAdmin.Base_de_datos.Sucursal
{
    /// <summary>
    /// Clase encargada de generar la instancia de lista, hereda de entidad y
    /// envía el tipo de clase con la cual se desea trabajar en la clase genérica Entidad
    /// </summary>
    public class SucursalList : Entidad<Sucursal>
    {
        public SucursalList() : base("Sucursal/Sucursal.json")
        {

        }

    }
    /// <summary>
    /// Clase sucursal, posee los parámetros necesarios para crear las listas
    /// que se guardarán en la base de datos.
    /// </summary>
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
