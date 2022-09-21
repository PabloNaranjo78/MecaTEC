namespace BaseDatosAdmin.Base_de_datos.Login;

public class LoginResult
{
    public int id { get; set; }
    public string? type { set; get; }
    public bool correctPassword { set; get; }
}

public class Login { 
    public int id { get; set; }
    public string password { set; get; }
}


