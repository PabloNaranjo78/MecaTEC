﻿namespace BaseDatosAdmin.Base_de_datos.Trabajador
{
    public class TrabajadorList : Entidad<Trabajador>
    {
        public TrabajadorList (): base("Trabajador.json")
        {
            
        }

    }

    public class Trabajador
    {
        public int NumeroCedula { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string FechaIngreso { get; set; }
        public string Rol { get; set; }
        public string Password { get; set; }
        public string FechaNacimiento { get; set; }
        public Administrador Administrador { get; set; }

        public Trabajador (int numeroCedula, string nombre, string apellidos,
            string fechaIngreso, string rol, string password, string fechaNacimiento)
        {
            NumeroCedula = numeroCedula;
            Nombre = nombre;
            Apellidos = apellidos;
            FechaIngreso = fechaIngreso;
            Rol = rol;
            Password = password;
            FechaNacimiento = fechaNacimiento;
        }

       
        
    }



    public class Administrador
    {
        public bool? Administra { get; set; }
        public object? Sucursal { get; set; }
    }
}
