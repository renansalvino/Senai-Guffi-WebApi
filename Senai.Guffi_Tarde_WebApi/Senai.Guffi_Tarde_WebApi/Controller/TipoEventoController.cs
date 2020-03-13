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
        [Produces("application/json")]
        [Route("api/[controller]")]
        [ApiController]
        public class TipoEventoController : ControllerBase
        {
            private ITipoEventoRepository _TipoEventoRepository;

            public TipoEventoController()
            {
                _TipoEventoRepository = new TipoEventoRepository();
            }

            [HttpGet]
            public IActionResult Get()
            {
                return Ok(_TipoEventoRepository.Listar());
            }

            [HttpGet("{id}")]
            public IActionResult GetById(int id)
            {
                return StatusCode(200, _TipoEventoRepository.BuscarPorId(id));
            }

            [HttpPost]
            public  IActionResult Post(TipoEvento novoTipoEvento)
            {
                _TipoEventoRepository.Cadastrar(novoTipoEvento);

                return StatusCode(200);
            }

            [HttpPut("{id}")]
            public IActionResult Put(int id, TipoEvento TipoEventoAtualizado)
            {
                TipoEvento TipoEventoBuscado = _TipoEventoRepository.BuscarPorId(id);

                if (TipoEventoBuscado != null)
                {
                    try
                    {
                        _TipoEventoRepository.Atualizar(id, TipoEventoAtualizado);

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
                TipoEvento TipoEventoBuscado = _TipoEventoRepository.BuscarPorId(id);

                if (TipoEventoBuscado == null)
                {
                    return NotFound();
                }

                _TipoEventoRepository.Deletar(id);

                return StatusCode(202);
            }
        }
}
