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
  cliente:Cliente={
    idCliente:0,
    usuario:"",
    contraseña:"1234",
    infoContacto:"",
    nombre:"",
    email:""
  }
  telefonoNuevo:Telefono={
    idCliente:0,
    telefono:0
  }
  direccionNueva:Direccion={
    idCliente:0,
    provincia:"",
    canton:"",
    distrito:""
  }

  listaClientes:Cliente[];
  listaTelefonos:Telefono[];
  listaDirecciones:Direccion[];

  constructor(private clienteService:ClienteService, private route:Router) {
    clienteService.getAllClientes().subscribe((data) =>{
      this.listaClientes = data
    })
  }

  ngOnInit(): void {
  }

  onTelefonos():void{
    this.clienteService.getTelefonos(this.cliente.idCliente).subscribe((data) =>{
      this.listaTelefonos = data;
    })
  }
  onDirecciones():void{
    this.clienteService.getDirecciones(this.cliente.idCliente).subscribe((data) =>{
      this.listaDirecciones = data;
    })
  }

  onAddTelefono():void{
    this.clienteService.addTelefono(this.telefonoNuevo).subscribe({
      next: (data) => {
        Swal.fire({
        icon: 'success',
        title: '¡Has agregado una nuevo Teléfono a ' + this.cliente.nombre})
      this.telefonoNuevo.telefono=0},
      error: (err) =>{
        Swal.fire({
        icon: 'error',
        title: '¡Algo ha salido mal!',
        text: err.error})}
    })
  }
  onAddDireccion():void{
    this.clienteService.addDireccion(this.direccionNueva).subscribe({
      next: (data) => {
        Swal.fire({
        icon: 'success',
        title: '¡Has agregado una nueva Dirección a ' + this.cliente.nombre})
      this.direccionNueva.canton="", this.direccionNueva.distrito="", this.direccionNueva.provincia=""},
      error: (err) =>{
        Swal.fire({
        icon: 'error',
        title: '¡Algo ha salido mal!',
        text: err.error})}
    })
  }

  onSubmit(): void{
    this.clienteService.guardarCliente(this.cliente).subscribe({
      next: (data) => {
        Swal.fire({
        icon: 'success',
        title: '¡Has agregado a ' + this.cliente.nombre + ' como Cliente'})
      this.route.navigate(['clientes'])},
      error: (err) =>{
        Swal.fire({
        icon: 'error',
        title: '¡Algo ha salido mal!',
        text: err.error})}
    })
  }

}

