import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cita } from '../interfaces/cita';
import { Cliente, Direccion, Telefono} from '../interfaces/cliente';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {
  RUTA_API = "https://127.0.0.1:5001/api/BaseDatosAdmin"
  listaClientes:Cliente[];
  constructor(private httpClient:HttpClient) {
   }
  getAllClientes(){
    return this.httpClient.get<Cliente[]>(this.RUTA_API +'/all-cliente');
   }
   guardarCliente(cliente:Cliente): Observable<Cliente>{
    return this.httpClient.post<Cliente>(this.RUTA_API+'/cliente',cliente);
  }
  getTelefonos(id:number): Observable<Telefono[]>{
    return this.httpClient.get<Telefono[]>(this.RUTA_API+'/cliente-telefonos/?idCliente=' + id);
  }

  addTelefono(tel:Telefono): Observable<Telefono>{
    return this.httpClient.post<Telefono>(this.RUTA_API+'/cliente-telefonos', tel);
  }

  getDirecciones(id:number): Observable<Direccion[]>{
    return this.httpClient.get<Direccion[]>(this.RUTA_API+'/cliente-direcciones/?idCliente=' + id);
  }

  addDireccion(dir:Direccion): Observable<Direccion>{
    console.log(dir);
    return this.httpClient.post<Direccion>(this.RUTA_API+'/cliente-direcciones', dir);
  }
}
