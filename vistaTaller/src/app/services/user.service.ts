import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Usuario } from '../interfaces/usuario';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  user:Usuario={
    id:0,
    type:"",
    correctPassword:false
  };
  RUTA_API = "https://127.0.0.1:5001/api/BaseDatosAdmin"

  constructor(private httpClient:HttpClient) {
   }

   isTrabajador(){
    if(this.user.correctPassword && this.user.type == "Trabajador"){
      return true;
    }
    return false;
   }
   isCliente(){
    if(this.user.correctPassword && this.user.type == "Cliente"){
      return true;
    }
    return false;
   }
   setRespuesta(u:Usuario){
    this.user.id = u.id,
    this.user.type = u.type,
    this.user.correctPassword = u.correctPassword
   }

  verificarUsuario(idN:number, pas:string): Observable<Usuario>{
    return this.httpClient.post<Usuario>(this.RUTA_API+'/login',{id:idN, password:pas});
  }
}
