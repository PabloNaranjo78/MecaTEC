import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Cliente } from '../interfaces/cliente';
import { ClienteService } from '../services/cliente.service';

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

  listaClientes:Cliente[];

  constructor(private clienteService:ClienteService, private route:Router) { 
    
    clienteService.getAllClientes().subscribe((data) =>{
      this.listaClientes = data
    })
  }

  ngOnInit(): void {
  }

  onSubmit(): void{
    this.clienteService.guardarCliente(this.cliente).subscribe(res => {alert("Success")})
  }

}
