import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';
import { Cita, Servicio, Sucursal } from '../interfaces/cita';
import { Cliente} from '../interfaces/cliente';
import { CitaService } from '../services/cita.service';
import { ClienteService } from '../services/cliente.service';

@Component({
  selector: 'app-info-cita',
  templateUrl: './info-cita.component.html',
  styleUrls: ['./info-cita.component.css']
})
export class InfoCitaComponent implements OnInit {
  /*Cita temporal que alberga las modificaciones en el formulario
   object: Cita*/
  cita:Cita={
    placa:0,
    fechaCita:"",
    idMecanico:1,
    idAyudante:1,
    sucursal:"",
    idCliente:0
  }
  /*Listas contenedoras de la data consultada en la base de datos*/
  listaClientes:Cliente[]
  listaServicios:Servicio[]
  listaSucursales:Sucursal[]
  servicio=""

  /*Constructor de Componente, con servicio de consulta de cliente, citas y routering 
  return void()*/
  constructor(private clienteService:ClienteService, private citasService:CitaService, private route:Router) {
    /*Request a los servicios de clientes con base de datos almacenados en variable local*/
    clienteService.getAllClientes().subscribe((data) =>{
      this.listaClientes = data
    })
    /*Request a los servicios de servicios con base de datos almacenados en variable local*/
    citasService.getAllServicios().subscribe((data) =>{
      this.listaServicios = data
    })
    /*Request a los servicios de sucursales con base de datos almacenados en variable local*/
    citasService.getAllSucursales().subscribe((data) =>{
      this.listaSucursales = data
    })
  }

  ngOnInit(): void {
  }
  
  /*Llamada desde el botón "Guardar" de la cita" envía un POST request al server */
  onSubmit(): void{
    this.citasService.guardarCita(this.cita).subscribe({
      /*Mensaje emergente de exito*/
      next: (data) => {
        Swal.fire({
        icon: 'success',
        title: 'Cita guarda existosamente para '+ this.cita.placa + ' el ' + this.cita.fechaCita});
      this.route.navigate(['citas'])},
      /*Mensaje emergente de error*/
      error: (err) =>{
        Swal.fire({
        icon: 'error',
        title: '¡Algo ha salido mal!',
        text: err.error})}
      })
  }
}

