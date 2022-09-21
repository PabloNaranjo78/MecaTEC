import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-cita',
  templateUrl: './cita.component.html',
  styleUrls: ['./cita.component.css']
})
export class CitaComponent implements OnInit {
  
  mensaje="";
  registrado=false;
  nombre:String="";
  apellido:String="";


  constructor() { }

  ngOnInit(): void {
  }

}
