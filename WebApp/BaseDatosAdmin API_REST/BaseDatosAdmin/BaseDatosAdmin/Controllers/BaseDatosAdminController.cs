﻿using Microsoft.AspNetCore.Http;
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
        Cliente_DireccionesList cliente_DireccionesList = new Cliente_DireccionesList();
        Cliente_Telefonos cliente_Telefonos = new Cliente_Telefonos();
        Servicios_Sucursal servicios_Sucursal = new Servicios_Sucursal();
        Servicios_Cita servicios_Cita = new Servicios_Cita();
        Admin_Sucursal admin_Sucursal = new Admin_Sucursal();
        Factura factura = new Factura();

        [HttpGet]
        [Route("trabajador/")]
        public async Task<ActionResult<List<Trabajador>>> Get([FromForm] int cedula)
        {

            var trabajadortemp = trabajadorList.list.Find(t => t.IDTrabajador == cedula);

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
        public async Task<ActionResult<List<Trabajador>>> AddTrabajador([FromForm] int idTrabajador, [FromForm] string nombre, [FromForm] string apellidos,
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


            var trabajadortemp = trabajadorList.list.Find(t => t.IDTrabajador == idTrabajador);
            if (trabajadortemp == null)
            {
                Trabajador trabajador = new Trabajador(idTrabajador, nombre, apellidos, fechaIngreso, rol, hashPassword, fechaNacimiento);
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
                Sucursal sucursal = new Sucursal(nombreSuc, fechaApert, telefono, provincia, canton, distrito);
                string result = sucursalList.addElementToJson(sucursal);
                return Ok(result);
            }

            return BadRequest("Ya existe una sucursal bajo este nombre");
        }
        [HttpGet]
        [Route("servicio/")]
        public async Task<ActionResult<List<Servicio>>> GetServicio([FromForm] string servicio)
        {

            var servicioTep = servicioList.list.Find(t => t.NombreServ == servicio);

            if (servicioTep == null)
                return NotFound("No se ha encontrado el servicio " + servicio);
            return Ok(servicioTep);
        }

        [HttpGet]
        [Route("all-servicio/")]
        public async Task<ActionResult<List<Servicio>>> GetAllServicio()
        {
            return Ok(servicioList.list);
        }
        [HttpPost]
        [Route("servicio/")]
        public async Task<ActionResult<List<Servicio>>> addServicio([FromForm] string nombreSer, [FromForm] string duracion,
            [FromForm] int precio, [FromForm] int costo)
        {
            var servicioTemp = servicioList.list.Find(s => s.NombreServ == nombreSer);

            if (servicioTemp == null)
            {
                Servicio servicio = new Servicio(nombreSer, duracion, precio, costo);
                string result = servicioList.addElementToJson(servicio);
                return Ok(result);

            }
            return BadRequest("El servicio ya existe");
        }


        [HttpGet]
        [Route("cliente/")]
        public async Task<ActionResult<List<Cliente>>> GetCliete([FromForm] int idCliente)
        {

            var clienteTemp = clienteList.list.Find(c => c.IDCliente == idCliente);

            if (clienteTemp == null)
                return NotFound("No se ha encontrado el cliente " + idCliente);
            return Ok(clienteTemp);
        }

        [HttpGet]
        [Route("all-cliente/")]
        public async Task<ActionResult<List<Cliente>>> GetAlCliente()
        {
            return Ok(clienteList.list);
        }
        [HttpPost]
        [Route("cliente/")]
        public async Task<ActionResult<List<Cliente>>> addCliente([FromForm] int idCliente,
            [FromForm] string usuario, [FromForm] string contraseña, [FromForm] string infoContacto,
            [FromForm] string nombre, [FromForm] string email)
        {
            //Hay que validar el email
            var clienteTemp = clienteList.list.Find(c => c.IDCliente == idCliente);

            SHA256 sha256Hash = SHA256.Create();

            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(contraseña));
            StringBuilder stringbuilder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                stringbuilder.Append(bytes[i].ToString("x2"));
            }
            string hashPassword = stringbuilder.ToString();

            if (clienteTemp == null)
            {
                Cliente cliente = new Cliente(idCliente, usuario, hashPassword, infoContacto, nombre, email);
                string result = clienteList.addElementToJson(cliente);
                return Ok(result);

            }
            return BadRequest("El cliente ya existe");
        }

        //
        [HttpGet]
        [Route("cita/")]
        public async Task<ActionResult<List<Cita>>> GetCita([FromForm] int placa)
        {

            var citaTemp = citaList.list.Find(c => c.Placa == placa);

            if (citaTemp == null)
                return NotFound("No se ha encontrado la cita " + placa);
            return Ok(citaTemp);
        }

        [HttpGet]
        [Route("all-cita/")]
        public async Task<ActionResult<List<Cita>>> GetAllCita()
        {
            return Ok(citaList.list);
        }
        [HttpPost]
        [Route("cita/")]
        public async Task<ActionResult<List<Cliente>>> addCita([FromForm] int placa, [FromForm] string fechaCita,
            [FromForm] int idMecanico, [FromForm] int idAyudante, [FromForm] string sucursal, [FromForm] int idCliente)
        {
            var citaTemp = citaList.list.Find(c => c.Placa == placa);


            if (citaTemp == null)
            {
                var verificadorMecanico = trabajadorList.list.Find(t => t.IDTrabajador == idMecanico);
                var verificadorAyudante = trabajadorList.list.Find(t => t.IDTrabajador == idAyudante);
                var verificadorSucursal = sucursalList.list.Find(s => s.NombreSuc == sucursal);
                var verificadorCliente = clienteList.list.Find(s => s.IDCliente == idCliente);

                if (verificadorMecanico != null)
                {
                    if (verificadorCliente != null)
                    {
                        if (verificadorAyudante != null)
                        {
                            if (verificadorSucursal != null)
                            {
                                Cita cita = new Cita(placa, fechaCita, idMecanico, idAyudante, sucursal, idCliente);
                                string result = citaList.addElementToJson(cita);
                                return Ok(result);
                            }
                            else return BadRequest("No existe la sucursal");
                        }
                        else return BadRequest("No existe el trabajador ayudante");
                    }
                    else return BadRequest("No existe el cliente");

                }
                else return BadRequest("Mecanico no existe");

            }
            return BadRequest("La cita ya existe");
        }

        //
        [HttpGet]
        [Route("cliente-direcciones/")]
        public async Task<ActionResult<List<Cliente_Direcciones>>> GetClienteDirecciones([FromForm] int idCliente)
        {

            var clienteDireccionesTemp = cliente_DireccionesList.list.FindAll(c => c.IDCliente == idCliente);

            if (clienteDireccionesTemp == null)
                return NotFound("No se ha encontrado la direccion " + idCliente);
            return Ok(clienteDireccionesTemp);
        }

        [HttpGet]
        [Route("all-cliente-direcciones/")]
        public async Task<ActionResult<List<Cliente_Direcciones>>> GetAllClienteDirecciones()
        {
            return Ok(cliente_DireccionesList.list);
        }
        [HttpPost]
        [Route("cliente-direcciones/")]
        public async Task<ActionResult<List<Cliente_Direcciones>>> addClienteDirecciones([FromForm] int idCliente,
            [FromForm] string provincia, [FromForm] string canton, [FromForm] string distrito)
        {
            var clielteDireccionesTemp1 = cliente_DireccionesList.list.Find(c => c.IDCliente == idCliente);
            var clielteDireccionesTemp2 = cliente_DireccionesList.list.Find(c => c.Provincia == provincia);
            var clielteDireccionesTemp3 = cliente_DireccionesList.list.Find(c => c.Canton == canton);
            var clielteDireccionesTemp4 = cliente_DireccionesList.list.Find(c => c.Distrito == distrito);
            var verificadorCliente = clienteList.list.Find(c => c.IDCliente == idCliente);

            if (verificadorCliente != null)
            {
                if ((clielteDireccionesTemp1 == null)
               || (clielteDireccionesTemp2 == null)
               || (clielteDireccionesTemp3 == null)
               || (clielteDireccionesTemp4 == null))
                {
                    Cliente_Direcciones cliente_Direcciones = new Cliente_Direcciones(idCliente, provincia, canton, distrito);
                    string result = cliente_DireccionesList.addElementToJson(cliente_Direcciones);
                    return Ok(result);
                }
                else return BadRequest("Dirección ya registrada");


            }
            return BadRequest("Cliente no existe");
        }

    }


}
