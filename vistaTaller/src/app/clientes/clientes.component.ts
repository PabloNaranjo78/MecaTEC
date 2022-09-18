import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-clientes',
  templateUrl: './clientes.component.html',
  styleUrls: ['./clientes.component.css']
})
export class ClientesComponent implements OnInit {
  
  number=[1,2,3,4,5,6,7,8,9,10,11]

  crearFila(valor:number){
    if (valor%5==0){
      return true;
    }
    return false;
  }

  subLista(valor:number){
    var sub=[];
    if(valor+5 > this.number.length){
      sub = this.number.slice(valor)
      while(sub.length!= 5){
        sub.push(0);
      }
    } else {
      sub = this.number.slice(valor, valor+5);
    }
    return sub;
  }

  esValido(valor:number){
    if (valor==0){
      return false;
    }
    return true;
  }

  constructor() { }

  ngOnInit(): void {
  }

}
