using DTO;
namespace BLL.Interface
{
    public interface ILogin
    {
        AvaliadorDTO RealizarLogin(LoginDTO login);
    }
}