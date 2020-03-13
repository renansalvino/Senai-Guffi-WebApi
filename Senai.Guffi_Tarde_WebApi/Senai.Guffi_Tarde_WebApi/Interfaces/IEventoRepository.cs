using Senai.Guffi_Tarde_WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Guffi_Tarde_WebApi.Interfaces
{
    interface IEventoRepository
    {
        List<Evento> Listar();

        void Cadastrar(Evento novoEvento);

        void Atualizar(int id, Evento EventoAtualizado);

        void Deletar(int id);

        Evento BuscarPorId(int id);
    }
}
