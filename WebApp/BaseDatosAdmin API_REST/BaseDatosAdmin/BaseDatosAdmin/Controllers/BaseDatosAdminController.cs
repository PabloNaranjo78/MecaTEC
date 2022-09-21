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
using BaseDatosAdmin.Base_de_datos.Login;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using BaseDatosAdmin.Base_de_datos.Cliente_Direcciones;
using System.Reflection.Metadata.Ecma335;

namespace BaseDatosAdmin.Controllers
{

    /// <summary>
    /// Esta clase se encarga del manejo de los métodos que se llaman por medio del api
    /// </summary>
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

        /// <summary>
        /// Método get para obtener un determinado trabajador que está en la base de datos, en caso de no existir retornará
        /// un error 404
        /// </summary>
        /// <param name="cedula"> Número entero referente el número de cédula o id del trabajador a buscar </param>
        /// <returns>En caso de encontrarse, retorna un trabajador en forma de json, en caso contrario, un error 404</returns>
        [HttpGet]
        [Route("trabajador/")]
        public async Task<ActionResult<List<Trabajador>>> Get(int cedula)
        {

            var trabajadortemp = trabajadorList.list.Find(t => t.idTrabajador == cedula);

            if (trabajadortemp == null)
                return NotFound("No se ha encontrado el trabajador " + cedula);
            return Ok(trabajadortemp);
        }

        /// <summary>
        /// Método get para los trabajadores, retorna una lista con todos los trabajadores
        /// </summary>
        /// <returns>Retorna un array de json con todos los trabajdores</returns>
        [HttpGet]
        [Route("all-trabajador/")]
        public async Task<ActionResult<List<Trabajador>>> GetAllTrabajador()
        {

            return Ok(trabajadorList.list);
        }

