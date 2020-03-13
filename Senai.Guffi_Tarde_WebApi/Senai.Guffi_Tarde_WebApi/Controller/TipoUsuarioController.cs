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
        public class TipoUsuarioController : ControllerBase
        {
            private ITipoUsuarioRepository _TipoUsuarioRepository;

            public TipoUsuarioController()
            {
                _TipoUsuarioRepository = new TipoUsuarioRepository();
            }

            [HttpGet]
            public IActionResult Get()
            {
                return Ok(_TipoUsuarioRepository.Listar());
            }

            [HttpGet("{id}")]
            public IActionResult GetById(int id)
            {
                return StatusCode(200, _TipoUsuarioRepository.BuscarPorId(id));
            }

            [HttpPost]
            public IActionResult Post(TipoUsuario novoTipoUsuario)
            {
                _TipoUsuarioRepository.Cadastrar(novoTipoUsuario);

                return StatusCode(201);
            }

            [HttpPut("{id}")]
            public IActionResult Put(int id, TipoUsuario TipoUsuarioAtualizado)
            {
                TipoUsuario TipoUsuarioBuscado = _TipoUsuarioRepository.BuscarPorId(id);

                if (TipoUsuarioBuscado != null)
                {
                    try
                    {
                        _TipoUsuarioRepository.Atualizar(id, TipoUsuarioAtualizado);

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
                TipoUsuario TipoUsuarioBuscado = _TipoUsuarioRepository.BuscarPorId(id);

                if (TipoUsuarioBuscado == null)
                {
                    return NotFound();
                }

                _TipoUsuarioRepository.Deletar(id);

                return StatusCode(202);
            }
        }
}
