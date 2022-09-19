import { Injectable } from '@angular/core';
import {HttpClient } from'@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class CitasService {
  RUTA_API = "https://127.0.0.1:5001/api/BaseDatosAdmin"

  constructor(public httpClient:HttpClient) {}
    getCitas(){
      return this.httpClient.get(this.RUTA_API +'/all-trabajador');
    }
}
