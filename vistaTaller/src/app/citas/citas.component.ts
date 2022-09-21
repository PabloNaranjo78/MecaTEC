import { Component, Input, OnInit } from '@angular/core';
import { CitaService } from '../services/cita.service';
import { Cita } from '../interfaces/cita';

@Component({
  selector: 'app-citas',
  templateUrl: './citas.component.html',
  styleUrls: ['./citas.component.css']
})
export class CitasComponent implements OnInit {

  listaCitas:Cita[];
  /*Crea filas de 5 unidades a partir de índice
  valor:number 
  return: boolean*/
  crearFila(valor:number){
    if (valor%5==0){
      return true;
    }
    return false;
  }
  /*Rellena la lista con elementos nulos para conservar el espaciado
  valor:number
  return: list*/
  subLista(valor:number){
    var sub=[];
    if(valor+5 > this.listaCitas.length){
      sub = this.listaCitas.slice(valor)
      while(sub.length!= 5){
        sub.push({placa:0,
          fechaCita:"",
          idMecanico:0,
          idAyudante:0,
          sucursal:"",
          idCliente:0
      });
      }
    } else {
      sub = this.listaCitas.slice(valor, valor+5);
    }
    return sub;
  }

  /*Valida si el objeto tiene un idCliente Valido 
  objeto: Cita[]
  return: boolean*/
  esValido(object:any){
    if (object.idCliente==""){
      return false;
    }
    return true;
  }

  registrarUsuario(){
    
  }

  /*Constructor de la clase, servicio de citas inyectado 
  Consulta todas las citas disponibles a la base de datos*/
  constructor(private citaServices:CitaService) {
    citaServices.getAllCitas().subscribe((data) =>{
      this.listaCitas = data
    })
  }

  ngOnInit(): void {
    
  }

  
  public fontFamily: Object={
    default: "Montserrat"
  }

}
