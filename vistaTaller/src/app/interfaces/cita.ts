export interface Cita {
    placa:number,
    fechaCita:string,
    idMecanico:number,
    idAyudante:number,
    sucursal:string,
    idCliente:number
}

export interface Sucursal{
    nombreSuc:string,
    fechaApert:string,
    telefono:number,
    provincia:string,
    canton:string,
    distrito:string
} 

export interface Servicio{
    nombreServ:string,
    duracion:string,
    precio:number,
    costo:number
}

export interface ServicioRequest{
    NombreServ:string,
    Duracion:string,
    Precio:number,
    Costo:number
}