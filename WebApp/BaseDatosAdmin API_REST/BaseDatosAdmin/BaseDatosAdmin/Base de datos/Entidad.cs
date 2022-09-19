using Newtonsoft.Json;
using BaseDatosAdmin.Base_de_datos;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace BaseDatosAdmin.Base_de_datos
{
    public abstract class Entidad<T>
    {
        private string jsonFileName { get; set; }

        private string path = @"C:/Users/maxta/GitHub/MecaTEC/WebApp/BaseDatosAdmin API_REST/BaseDatosAdmin/BaseDatosAdmin/Base de datos/";

        private StreamReader? reader;

        public List<T>? list { get; set; }

        public string jsonInfo { get; set; }

        public Entidad(string jsonFileName)
        {

            this.jsonFileName = jsonFileName;
            this.jsonInfo = this.getJsonString();
            this.loadJson();

        }
        public string getJsonString()
        {
            Console.WriteLine(this.path);
            Console.WriteLine(this.jsonFileName);

            reader = new StreamReader(this.path + this.jsonFileName);
            string jsonString = reader.ReadToEnd();
            reader.Close();
            return jsonString;
        }

        private void loadJson()
        {
            this.list = JsonConvert.DeserializeObject<List<T>>(jsonInfo);
            this.jsonInfo = this.getJsonString();
        }

        private void saveJson()
        {
            string tempJson = JsonConvert.SerializeObject(this.list);
            System.IO.File.WriteAllText(this.path + this.jsonFileName, tempJson);
            this.loadJson();
        }

        public string addElementToJson(T newElement)
        {
            this.list.Add(newElement);
            this.saveJson();
            return this.jsonInfo;
        }
    }
}
