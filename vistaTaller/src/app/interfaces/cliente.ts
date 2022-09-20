export interface Cliente {
    idCliente:number,
    usuario:string,
    constraseña:string,
    infoContacto:string,
    nombre:string,
    email:string
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
