import { Component, OnInit } from '@angular/core';
import { Route, Router } from '@angular/router';
import Swal from 'sweetalert2';
import { Trabajador } from '../interfaces/trabajador';
import { TrabajadorService } from '../services/trabajador.service';

@Component({
  selector: 'app-info-trabajador',
  templateUrl: './info-trabajador.component.html',
  styleUrls: ['./info-trabajador.component.css']
})
export class InfoTrabajadorComponent implements OnInit {
  trabajador:Trabajador={
    idTrabajador:0,
    nombre:"",
    apellidos:"",
    fechaIngreso:"",
    rol:"",
    password:"",
    fechaNacimiento:""}
  constructor(private trabajadorService:TrabajadorService, private route:Router) { }

  ngOnInit(): void {
  }
  

  onSubmit(): void{
    this.trabajadorService.guardarTrabajador(this.trabajador).subscribe({
      next: (data) => {
        Swal.fire({
        icon: 'success',
        title: '¡Has agregado a ' + this.trabajador.nombre + ' como Trabajador'})
        this.route.navigate(['trabajadores'])},
      error: (err) =>{
        Swal.fire({
        icon: 'error',
        title: '¡Algo ha salido mal!',
        text: err.error})}
    })
  }
}
