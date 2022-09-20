import { Component, OnInit } from '@angular/core';
import { ClienteService } from '../services/cliente.service';
import { Cliente } from '../interfaces/cliente';

@Component({
  selector: 'app-clientes',
  templateUrl: './clientes.component.html',
  styleUrls: ['./clientes.component.css']
})
export class ClientesComponent implements OnInit {
  listaClientes: Cliente[];

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
        sub.push({
          idCliente:0,
          usuario:"",
          constraseña:"",
          infoContacto:"",
          nombre:"",
          email:""
      });
      }
    } else {
      sub = this.listaClientes.slice(valor, valor+5);
    }
    return sub;
  }

  esValido(object:any){
    if (object.nombre==""){
      return false;
    }
    return true;
  }

  constructor(clienteService:ClienteService) {
    clienteService.getAllClientes().subscribe((data) =>{
      this.listaClientes = data
    })
   }

  ngOnInit(): void {
  }

}
