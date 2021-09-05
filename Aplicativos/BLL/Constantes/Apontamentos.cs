namespace BLL.Constantes
{
    public static class Apontamentos
    {
        public static string URLServidor { get; } = "http://localhost:5001/motic/";
        public static string LoginAdministrador { get; } = URLServidor + "Login/LoginAdministrador";
        public static string LoginAvaliador { get; } = URLServidor + "Login/LoginAvaliador";
    }
}