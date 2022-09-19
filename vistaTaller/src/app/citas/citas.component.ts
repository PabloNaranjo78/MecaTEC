import { Component, Input, OnInit } from '@angular/core';
import { CitasService } from '../services/citas.service';
import { HttpClient } from '@angular/common/http';
import { Citas } from '../interfaces/citas';

@Component({
  selector: 'app-citas',
  templateUrl: './citas.component.html',
  styleUrls: ['./citas.component.css']
})
export class CitasComponent implements OnInit {
  listaCitas:Citas[];
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
      sub = this.listaCitas.slice(valor, valor+5);
    }
    return sub;
  }

  esValido(object:any){
    if (object.nombre==""){
      return false;
    }
    return true;
  }

  registrarUsuario(){
    
  }

  
  RUTA_API = "https://127.0.0.1:5001/api/BaseDatosAdmin";  
  
  constructor(private citasServicesssssssss:CitasService, private httpClient:HttpClient ) {
    httpClient.get<Citas[]>(this.RUTA_API +'/all-trabajador').subscribe((data) =>{
      this.listaCitas = data,
      console.log(this.listaCitas)
      console.log(this.listaCitas.length)
    })
  }

  ngOnInit(): void {
    
  }

  
  public fontFamily: Object={
    default: "Montserrat"
  }

}
