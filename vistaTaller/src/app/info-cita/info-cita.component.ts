import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
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
  cita:Cita={
    Placa:0,
    FechaCita:"",
    IDMecanico:1,
    IDAyudante:1,
    Sucursal:"",
    IDCliente:0
  }
  listaClientes:Cliente[]
  listaServicios:Servicio[]
  listaSucursales:Sucursal[]
  servicio=""

  
  constructor(private clienteService:ClienteService, private citasService:CitaService, private route:Router) {
    
    clienteService.getAllClientes().subscribe((data) =>{
      this.listaClientes = data
    })
    citasService.getAllServicios().subscribe((data) =>{
      this.listaServicios = data
    })
    citasService.getAllSucursales().subscribe((data) =>{
      this.listaSucursales = data
    })
  }

  ngOnInit(): void {
  }
  

  onSubmit(): void{
    this.citasService.save(this.cita).subscribe(res => {alert("Success")})
  }

}
