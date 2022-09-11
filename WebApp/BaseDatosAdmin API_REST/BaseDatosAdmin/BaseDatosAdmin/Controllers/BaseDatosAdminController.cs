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
        TrabajadorList trabajadorList = new TrabajadorList();

        [HttpGet]
        [Route("trabajador/")]
        public async Task <ActionResult<List<Trabajador>>> Get([FromForm] int cedula)
        {

            var trabajadortemp = trabajadorList.list.Find(t => t.NumeroCedula == cedula);

            if (trabajadortemp == null)
                return BadRequest("No se ha encontrado el trabajador " + cedula);
            return Ok(trabajadortemp);
        }

        [HttpPost]
        [Route("trabajador/")]
        public async Task<ActionResult<List<Trabajador>>> AddTrabajador([FromForm] int cedula, [FromForm] string nombre, [FromForm] string apellidos, 
            [FromForm] string fechaIngreso, [FromForm] string rol, [FromForm] string password, 
            [FromForm] string fechaNacimiento)
        {
            TrabajadorList trabajadorList = new TrabajadorList();
            var trabajadortemp = trabajadorList.list.Find(t => t.NumeroCedula == cedula);
            if (trabajadortemp == null) {
                Trabajador trabajador = new Trabajador(cedula, nombre, apellidos, fechaIngreso, rol, password, fechaNacimiento);
                string result = trabajadorList.addElementToJson(trabajador);
                return Ok(result);
            }

            return BadRequest("Ya existe un trabajador bajo esa cédula");
        }


    }
}
