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
        Cliente_DireccionesList cliente_DireccionesList = new Cliente_DireccionesList();
        Cliente_TelefonosList cliente_TelefonosList = new Cliente_TelefonosList();
        Servicios_SucursalList servicios_SucursalList = new Servicios_SucursalList();
        Servicios_CitaList servicios_CitaList = new Servicios_CitaList();
        Admin_SucursalList admin_SucursalList = new Admin_SucursalList();
        FacturaList facturaList = new FacturaList();

        [HttpGet]
        [Route("trabajador/")]
        public async Task<ActionResult<List<Trabajador>>> Get(int cedula)
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
        public async Task<ActionResult<List<Trabajador>>> AddTrabajador(int idTrabajador, string nombre, string apellidos,
              string fechaIngreso, string rol, string password,
              string fechaNacimiento)
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
        public async Task<ActionResult<List<Sucursal>>> Get(string nombreSuc)
        {

            var nombreSuctemp = sucursalList.list.Find(t => t.NombreSuc == nombreSuc);

            if (nombreSuctemp == null)
                return NotFound("No se ha encontrado la sucursal " + nombreSuctemp);
            return Ok(nombreSuctemp);
        }

        [HttpPost]
        [Route("sucursal/")]
        public async Task<ActionResult<List<Sucursal>>> AddSucursal(string nombreSuc, string fechaApert, int telefono,
              string provincia, string canton, string distrito)
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
        public async Task<ActionResult<List<Servicio>>> GetServicio(string servicio)
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
        public async Task<ActionResult<List<Servicio>>> addServicio(string nombreSer, string duracion,
              int precio, int costo)
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
        public async Task<ActionResult<List<Cliente>>> GetCliete(int idCliente)
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
        public async Task<ActionResult<List<Cliente>>> addCliente(int idCliente,
              string usuario, string contraseña, string infoContacto,
              string nombre, string email)
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
        public async Task<ActionResult<List<Cita>>> GetCita(int placa)
        {

            var citaTemp = citaList.list.Find(c => c.placa == placa);

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
        public async Task<ActionResult<List<Cliente>>> addCita(Cita cita)
        {
            var citaTemp = citaList.list.Find(c => c.placa == cita.placa);
            //Agregar fecha como key

            if (citaTemp == null)
            {
                var verificadorSucursal = sucursalList.list.Find(s => s.NombreSuc == cita.sucursal);
                var verificadorCliente = clienteList.list.Find(s => s.IDCliente == cita.idCliente);

                    if (verificadorCliente != null)
                    {
                    
                    
                            if (verificadorSucursal != null)
                            {
                                Cita cita = new Cita(cita.placa, cita.fechaCita, 1, 1, cita.sucursal, cita.idCliente);
                                string result = citaList.addElementToJson(cita);
                                return Ok(result);
                            }
                            else return BadRequest("No existe la sucursal");
                        
                    }
                    else return BadRequest("No existe el cliente");

            }
            return BadRequest("La cita ya existe");
        }

        //
        [HttpGet]
        [Route("cliente-direcciones/")]
        public async Task<ActionResult<List<Cliente_Direcciones>>> GetClienteDirecciones(int idCliente)
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
        public async Task<ActionResult<List<Cliente_Direcciones>>> addClienteDirecciones(int idCliente,
              string provincia, string canton, string distrito)
        {

            var verificadorCliente = clienteList.list.Find(c => c.IDCliente == idCliente);

            if (verificadorCliente != null)
            {
                var clielteDireccionesTemp1 = cliente_DireccionesList.list.Find(c => c.IDCliente == idCliente);
                var clielteDireccionesTemp2 = cliente_DireccionesList.list.Find(c => c.Provincia == provincia);
                var clielteDireccionesTemp3 = cliente_DireccionesList.list.Find(c => c.Canton == canton);
                var clielteDireccionesTemp4 = cliente_DireccionesList.list.Find(c => c.Distrito == distrito);
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

        //
        [HttpGet]
        [Route("cliente-telefonos/")]
        public async Task<ActionResult<List<Cliente_Telefonos>>> GetClienteTelefonos(int idCliente)
        {

            var clienteTelefonosTemp = cliente_TelefonosList.list.FindAll(c => c.IDCliente == idCliente);

            if (clienteTelefonosTemp == null)
                return NotFound("No se ha encontrado la telefono " + idCliente);
            return Ok(clienteTelefonosTemp);
        }

        [HttpGet]
        [Route("all-cliente-telefonos/")]
        public async Task<ActionResult<List<Cliente_Telefonos>>> GetAllClienteTelefonos()
        {
            return Ok(cliente_TelefonosList.list);
        }
        [HttpPost]
        [Route("cliente-telefonos/")]
        public async Task<ActionResult<List<Cliente_Telefonos>>> addClienteTelefonos(int idCliente, int telefono)
        {

            var verificadorCliente = clienteList.list.Find(c => c.IDCliente == idCliente);

            if (verificadorCliente != null)
            {
                var clielteTelefonosTemp1 = cliente_TelefonosList.list.Find(c => c.IDCliente == idCliente);
                var clielteTelefonosTemp2 = cliente_TelefonosList.list.Find(c => c.Telefono == telefono);
                if ((clielteTelefonosTemp1 == null)
               || (clielteTelefonosTemp2 == null))
                {
                    Cliente_Telefonos cliente_Telefonos = new Cliente_Telefonos(idCliente, telefono);
                    string result = cliente_TelefonosList.addElementToJson(cliente_Telefonos);
                    return Ok(result);
                }
                else return BadRequest("Telefono ya registrada");
            }
            return BadRequest("Cliente no existe");
        }

        //
        [HttpGet]
        [Route("servicios-sucursal/")]
        public async Task<ActionResult<List<Servicios_Sucursal>>> GetServiciosSucursal(string servicio)
        {

            var servicioSucursalTemp = servicios_SucursalList.list.FindAll(c => c.Servicio == servicio);

            if (servicioSucursalTemp == null)
                return NotFound("No se ha encontrado la sucursal " + servicio);
            return Ok(servicioSucursalTemp);
        }

        [HttpGet]
        [Route("all-servicios-sucursal/")]
        public async Task<ActionResult<List<Servicios_Sucursal>>> GetAllServiciosSucursa()
        {
            return Ok(servicios_SucursalList.list);
        }
        [HttpPost]
        [Route("servicios-sucursal/")]
        public async Task<ActionResult<List<Servicios_Sucursal>>> addServiciosSucursa(string servicio, string sucursal)
        {

            var verificadorServicio = servicioList.list.Find(c => c.NombreServ == servicio);
            var verificadorSucursal = sucursalList.list.Find(c => c.NombreSuc == sucursal);

            if (verificadorServicio != null && verificadorSucursal != null)
            {
                var serviciosSucursalTemp1 = servicios_SucursalList.list.Find(c => c.Sucursal == sucursal);
                var serviciosSucursalTemp2 = servicios_SucursalList.list.Find(c => c.Servicio == servicio);

                if ((serviciosSucursalTemp1 == null)
               || (serviciosSucursalTemp2 == null))
                {
                    Servicios_Sucursal servicios_sucursal = new Servicios_Sucursal(servicio, sucursal);
                    string result = servicios_SucursalList.addElementToJson(servicios_sucursal);
                    return Ok(result);
                }
                else return BadRequest("Servicio ya existente");
            }
            return BadRequest("Cliente no existe");
        }

        //
        [HttpGet]
        [Route("servicios-cita/")]
        public async Task<ActionResult<List<Servicios_Cita>>> GetServiciosCita(int placa)
        {

            var servicioCitaTemp = servicios_CitaList.list.FindAll(s => s.Placa == placa);

            if (servicioCitaTemp == null)
                return NotFound("No se ha encontrado el servicio a la placa" + placa);
            return Ok(servicioCitaTemp);
        }

        [HttpGet]
        [Route("all-servicios-cita/")]
        public async Task<ActionResult<List<Servicios_Cita>>> GetAllServiciosCita()
        {
            return Ok(servicios_CitaList.list);
        }

        [HttpPost]
        [Route("servicios-cita/")]
        public async Task<ActionResult<List<Servicios_Cita>>> addServiciosCita(int placa, string servicio)
        {

            var verificadorPlaca = citaList.list.Find(c => c.placa == placa);
            var verificadorServicio = servicioList.list.Find(c => c.NombreServ == servicio);

            if (verificadorPlaca != null && verificadorServicio != null)
            {
                var serviciosCitaTemp1 = servicios_CitaList.list.Find(c => c.Placa == placa);
                var serviciosCitaTemp2 = servicios_CitaList.list.Find(c => c.Servicio == servicio);

                if ((serviciosCitaTemp1 == null)
               || (serviciosCitaTemp2 == null))
                {
                    Servicios_Cita servicios_cita = new Servicios_Cita(servicio, placa);
                    string result = servicios_CitaList.addElementToJson(servicios_cita);
                    return Ok(result);
                }
                else return BadRequest("Servicio-cita ya existente");
            }
            return BadRequest("No existe el servicio-cita");
        }

        //
        [HttpGet]
        [Route("admin-sucursal/")]
        public async Task<ActionResult<List<Admin_Sucursal>>> GetAdminSucursal(int idTrabajador)
        {

            var adminSucursalTemp = admin_SucursalList.list.FindAll(s => s.IDTrabajador == idTrabajador);

            if (adminSucursalTemp == null)
                return NotFound("No se ha encontrado el admin" + idTrabajador);
            return Ok(adminSucursalTemp);
        }

        [HttpGet]
        [Route("all-admin-sucursal/")]
        public async Task<ActionResult<List<Admin_Sucursal>>> GetAllAdminSucursal()
        {
            return Ok(admin_SucursalList.list);
        }

        [HttpPost]
        [Route("admin-sucursal/")]
        public async Task<ActionResult<List<Admin_Sucursal>>> addAdminSucursal(int idTrabajador,
              string sucursal, string fechaInicio)
        {

            var verificadorTrabajador = trabajadorList.list.Find(c => c.IDTrabajador == idTrabajador);
            var verificadorSucursal = sucursalList.list.Find(c => c.NombreSuc == sucursal);

            if (verificadorTrabajador != null && verificadorSucursal != null)
            {
                var adminSucursalTemp1 = admin_SucursalList.list.Find(c => c.IDTrabajador == idTrabajador);
                var adminSucursalTemp2 = admin_SucursalList.list.Find(c => c.Sucursal == sucursal);

                if ((adminSucursalTemp1 == null)
               || (adminSucursalTemp1 == null))
                {
                    Admin_Sucursal admin_sucursal = new Admin_Sucursal(idTrabajador, sucursal, fechaInicio);
                    string result = admin_SucursalList.addElementToJson(admin_sucursal);
                    return Ok(result);
                }
                else return BadRequest("Admin-sucursal ya existente");
            }
            return BadRequest("No existe el Admin-sucursal");
        }

        //
        [HttpGet]
        [Route("factura/")]
        public async Task<ActionResult<List<Factura>>> GetFacturas(int placa)
        {

            var facuturaTemp = facturaList.list.FindAll(s => s.Placa == placa);

            if (facuturaTemp == null)
                return NotFound("No se han encontrado citas para la placa" + placa);
            return Ok(facuturaTemp);
        }

        [HttpGet]
        [Route("all-facturas/")]
        public async Task<ActionResult<List<Admin_Sucursal>>> GetAllFacturas()
        {
            return Ok(facturaList.list);
        }

        [HttpPost]
        [Route("factura/")]
        public async Task<ActionResult<List<Factura>>> addFactura(int placa,
              int numeroFactura)
        {

            var verificadorPlaca = citaList.list.Find(c => c.placa == placa);

            if (verificadorPlaca != null)
            {
                var facturaTemp1 = facturaList.list.Find(c => c.Placa == placa);
                var facturaTemp2 = facturaList.list.Find(c => c.NumFactura == numeroFactura);

                if ((facturaTemp1 == null)
               || (facturaTemp2 == null))
                {
                    Factura admin_sucursal = new Factura(placa, numeroFactura);
                    string result = facturaList.addElementToJson(admin_sucursal);
                    return Ok(result);
                }
                else return BadRequest("Factura ya registrada");
            }
            return BadRequest("No existe la placa");
        }

    }


}
