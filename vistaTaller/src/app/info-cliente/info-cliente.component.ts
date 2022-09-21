import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Cliente, Telefono, Direccion } from '../interfaces/cliente';
import { ClienteService } from '../services/cliente.service';
// ES6 Modules or TypeScript
import Swal from 'sweetalert2'

@Component({
  selector: 'app-info-cliente',
  templateUrl: './info-cliente.component.html',
  styleUrls: ['./info-cliente.component.css']
})
export class InfoClienteComponent implements OnInit {
  /*Cita temporal que alberga las modificaciones en el formulario
   object: Cliente*/
  cliente:Cliente={
    idCliente:0,
    usuario:"",
    contraseña:"1234",
    infoContacto:"",
    nombre:"",
    email:""
  }
  /*Telefono temporal que alberga las modificaciones en el formulario
   object: Telefono*/
  telefonoNuevo:Telefono={
    idCliente:0,
    telefono:0
  }
  /*Direccion temporal que alberga las modificaciones en el formulario
   object: Telefono*/
  direccionNueva:Direccion={
    idCliente:0,
    provincia:"",
    canton:"",
    distrito:""
  }

  /*Listas contenedoras de la data consultada en la base de datos*/
  listaClientes:Cliente[];
  listaTelefonos:Telefono[];
  listaDirecciones:Direccion[];

/*Constructor de Componente, con servicio de consulta de cliente, citas y routering 
  return void()*/
  constructor(private clienteService:ClienteService, private route:Router) {
    clienteService.getAllClientes().subscribe((data) =>{
      this.listaClientes = data
    })
  }

  ngOnInit(): void {
  }
/*Hace un GET request de los telefonoes de un cliente especifico con su id*/
  onTelefonos():void{
    this.clienteService.getTelefonos(this.cliente.idCliente).subscribe((data) =>{
      this.listaTelefonos = data;
    })
  }
  
  /*Hace un GET request de las direcciones de un cliente especifico con su id*/
  onDirecciones():void{
    this.clienteService.getDirecciones(this.cliente.idCliente).subscribe((data) =>{
      this.listaDirecciones = data;
    })
  }

  /*Llamada desde el botón "Añadir Telefono" envía un POST request al server */
  onAddTelefono():void{
    this.clienteService.addTelefono(this.telefonoNuevo).subscribe({
      /*Mensaje emergente de exito*/
      next: (data) => {
        Swal.fire({
        icon: 'success',
        title: '¡Has agregado una nuevo Teléfono a ' + this.cliente.nombre})
      this.telefonoNuevo.telefono=0},
      /*Mensaje emergente de error*/
      error: (err) =>{
        Swal.fire({
        icon: 'error',
        title: '¡Algo ha salido mal!',
        text: err.error})}
    })
  }

  /*Llamada desde el botón "Añadir Direccion" envía un POST request al server */
  onAddDireccion():void{
    this.clienteService.addDireccion(this.direccionNueva).subscribe({
      next: (data) => {
        /*Mensaje emergente de exito*/
      
        Swal.fire({
        icon: 'success',
        title: '¡Has agregado una nueva Dirección a ' + this.cliente.nombre})
      this.direccionNueva.canton="", this.direccionNueva.distrito="", this.direccionNueva.provincia=""},
      /*Mensaje emergente de error*/
      error: (err) =>{
        Swal.fire({
        icon: 'error',
        title: '¡Algo ha salido mal!',
        text: err.error})}
    })
  }
/*Llamada desde el botón "Guardar Cliente" envía un POST request al server */
  
  onSubmit(): void{
    this.clienteService.guardarCliente(this.cliente).subscribe({
      /*Mensaje emergente de exito*/
      
      next: (data) => {
        Swal.fire({
        icon: 'success',
        title: '¡Has agregado a ' + this.cliente.nombre + ' como Cliente'})
      this.route.navigate(['clientes'])},
      /*Mensaje emergente de error*/
      error: (err) =>{
        Swal.fire({
        icon: 'error',
        title: '¡Algo ha salido mal!',
        text: err.error})}
    })
  }

}

