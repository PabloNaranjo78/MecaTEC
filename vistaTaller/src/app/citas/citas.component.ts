import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-citas',
  templateUrl: './citas.component.html',
  styleUrls: ['./citas.component.css']
})
export class CitasComponent implements OnInit {
  @Input() nombreLista: String;
  @Input() apellidoLista: String;

  listaCitas: Array<{nombre:String, apellido:String}>;

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
        sub.push({nombre: "", apellido:""});
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
    this.listaCitas.push({nombre: this.nombreLista, apellido:this.apellidoLista})
  }

  constructor() { 
    this.listaCitas=[
      {nombre:"123", apellido:"AVD"},
      {nombre:"ASD", apellido:"412"},
      {nombre:"121", apellido:"893"},
      {nombre:"MCP", apellido:"062"},
      {nombre:"PJM", apellido:"233"},
    ]
  }

  ngOnInit(): void {
    
  }

  
  public fontFamily: Object={
    default: "Montserrat"
  }

}
