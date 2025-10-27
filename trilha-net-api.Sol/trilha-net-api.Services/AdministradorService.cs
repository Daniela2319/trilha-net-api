using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using trilha_net_api.Data;
using trilha_net_api.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace trilha_net_api.Services
{
    public class AdministradorService : IAdministradorService
    {
        #region Propriedades
            private Administrador _administrador;
            private OrganizerContext _organizerContext;
        #endregion

        #region Constructor
        public AdministradorService(OrganizerContext organizerContext)
            {
                this._organizerContext = organizerContext;
            }
        #endregion

        #region BuscaTodos
        public List<Administrador> GetAll()
            {
                return _organizerContext.Administradores.ToList();
            }
        #endregion

        #region BuscaPorId
        public Administrador GetById(int id)
            {
                this._administrador = GetAdmById(id);
                return this._administrador;
            }
        #endregion

        #region Cadastro
            public Administrador Register(string email, string senha, EnumPerfil perfil)
            {
                this._administrador = CreateAdm(0, email, senha, perfil);
                this._organizerContext.Administradores.Add(this._administrador);
                this._organizerContext.SaveChanges();
                return this._administrador;
            }
        #endregion

        #region Auxiliary Methods
        private Administrador GetAdmById(int id)
            {
                return this._organizerContext.Administradores.FirstOrDefault(t => t.Id == id);
            }

            private Administrador CreateAdm(int id, string email, string senha,EnumPerfil perfil)
            {
                var adm = new Administrador
                {
                    Id = id,
                    Email = email,
                    Senha = senha,
                    Perfil = perfil
                };
                return adm;
            }
        #endregion
    }
}
