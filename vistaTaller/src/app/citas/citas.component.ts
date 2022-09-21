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
  crearFila(valor:number){
    if (valor%5==0){
      return true;
    }
    return false;
  }

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

  esValido(object:any){
    if (object.idCliente==""){
      return false;
    }
    return true;
  }

  registrarUsuario(){
    
  }

  
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
