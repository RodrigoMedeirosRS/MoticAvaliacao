using DTO;

namespace DAL.Interface
{
    public interface ILoginDAL
    {
        AvaliadorDTO LoginAvaliador(LoginDTO loginDTO);
        AvaliadorDTO LoginAdministrador(LoginDTO loginDTO);
    }
}