using Senai.Guffi_Tarde_WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Guffi_Tarde_WebApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        List<TipoUsuario> Listar();

        void Cadastrar(TipoUsuario novoTipoUsuario);

        void Atualizar(int id, TipoUsuario TipoUsuarioAtualizado);

        void Deletar(int id);

        TipoUsuario BuscarPorId(int id);
    }
}
