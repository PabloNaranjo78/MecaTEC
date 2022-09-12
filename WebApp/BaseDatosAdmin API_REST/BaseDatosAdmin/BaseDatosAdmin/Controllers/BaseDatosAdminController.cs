using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BaseDatosAdmin.Base_de_datos.Trabajador;
using BaseDatosAdmin.Base_de_datos.Sucursal;
using BaseDatosAdmin.Base_de_datos.Cliente;
using BaseDatosAdmin.Base_de_datos.Servicio;
using BaseDatosAdmin.Base_de_datos.Cita;
using BaseDatosAdmin.Base_de_datos.Cliente_direcciones;
using BaseDatosAdmin.Base_de_datos.Cliente_Telefonos;
using BaseDatosAdmin.Base_de_datos.Servicios_Sucursal;
using BaseDatosAdmin.Base_de_datos.Servicios_Cita;
using BaseDatosAdmin.Base_de_datos.Admin_Sucursal;
using BaseDatosAdmin.Base_de_datos.Factura;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace BaseDatosAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseDatosAdminController : ControllerBase
    {
        TrabajadorList trabajadorList = new TrabajadorList();
        SucursalList sucursalList = new SucursalList();
        ClienteList clienteList = new ClienteList();
        ServicioList servicioList = new ServicioList();
        CitaList citaList = new CitaList();
        Cliente_Direcciones cliente_Direcciones = new Cliente_Direcciones();
        Cliente_Telefonos cliente_Telefonos = new Cliente_Telefonos();
        Servicios_Sucursal servicios_Sucursal = new Servicios_Sucursal();
        Servicios_Cita servicios_Cita = new Servicios_Cita();
        Admin_Sucursal admin_Sucursal = new Admin_Sucursal();
        Factura factura = new Factura();

        [HttpGet]
        [Route("trabajador/")]
        public async Task<ActionResult<List<Trabajador>>> Get([FromForm] int cedula)
        {

            var trabajadortemp = trabajadorList.list.Find(t => t.NumeroCedula == cedula);

            if (trabajadortemp == null)
                return NotFound("No se ha encontrado el trabajador " + cedula);
            return Ok(trabajadortemp);
        }

        [HttpGet]
        [Route("all-trabajador/")]
        public async Task<ActionResult<List<Trabajador>>> GetAllTrabajador()
        {

            return Ok(trabajadorList.list);
        }

        [HttpPost]
        [Route("trabajador/")]
        public async Task<ActionResult<List<Trabajador>>> AddTrabajador([FromForm] int cedula, [FromForm] string nombre, [FromForm] string apellidos,
            [FromForm] string fechaIngreso, [FromForm] string rol, [FromForm] string password,
            [FromForm] string fechaNacimiento)
        {

            SHA256 sha256Hash = SHA256.Create();

            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder stringbuilder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                stringbuilder.Append(bytes[i].ToString("x2"));
            }
            string hashPassword = stringbuilder.ToString();


            var trabajadortemp = trabajadorList.list.Find(t => t.NumeroCedula == cedula);
            if (trabajadortemp == null)
            {
                Trabajador trabajador = new Trabajador(cedula, nombre, apellidos, fechaIngreso, rol, hashPassword, fechaNacimiento);
                string result = trabajadorList.addElementToJson(trabajador);
                return Ok(result);
            }

            return BadRequest("Ya existe un trabajador bajo esa cédula");
        }

        [HttpGet]
        [Route("all-sucursal/")]
        public async Task<ActionResult<List<Sucursal>>> GetAllSucursal()
        {

            return Ok(sucursalList.list);
        }

        [HttpGet]
        [Route("sucursal/")]
        public async Task<ActionResult<List<Sucursal>>> Get([FromForm] string nombreSuc)
        {

            var nombreSuctemp = sucursalList.list.Find(t => t.NombreSuc == nombreSuc);

            if (nombreSuctemp == null)
                return NotFound("No se ha encontrado la sucursal " + nombreSuctemp);
            return Ok(nombreSuctemp);
        }

        [HttpPost]
        [Route("sucursal/")]
        public async Task<ActionResult<List<Sucursal>>> AddSucursal([FromForm] string nombreSuc, [FromForm] string fechaApert, [FromForm] int telefono,
            [FromForm] string provincia, [FromForm] string canton, [FromForm] string distrito)
        {

            var sucursaltemp = sucursalList.list.Find(t => t.NombreSuc == nombreSuc);
            if (sucursaltemp == null)
            {
                Sucursal sucursal = new Sucursal(nombreSuc,fechaApert,telefono,provincia,canton,distrito);
                string result = sucursalList.addElementToJson(sucursal);
                return Ok(result);
            }

            return BadRequest("Ya existe una sucursal bajo este nombre");
        }

    }

}
