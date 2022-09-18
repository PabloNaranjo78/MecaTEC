import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-clientes',
  templateUrl: './clientes.component.html',
  styleUrls: ['./clientes.component.css']
})
export class ClientesComponent implements OnInit {
  listaClientes: Array<{fullName:String, infoContacto:String, cedula:number, usuario:String, email:String}>;

  crearFila(valor:number){
    if (valor%5==0){
      return true;
    }
    return false;
  }

  subLista(valor:number){
    var sub=[];
    if(valor+5 > this.listaClientes.length){
      sub = this.listaClientes.slice(valor)
      while(sub.length!= 5){
        sub.push({fullName:"", infoContacto:"", cedula:0, usuario:"", email:""});
      }
    } else {
      sub = this.listaClientes.slice(valor, valor+5);
    }
    return sub;
  }

  esValido(object:any){
    if (object.fullName==""){
      return false;
    }
    return true;
  }

  constructor() {
    this.listaClientes=[
      {fullName:"Andy Ramírez", infoContacto:"Secretario", cedula:63070773, usuario:"andyrrr", email:"andy@gmail.com"},
      {fullName:"Pablo Naranjo", infoContacto:"Director", cedula:67869345, usuario:"pablonjo", email:"naranjopablo@gmail.com"},
      {fullName:"Fernando Monge", infoContacto:"Pariente", cedula:89764675, usuario:"fndox", email:"fernan48@gmail.com"},
      {fullName:"Joel Zúniga", infoContacto:"Pariente", cedula:89687382, usuario:"joe67", email:"zngjoel@gmail.com"}
    ]
   }

  ngOnInit(): void {
  }

}
