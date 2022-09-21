import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  constructor(private route:Router, private aoth:UserService){}

  /*Consulta a la base de datos si el usuario loggeado es un Trabajador 
  return: boolean*/
  esTrabajador(){
    return this.aoth.isTrabajador()
  }
  /*Consulta a la base de datos si el usuario loggeado es un Cliente 
  return: boolean*/
  esCliente(){
    return this.aoth.isCliente()
  }

  ngOnInit(): void {
  }

}
