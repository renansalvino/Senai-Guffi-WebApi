using Senai.Guffi_Tarde_WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Guffi_Tarde_WebApi.Interfaces
{
    interface IUsuarioRepository
    {
        List<Usuario> Listar();

        void Cadastrar(Usuario novoUsuario);

        void Atualizar(int id, Usuario UsuarioAtualizado);

        void Deletar(int id);

        Usuario BuscarPorId(int id);
    }
}
