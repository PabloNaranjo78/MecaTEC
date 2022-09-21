import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  id: number;
  password:string;

  constructor(private route:Router, private aoth:UserService) { }

  ngOnInit(): void {
  }

  onSubmit(){
    this.aoth.verificarUsuario(this.id,this.password).subscribe({
      next: (data) => {
        this.aoth.setRespuesta(data)
        if (this.aoth.isTrabajador()){
            Swal.fire({
            icon: 'success',
            title: 'Bienvenido Trabajador'})
            this.route.navigate(['trabajadores'])
          } else if (this.aoth.isCliente()){
            Swal.fire({
            icon: 'success',
            title: 'Bienvenido Cliente'})
          this.route.navigate(['cliente'])
        } else{
            Swal.fire({
            icon: 'error',
            title: 'Contraseña Incorrecta'})
        }
      },
      error: (err) =>{
        Swal.fire({
        icon: 'error',
        title: 'Usuario no encontrado'})}
    })
  }

}


