import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Trabajador } from '../interfaces/trabajador';

@Injectable({
  providedIn: 'root'
})
export class TrabajadorService {
  RUTA_API = "https://127.0.0.1:5001/api/BaseDatosAdmin"
  constructor(private httpClient:HttpClient) {
   }
  getAllTrabajadores(){
    return this.httpClient.get<Trabajador[]>(this.RUTA_API +'/all-trabajador');
   }
   guardarTrabajador(trabajador:Trabajador): Observable<Trabajador>{
    console.log(trabajador);
    return this.httpClient.post<Trabajador>(this.RUTA_API+'/trabajador',trabajador);
  }
}
