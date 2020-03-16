using Senai.Guffi_Tarde_WebApi.Domains;
using Senai.Guffi_Tarde_WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Guffi_Tarde_WebApi.Repository
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        GufiContext ctx = new GufiContext();

        public void Atualizar(int id, Instituicao InstituicaoAtualizado)
        {
            Instituicao InstituicaoBuscado = ctx.Instituicao.Find(id);

            InstituicaoBuscado.NomeFantasia = InstituicaoAtualizado.NomeFantasia;

            ctx.Instituicao.Update(InstituicaoBuscado);

            ctx.SaveChanges();
        }

        public Instituicao BuscarPorId(int id)
        {
            return ctx.Instituicao.FirstOrDefault(te => te.IdInstituicao == id);
        }

        public void Cadastrar(Instituicao novoInstituicao)
        {
            ctx.Instituicao.Add(novoInstituicao);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Instituicao.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Instituicao> Listar()
        {
            return ctx.Instituicao.ToList();
        }
    }
}
