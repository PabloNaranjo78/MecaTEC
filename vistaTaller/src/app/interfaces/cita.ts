export interface Cita {
    Placa:number,
    FechaCita:string,
    IDMecanico:number,
    IDAyudante:number,
    Sucursal:string,
    IDCliente:number
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