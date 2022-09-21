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


  esTrabajador(){
    return this.aoth.isTrabajador()
  }
  esCliente(){
    return this.aoth.isCliente()
  }

  ngOnInit(): void {
  }

}
