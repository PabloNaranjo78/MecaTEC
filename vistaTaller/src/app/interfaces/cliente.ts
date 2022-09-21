export interface Cliente {
    idCliente:number,
    usuario:string,
    contraseña:string,
    infoContacto:string,
    nombre:string,
    email:string
}

export interface Telefono{
    idCliente:number,
    telefono:number
}

export interface Direccion{
    idCliente:number,
    provincia:string,
    canton:string,
    distrito:string
}


