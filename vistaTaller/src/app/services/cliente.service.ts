import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Cliente} from '../interfaces/cliente';

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
}
