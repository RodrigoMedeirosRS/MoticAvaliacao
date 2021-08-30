using System.Linq;
using Microsoft.EntityFrameworkCore;

using DAO;
using DTO;
using DAL.Utils;
using DAL.Interface;

namespace DAL
{
    public class LoginDAL : ILoginDAL
    {
        private motic_avaliacaoContext DataContext { get; set; }

        public LoginDAL(motic_avaliacaoContext dataContext)
        {
            DataContext = dataContext;
        }
        public AvaliadorDTO LoginAvaliador(LoginDTO loginDTO)
        {
            var resultado = (from avaliador in DataContext.Avaliadors
                where loginDTO.CPF == avaliador.Cpf &&
                    loginDTO.Senha == avaliador.Senha
                select ConversorUtil.Mapear(avaliador)).AsNoTracking().FirstOrDefault();
            return resultado;
        }

        public AvaliadorDTO LoginAdministrador(LoginDTO loginDTO)
        {
            var resultado = (from avaliador in DataContext.Avaliadors
                join
                    administrador in DataContext.Administradors
                    on avaliador.Codigo equals administrador.Avaliador
                where loginDTO.CPF == avaliador.Cpf &&
                    loginDTO.Senha == avaliador.Senha
                select ConversorUtil.Mapear(avaliador)).AsNoTracking().FirstOrDefault();
            return resultado;
        }
    }
}