        /// <summary>
        /// Método post para trabajadores, recibe una serie de parámetros establecidos en la clase TrabajadorInterface
        /// </summary>
        /// <param name="trabajadorInterface"> Un objeto con los parámetros de idTrabajador(int) nombre(string) apellidos(string)
        /// fechaIngreso(string) rol(string) password(string) fechaNacimiento(string)</param>
        /// <returns>Retorna una lista con todos los trabajadores que hay en la base de datos</returns>
        [HttpPost]
        [Route("trabajador/")]
        public async Task<ActionResult<TrabajadorInterface>> AddTrabajador(TrabajadorInterface trabajadorInterface)
        {

            SHA256 sha256Hash = SHA256.Create();

            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(trabajadorInterface.password));
            StringBuilder stringbuilder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                stringbuilder.Append(bytes[i].ToString("x2"));
            }
            string hashPassword = stringbuilder.ToString();


            var trabajadortemp = trabajadorList.list.Find(t => t.idTrabajador == trabajadorInterface.idTrabajador);
            if (trabajadortemp == null)
            {
                Trabajador trabajador = new Trabajador(trabajadorInterface.idTrabajador, trabajadorInterface.nombre,
                    trabajadorInterface.apellidos,
                    trabajadorInterface.fechaIngreso, trabajadorInterface.rol, hashPassword, trabajadorInterface.fechaNacimiento);
                string result = trabajadorList.addElementToJson(trabajador);
                return Ok(result);
            }

            return BadRequest("Ya existe un trabajador bajo esa cédula");
        }

        /// <summary>
        /// Retorna todas las sucursales que existen en la base de datos
        /// </summary>
        /// <returns>Retorna una lista con todos las sucursales</returns>
        [HttpGet]
        [Route("all-sucursal/")]
        public async Task<ActionResult<List<Sucursal>>> GetAllSucursal()
        {

            return Ok(sucursalList.list);
        }

        /// <summary>
        /// Método get que retorna una surucrsal a partir de su nombre
        /// </summary>
        /// <param name="nombreSuc"> string con el nombre de la sucursal</param>
        /// <returns></returns>
        [HttpGet]
        [Route("sucursal/")]
        public async Task<ActionResult<List<Sucursal>>> Get(string nombreSuc)
        {

            var nombreSuctemp = sucursalList.list.Find(t => t.NombreSuc == nombreSuc);

            if (nombreSuctemp == null)
                return NotFound("No se ha encontrado la sucursal " + nombreSuctemp);
            return Ok(nombreSuctemp);
        }

        /// <summary>
        /// Agrega una nueva surucal por medio de un método post
        /// </summary>
        /// <param name="nombreSuc"> string con el nombre de la sucursal</param>
        /// <param name="fechaApert">string con la fecha de apertura</param>
        /// <param name="telefono">int con el telefono de la surcursal</param>
        /// <param name="provincia">string con provincia de la sucursal</param>
        /// <param name="canton">string con el cantón de la sucursal</param>
        /// <param name="distrito">string del distrito de la sucursal</param>
        /// <returns>Retorna una la lista con todos las sucursales</returns>
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

        /// <summary>
        /// Método get para obtener un servicio
        /// </summary>
        /// <param name="servicio">string con el nombre del serivicio a buscar</param>
        /// <returns>Retorna un json con el servicio encontrado, en caso contrario, un eror 404</returns>
        [HttpGet]
        [Route("servicio/")]
        public async Task<ActionResult<List<Servicio>>> GetServicio(string servicio)
        {

            var servicioTep = servicioList.list.Find(t => t.NombreServ == servicio);

            if (servicioTep == null)
                return NotFound("No se ha encontrado el servicio " + servicio);
            return Ok(servicioTep);
        }

        /// <summary>
        /// Retorna todos los servicios que se tienen en la base de datos
        /// </summary>
        /// <returns>Json con los servicios</returns>
        [HttpGet]
        [Route("all-servicio/")]
        public async Task<ActionResult<List<Servicio>>> GetAllServicio()
        {
            return Ok(servicioList.list);
        }
        /// <summary>
        /// Método post para agregar un nuevo servicio
        /// </summary>
        /// <param name="nombreSer">string con el nombre del servicio</param>
        /// <param name="duracion">int con la duracion del servicio en horas</param>
        /// <param name="precio">int con el precio del servicio</param>
        /// <param name="costo">int con el costo del servicio</param>
        /// <returns>Json con todos los servicios que se tienen en la base de datos</returns>
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

        /// <summary>
        /// Método get para obtener un cliente específico
        /// </summary>
        /// <param name="idCliente">int con el id del cliente a buscar</param>
        /// <returns>returna un json con los datos del cliente encontrado</returns>
        [HttpGet]
        [Route("cliente/")]
        public async Task<ActionResult<List<Cliente>>> GetCliete(int idCliente)
        {

            var clienteTemp = clienteList.list.Find(c => c.idCliente == idCliente);

            if (clienteTemp == null)
                return NotFound("No se ha encontrado el cliente " + idCliente);
            return Ok(clienteTemp);
        }
        /// <summary>
        /// Método get para obtener todos los clientes que se tienen en la base de datos
        /// </summary>
        /// <returns>json con todos los clientes de la base de datos</returns>
        [HttpGet]
        [Route("all-cliente/")]
        public async Task<ActionResult<List<Cliente>>> GetAlCliente()
        {
            return Ok(clienteList.list);
        }
        /// <summary>
        /// Método post para crear un cliente, este recibe los parámetros establecidos en el interface
        /// </summary>
        /// <param name="client">un objeto con los datos de idCliente(string) usuario(string) contraseña(string)
        /// infoContacto(string) nombre(string) email(string)</param>
        /// <returns>Retorna todos los clientes que existen en la base de datos</returns>
        [HttpPost]
        [Route("cliente/")]
        public async Task<ActionResult<ClienteInterface>> addCliente(ClienteInterface client)
        {

            var clienteTemp = clienteList.list.Find(c => c.idCliente == client.idCliente);

            SHA256 sha256Hash = SHA256.Create();

            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(client.contraseña));
            StringBuilder stringbuilder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                stringbuilder.Append(bytes[i].ToString("x2"));
            }
            string hashPassword = stringbuilder.ToString();

            if (clienteTemp == null)
            {
                Cliente cliente = new(client.idCliente, client.usuario, hashPassword, client.infoContacto,
                  client.nombre, client.email);
                string result = clienteList.addElementToJson(cliente);
                return Ok(result);

            }
            return BadRequest("Cliente ya existe");
        }

        /// <summary>
        /// Método get para obtener una cita específica a partir de una placa
        /// </summary>
        /// <param name="placa">Placa de la cita a buscar (int)</param>
        /// <returns>retorna un json con los datos de la cita, caso contrario un error 404</returns>
        [HttpGet]
        [Route("cita/")]
        public async Task<ActionResult<List<Cita>>> GetCita(int placa)
        {

            var citaTemp = citaList.list.Find(c => c.placa == placa);

            if (citaTemp == null)
                return NotFound("No se ha encontrado la cita " + placa);
            return Ok(citaTemp);
        }
        /// <summary>
        /// Retorna todas las citas que se tienen en la base de datos
        /// </summary>
        /// <returns>json con los datos de todas las citas</returns>
        [HttpGet]
        [Route("all-cita/")]
        public async Task<ActionResult<List<Cita>>> GetAllCita()
        {
            return Ok(citaList.list);
        }

        /// <summary>
        /// Método post para crear una cita
        /// </summary>
        /// <param name="cita">un objeto con los parámetros de placa(int) fechaCita(string) idMecanico(int)
        /// idAyudante(int) sucursal(string) idCliente(int)</param>
        /// <returns>Retorna un json con todas las citas</returns>
        [HttpPost]
        [Route("cita/")]
        public async Task<ActionResult<List<Cita>>> addCita(Cita cita)
        {
            var citaTemp = citaList.list.Find(c => c.placa == cita.placa);

            if (citaTemp == null)
            {
                var verificadorSucursal = sucursalList.list.Find(s => s.NombreSuc == cita.sucursal);
                var verificadorCliente = clienteList.list.Find(s => s.idCliente == cita.idCliente);

                if (verificadorCliente != null)
                {


                    if (verificadorSucursal != null)
                    {
                        Cita citaa = new Cita(cita.placa, cita.fechaCita, 1, 1, cita.sucursal, cita.idCliente);
                        string result = citaList.addElementToJson(citaa);
                        return Ok(result);
                    }
                    else return BadRequest("No existe la sucursal");

                }
                else return BadRequest("No existe el cliente");

            }
            return BadRequest("La cita ya existe");
        }

        /// <summary>
        /// Retorna toda las direcciones que tiene un cliente
        /// </summary>
        /// <param name="idCliente">int con el id del cliente</param>
        /// <returns>Retorna un json con las direcciones del cliente</returns>
        [HttpGet]
        [Route("cliente-direcciones/")]
        public async Task<ActionResult<List<Cliente_Direcciones>>> GetClienteDirecciones(int idCliente)
        {

            var clienteDireccionesTemp = cliente_DireccionesList.list.FindAll(c => c.idCliente == idCliente);

            if (clienteDireccionesTemp == null)
                return NotFound("No se ha encontrado la direccion " + idCliente);
            return Ok(clienteDireccionesTemp);
        }
        /// <summary>
        /// Método get para obtener todas las direcciones que hay en la base de datos
        /// </summary>
        /// <returns>Retorna un json con todas las direcciones</returns>
        [HttpGet]
        [Route("all-cliente-direcciones/")]
        public async Task<ActionResult<List<Cliente_Direcciones>>> GetAllClienteDirecciones()
        {
            return Ok(cliente_DireccionesList.list);
        }
        /// <summary>
        /// Método post para agregar una nueva direccion
        /// </summary>
        /// <param name="cdInterface">un objeto con los parámetros de idCliente(int) provincia(string)
        /// canton(string) distrito(string)</param>
        /// <returns>Retorna todos las direcciones del cliente al cual se agregó la direccion</returns>
        [HttpPost]
        [Route("cliente-direcciones/")]
        public async Task<ActionResult<ClienteDireccionesInterface>> addClienteDirecciones(ClienteDireccionesInterface cdInterface)
        {

            var verificadorCliente = clienteList.list.Find(c => c.idCliente == cdInterface.idCliente);

            if (verificadorCliente != null)
            {
                var clielteDireccionesTemp1 = cliente_DireccionesList.list.Find(c => c.idCliente == cdInterface.idCliente);
                var clielteDireccionesTemp2 = cliente_DireccionesList.list.Find(c => c.provincia == cdInterface.provincia);
                var clielteDireccionesTemp3 = cliente_DireccionesList.list.Find(c => c.canton == cdInterface.canton);
                var clielteDireccionesTemp4 = cliente_DireccionesList.list.Find(c => c.distrito == cdInterface.distrito);
                if ((clielteDireccionesTemp1 == null)
               || (clielteDireccionesTemp2 == null)
               || (clielteDireccionesTemp3 == null)
               || (clielteDireccionesTemp4 == null))
                {
                    Cliente_Direcciones cliente_Direcciones = new Cliente_Direcciones(cdInterface.idCliente, cdInterface.provincia,
                        cdInterface.canton, cdInterface.distrito);
                    string result = cliente_DireccionesList.addElementToJson(cliente_Direcciones);
                    var clienteDireccionesTemp = cliente_DireccionesList.list.FindAll(c => c.idCliente == cdInterface.idCliente);
                    return Ok(clienteDireccionesTemp);
                }
                else return BadRequest("Dirección ya registrada");
            }
            return BadRequest("Cliente no existe");
        }

        /// <summary>
        /// Retorna todos los telefonos que tiene un cliente
        /// </summary>
        /// <param name="idCliente">int con el id del cliente a buscar</param>
        /// <returns></returns>
        [HttpGet]
        [Route("cliente-telefonos/")]
        public async Task<ActionResult<List<Cliente_Telefonos>>> GetClienteTelefonos(int idCliente)
        {

            var clienteTelefonosTemp = cliente_TelefonosList.list.FindAll(c => c.idCliente == idCliente);

            if (clienteTelefonosTemp == null)
                return NotFound("No se ha encontrado la telefono " + idCliente);
            return Ok(clienteTelefonosTemp);
        }

        /// <summary>
        /// Retorna todos los telefonos de todos los clientes
        /// </summary>
        /// <returns>Json con lost telefonos de todos los clientes</returns>
        [HttpGet]
        [Route("all-cliente-telefonos/")]
        public async Task<ActionResult<List<Cliente_Telefonos>>> GetAllClienteTelefonos()
        {
            return Ok(cliente_TelefonosList.list);
        }

        /// <summary>
        /// Método post para agregar nuevos telefonos a un cliente
        /// </summary>
        /// <param name="ctInterface">objeto con los datos de idCliente(int) telefono(int)</param>
        /// <returns></returns>
        [HttpPost]
        [Route("cliente-telefonos/")]
        public async Task<ActionResult<ClienteTelefonosInterface>> addClienteTelefonos(ClienteTelefonosInterface ctInterface)
        {

            var verificadorCliente = clienteList.list.Find(c => c.idCliente == ctInterface.idCliente);

            if (verificadorCliente != null)
            {
                var clielteTelefonosTemp1 = cliente_TelefonosList.list.Find(c => c.idCliente == ctInterface.idCliente);
                var clielteTelefonosTemp2 = cliente_TelefonosList.list.Find(c => c.telefono == ctInterface.telefono);
                if ((clielteTelefonosTemp1 == null)
               || (clielteTelefonosTemp2 == null))
                {
                    Cliente_Telefonos cliente_Telefonos = new Cliente_Telefonos(ctInterface.idCliente, ctInterface.telefono);
                    string result = cliente_TelefonosList.addElementToJson(cliente_Telefonos);
                    var clienteTelefonosTemp = cliente_TelefonosList.list.FindAll(c => c.idCliente == ctInterface.idCliente);
                    return Ok(clienteTelefonosTemp);
                }
                else return BadRequest("Telefono ya registrada");
            }
            return BadRequest("Cliente no existe");
        }

        /// <summary>
        /// Método get para obtener un servicio en específico
        /// </summary>
        /// <param name="servicio">Nombre del servicio (string)</param>
        /// <returns>Retorna un json con todos los datos del servicio a buscar</returns>
        [HttpGet]
        [Route("servicios-sucursal/")]
        public async Task<ActionResult<List<Servicios_Sucursal>>> GetServiciosSucursal(string servicio)
        {

            var servicioSucursalTemp = servicios_SucursalList.list.FindAll(c => c.Servicio == servicio);

            if (servicioSucursalTemp == null)
                return NotFound("No se ha encontrado la sucursal " + servicio);
            return Ok(servicioSucursalTemp);
        }

        /// <summary>
        /// Método que retorna todos los servicios de una sucursal
        /// </summary>
        /// <returns>Json con todos los servicios</returns>
        [HttpGet]
        [Route("all-servicios-sucursal/")]
        public async Task<ActionResult<List<Servicios_Sucursal>>> GetAllServiciosSucursa()
        {
            return Ok(servicios_SucursalList.list);
        }
        /// <summary>
        /// Método para agregar un nuevo servicio a una sucursal
        /// </summary>
        /// <param name="servicio">nombre del servicio(string)</param>
        /// <param name="sucursal">nombre de la sucursal(string)</param>
        /// <returns>Json con todos los servicios y sucursales</returns>
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

        /// <summary>
        /// Método get para obtener un servicio asignado a una cita
        /// </summary>
        /// <param name="placa">int de la placa</param>
        /// <returns>json con la cita relacionada a un servicio</returns>
        [HttpGet]
        [Route("servicios-cita/")]
        public async Task<ActionResult<List<Servicios_Cita>>> GetServiciosCita(int placa)
        {

            var servicioCitaTemp = servicios_CitaList.list.FindAll(s => s.Placa == placa);

            if (servicioCitaTemp == null)
                return NotFound("No se ha encontrado el servicio a la placa" + placa);
            return Ok(servicioCitaTemp);
        }
        /// <summary>
        /// Método get para obtener todos los servicios relacionados a una cita
        /// </summary>
        /// <returns>Json con los servicios-cita</returns>
        [HttpGet]
        [Route("all-servicios-cita/")]
        public async Task<ActionResult<List<Servicios_Cita>>> GetAllServiciosCita()
        {
            return Ok(servicios_CitaList.list);
        }

        /// <summary>
        /// Método para agregar un servicio a una cita
        /// </summary>
        /// <param name="placa">int de placa</param>
        /// <param name="servicio">string de nombre del servicio</param>
        /// <returns></returns>
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

            var verificadorTrabajador = trabajadorList.list.Find(c => c.idTrabajador == idTrabajador);
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

        /// <summary>
        /// Método post encargado de verificar el inicio se sesión
        /// </summary>
        /// <param name="login"> objeto con id(int) password(string)</param>
        /// <returns>Retorna un json con el resultado del inicio de sesion y el tipo de usuario que es</returns>
        [HttpPost]
        [Route("login/")]
        public async Task<ActionResult<LoginResult>> login(Login login)
        {

            var trabajadorVer = trabajadorList.list.Find(t => t.idTrabajador == login.id);
            LoginResult loginResult;

            SHA256 sha256Hash = SHA256.Create();

            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(login.password));
            StringBuilder stringbuilder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                stringbuilder.Append(bytes[i].ToString("x2"));
            }
            string hashPassword = stringbuilder.ToString();


            if (trabajadorVer != null)
            {
                if (hashPassword == trabajadorVer.password)
                {
                    loginResult = new LoginResult { id = login.id, correctPassword = true, type = "Trabajador" };
                }
                else
                {
                    loginResult = new LoginResult { id = login.id, correctPassword = false, type = "Trabajador" };
                }
                return Ok(loginResult);
            }
            var clienteVer = clienteList.list.Find(c => c.idCliente == login.id);
            if (clienteVer != null)
            {
                if (hashPassword == clienteVer.contraseña)
                {
                    loginResult = new LoginResult { id = login.id, correctPassword = true, type = "Cliente" };
                }
                else
                {
                    loginResult = new LoginResult { id = login.id, correctPassword = false, type = "Cliente" };
                }
                return Ok(loginResult);
            }

            return BadRequest("No existe el id");

        }

    }


}
