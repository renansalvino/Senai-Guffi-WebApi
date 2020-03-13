using Senai.Guffi_Tarde_WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Guffi_Tarde_WebApi.Interfaces
{
    interface IPresencaRepository
    {
        List<Presenca> Listar();

        void Cadastrar(Presenca novoPresenca);

        void Atualizar(int id, Presenca PresencaAtualizado);

        void Deletar(int id);

        Presenca BuscarPorId(int id);

        List<Presenca> ListarMinhas(Presenca presenca, int id);

        Presenca Convidar(Presenca presenca, int id );

        void Aprovar(int id);

        void Reprovar(int id);

        void Inscricao(Presenca presenca );
    }
}
