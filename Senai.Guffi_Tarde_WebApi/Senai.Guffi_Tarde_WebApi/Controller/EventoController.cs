using Microsoft.AspNetCore.Mvc;
using Senai.Guffi_Tarde_WebApi.Domains;
using Senai.Guffi_Tarde_WebApi.Interfaces;
using Senai.Guffi_Tarde_WebApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Guffi_Tarde_WebApi.Controller
{
    public class EventoController
    {
        [Produces("application/json")]
        [Route("api/[controller]")]
        [ApiController]
        public class TipoEventoController : ControllerBase
        {
            private IEventoRepository _EventoRepository;

            public TipoEventoController()
            {
                _EventoRepository = new EventoRepository();
            }

            [HttpGet]
            public IActionResult Get()
            {
                return Ok(_EventoRepository.Listar());
            }

            [HttpGet("{id}")]
            public IActionResult GetById(int id)
            {
                return StatusCode(200, _EventoRepository.BuscarPorId(id));
            }

            [HttpPost]
            public IActionResult Post(Evento novoEvento)
            {
                _EventoRepository.Cadastrar(novoEvento);

                return StatusCode(201);
            }

            [HttpPut("{id}")]
            public IActionResult Put(int id, Evento EventoAtualizado)
            {
                Evento EventoBuscado = _EventoRepository.BuscarPorId(id);

                if (EventoBuscado != null)
                {
                    try
                    {
                        _EventoRepository.Atualizar(id, EventoAtualizado);

                        return StatusCode(200);
                    }
                    catch (Exception erro)
                    {
                        return BadRequest(erro);
                    }
                }

                return StatusCode(404);
            }

            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                Evento EventoBuscado = _EventoRepository.BuscarPorId(id);

                if (EventoBuscado == null)
                {
                    return NotFound();
                }

                _EventoRepository.Deletar(id);

                return StatusCode(202);
            }
        }
    }
}

