using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BaseDatosAdmin.Base_de_datos.Trabajador;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BaseDatosAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseDatosAdminController : ControllerBase
    {
        [HttpGet]
        public async Task <ActionResult<List<Trabajador>>> Get()
        {

            TrabajadorList trabajadorList = new TrabajadorList();
            string list = trabajadorList.jsonInfo;

            Trabajador temp = new Trabajador(303090250, "Juann", "Monge", "1/3/2222", "Hola", "1111111", "3/3/10");
            trabajadorList.addElementToJson(temp);
            list = trabajadorList.jsonInfo;


            //string path = @"../../BaseDatosAdmin/BaseDatosAdmin/Base de datos/Trabajador/Trabajador.json";

            //StreamReader jsonStream = new StreamReader(path);

            //var json = jsonStream.ReadToEnd();
            //Console.WriteLine(json);
            //List<Trabajador> list = JsonConvert.DeserializeObject<List<Trabajador>>(json);

            //var jsonS = JsonConvert.SerializeObject(list);
            //Console.WriteLine("-->" + jsonS);


            return Ok(list);
        }


    }
}
