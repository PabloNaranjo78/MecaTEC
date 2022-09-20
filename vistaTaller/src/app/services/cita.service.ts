import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Cita, Servicio, ServicioRequest, Sucursal} from '../interfaces/cita';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CitaService {
  RUTA_API = "https://127.0.0.1:5001/api/BaseDatosAdmin"
  listaCitas:Cita[];
  constructor(private httpClient:HttpClient) {
   }
  getAllCitas(){
    return this.httpClient.get<Cita[]>(this.RUTA_API +'/all-cita');
  }
  
  getAllSucursales(){
    return this.httpClient.get<Sucursal[]>(this.RUTA_API +'/all-sucursal');
  }
  getAllServicios(){
    return this.httpClient.get<Servicio[]>(this.RUTA_API +'/all-servicio');
  }
  getCita(cita:Cita){
    return this.httpClient.get<Servicio[]>(this.RUTA_API +'/cita?placa='+cita.placa);
  }
  
  guardarCita(cita:Cita): Observable<Cita>{
    return this.httpClient.post<Cita>(this.RUTA_API+'/cita',cita);
  }
}
