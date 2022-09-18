import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-citas',
  templateUrl: './citas.component.html',
  styleUrls: ['./citas.component.css']
})
export class CitasComponent implements OnInit {
  mensaje="";
  registrado=false;
  nombre:String="";
  apellido:String="";
  entradas: Array<{nombre:String, apellido:String}>;

  registrarUsuario(){
    this.entradas.push({nombre: this.nombre, apellido:this.apellido})
  }

  constructor() { 
    this.entradas=[
      {nombre:"empleado", apellido:"1"},
      {nombre:"empleado", apellido:"2"},
      {nombre:"empleado", apellido:"3"},
      {nombre:"empleado", apellido:"4"},
      {nombre:"empleado", apellido:"5"},
    ]
  }

  ngOnInit(): void {
    
  }

  
  public fontFamily: Object={
    default: "Montserrat"
  }

}
