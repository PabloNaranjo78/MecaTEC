import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cita } from '../interfaces/cita';
import { Cliente} from '../interfaces/cliente';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {
  RUTA_API = "https://127.0.0.1:7170/api/BaseDatosAdmin"
  listaClientes:Cliente[];
  constructor(private httpClient:HttpClient) {
   }
  getAllClientes(){
    return this.httpClient.get<Cliente[]>(this.RUTA_API +'/all-cliente');
   }
   guardarCliente(cliente:Cliente): Observable<Cliente>{
    console.log(cliente);
    return this.httpClient.post<Cliente>(this.RUTA_API+'/cliente',cliente);
  }
}
