using Microsoft.EntityFrameworkCore;
using Senai.Guffi_Tarde_WebApi.Domains;
using Senai.Guffi_Tarde_WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Guffi_Tarde_WebApi.Repository
{    

    public class PresencaRepository : IPresencaRepository
    {
        GufiContext ctx = new GufiContext();

        public void Aprovar(int id)
        {
            ctx.Presenca.Add(BuscarPorId(id));
            ctx.SaveChanges();
        }

        public void Atualizar(int id, Presenca PresencaAtualizado)
        {
            Presenca PresencaBuscado = ctx.Presenca.Find(id);

            PresencaBuscado.Situacao = PresencaAtualizado.Situacao;

            ctx.Presenca.Update(PresencaBuscado);

            ctx.SaveChanges();
        }

        public Presenca BuscarPorId(int id)
        {
            return ctx.Presenca.FirstOrDefault(te => te.IdPresenca == id);
        }

        public void Cadastrar(Presenca novoPresenca)
        {
            ctx.Presenca.Add(novoPresenca);

            ctx.SaveChanges();
        }

        public Presenca Convidar(Presenca presenca, int id) // idUsuario = x, idEvento = y;
        {
            presenca.Situacao = "Agendada";
            ctx.Presenca.Add(presenca);
            ctx.Presenca.FirstOrDefault(e => e.IdUsuario == id );

            return presenca;
        }

        public void Deletar(int id)
        {
            ctx.Presenca.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public void Inscricao(Presenca presenca)
        {
            presenca.Situacao = "Agendada";
            ctx.Presenca.Add(presenca);
            ctx.SaveChanges();
        }

        public List<Presenca> Listar()
        {
            return ctx.Presenca.ToList();
        }

        public List<Presenca> ListarMinhas(Presenca presenca, int id)
        {
            ctx.Presenca.FirstOrDefault(e => e.IdUsuario == id);
            return ctx.Presenca.Include(x => x.IdUsuario).ToList();
        }

        public void Reprovar(int id)
        {
             ctx.Presenca.Remove(BuscarPorId(id));

             ctx.SaveChanges();
        }
    }
}
