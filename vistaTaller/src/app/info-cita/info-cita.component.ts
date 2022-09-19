import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-info-cita',
  templateUrl: './info-cita.component.html',
  styleUrls: ['./info-cita.component.css']
})
export class InfoCitaComponent implements OnInit {
  cliente = "Seleccione un cliente";
  sucursal = "Seleccione una sucursal";
  servicio = "Seleccione un servicio";
  placa = "";
  fecha = Date;
  constructor() { }

  ngOnInit(): void {
  }

}
