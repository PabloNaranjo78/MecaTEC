using Newtonsoft.Json;
using BaseDatosAdmin.Base_de_datos;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace BaseDatosAdmin.Base_de_datos
{
    /// <summary>
    /// Clase abstracta y genérica para el manejo de entidades
    /// </summary>
    /// <typeparam name="T">Tipo de clase con la cual se desea realizar las listas de la base de datos</typeparam>
    public abstract class Entidad<T>
    {
        private string jsonFileName { get; set; }

        private string path = @"C:/Users/jpabl/Documents/GitHub/MecaTEC/WebApp/BaseDatosAdmin API_REST/BaseDatosAdmin/BaseDatosAdmin/Base de datos/";

        private StreamReader? reader;

        public List<T>? list { get; set; }

        public string jsonInfo { get; set; }

        public Entidad(string jsonFileName)
        {

            this.jsonFileName = jsonFileName;
            this.jsonInfo = this.getJsonString();
            this.loadJson();

        }
        /// <summary>
        /// Método encargado de obtener el json a partir de los datos guardados localmente
        /// </summary>
        /// <returns></returns>
        public string getJsonString()
        {


            reader = new StreamReader(this.path + this.jsonFileName);
            string jsonString = reader.ReadToEnd();
            reader.Close();
            return jsonString;
        }

        /// <summary>
        /// Carga un json a la clase
        /// </summary>
        private void loadJson()
        {
            this.list = JsonConvert.DeserializeObject<List<T>>(jsonInfo);
            this.jsonInfo = this.getJsonString();
        }

        /// <summary>
        /// Guarda el json localmente
        /// </summary>
        private void saveJson()
        {
            string tempJson = JsonConvert.SerializeObject(this.list);
            System.IO.File.WriteAllText(this.path + this.jsonFileName, tempJson);
            this.loadJson();
        }

        /// <summary>
        /// Añade un nuevo elemento generico tipo T a la lista
        /// </summary>
        /// <param name="newElement">Elemento genérico que se desea agregar</param>
        /// <returns></returns>
        public string addElementToJson(T newElement)
        {
            this.list.Add(newElement);
            this.saveJson();
            return this.jsonInfo;
        }
    }
}
