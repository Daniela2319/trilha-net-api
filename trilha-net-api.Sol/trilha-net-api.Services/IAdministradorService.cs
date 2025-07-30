using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using trilha_net_api.Models;

namespace trilha_net_api.Services
{
    public interface IAdministradorService
    {

        Administrador Register(string email, string senha, EnumPerfil perfil);
        Administrador GetById(int id);
        List<Administrador> GetAll();


    }
}
