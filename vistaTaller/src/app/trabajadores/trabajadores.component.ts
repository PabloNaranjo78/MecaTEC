import { Component, OnInit } from '@angular/core';
import { Trabajador } from '../interfaces/trabajador';
import { TrabajadorService } from '../services/trabajador.service';

@Component({
  selector: 'app-trabajadores',
  templateUrl: './trabajadores.component.html',
  styleUrls: ['./trabajadores.component.css']
})
export class TrabajadoresComponent implements OnInit {
  listaTrabajadores: Trabajador[];
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
    if(valor+5 > this.listaTrabajadores.length){
      sub = this.listaTrabajadores.slice(valor)
      while(sub.length!= 5){
        sub.push({
          idTrabajador:0,
          nombre:"",
          apellidos:"",
          fechaIngreso:"",
          rol:"",
          password:"",
          fechaNacimiento:""
      });
      }
    } else {
      sub = this.listaTrabajadores.slice(valor, valor+5);
    }
    return sub;
  }
  /*Valida si el objeto tiene un idCliente Valido 
  objeto: Cita[]
  return: boolean*/
  esValido(object:any){
    if (object.nombre==""){
      return false;
    }
    return true;
  }
  /*Valida si el objeto tiene un idCliente Valido 
  objeto: Cita[]
  return: boolean*/
  constructor(trabajadorService:TrabajadorService) {
    trabajadorService.getAllTrabajadores().subscribe((data) =>{
    this.listaTrabajadores = data;
  });
   }

  ngOnInit(): void {
  }

}
