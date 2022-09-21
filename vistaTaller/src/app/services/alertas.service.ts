import { Injectable } from '@angular/core';
import Swal from 'sweetalert2';

@Injectable({
  providedIn: 'root'
})
export class AlertasService {
  constructor() { }
  successButton(mensaje:string){
    Swal.fire({
      title:mensaje,
      icon: 'success'
    })
  }
  errorButton(mensaje:string){
    Swal.fire({
      title:mensaje,
      icon: 'error'
    })
  }
}
