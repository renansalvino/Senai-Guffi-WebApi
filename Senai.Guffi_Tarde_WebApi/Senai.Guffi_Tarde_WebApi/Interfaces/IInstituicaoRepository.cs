using Senai.Guffi_Tarde_WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Guffi_Tarde_WebApi.Interfaces
{
    interface IInstituicaoRepository
    {
        List<Instituicao> Listar();

        void Cadastrar(Instituicao novoInstituicao);

        void Atualizar(int id, Instituicao InstituicaoAtualizado);

        void Deletar(int id);

        Instituicao BuscarPorId(int id);
    }
}
