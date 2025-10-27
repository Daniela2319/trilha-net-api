using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace trilha_net_api.Models
{
    public class Administrador
    {
        #region Propriedades
            public int Id { get; set; }
        
            public string Email { get; set; } 
        
            public string Senha { get; set; } 
       
            public EnumPerfil Perfil { get; set; }
        #endregion

        #region Constructor
            public Administrador() { }
            public Administrador(int id, string email, string senha, EnumPerfil enumPerfil)
            {
                Id = id;
                Email = email;
                Senha = senha;
                Perfil = enumPerfil;
            }
        #endregion

        #region ToString
            public override string ToString()
            {
                return $"Id: {Id}, Email: {Email}, Senha: {Senha}, Perfil: {Perfil}";
            }
        #endregion
    }
}
