namespace BaseDatosAdmin.Base_de_datos.Login;

/// <summary>
/// Clase para obtener los valores del front end
/// </summary>
public class LoginResult
{
    public int id { get; set; }
    public string? type { set; get; }
    public bool correctPassword { set; get; }
}

/// <summary>
/// Clase para enviar los valores al front end
/// </summary>
public class Login { 
    public int id { get; set; }
    public string password { set; get; }
}


