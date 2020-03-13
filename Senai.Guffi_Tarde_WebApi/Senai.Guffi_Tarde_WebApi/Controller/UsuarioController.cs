using Microsoft.AspNetCore.Mvc;
using Senai.Guffi_Tarde_WebApi.Domains;
using Senai.Guffi_Tarde_WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Guffi_Tarde_WebApi.Controller
{
    
        [Produces("application/json")]
        [Route("api/[controller]")]
        [ApiController]
        public class UsuarioController : ControllerBase
        {
            private IUsuarioRepository _UsuarioRepository;

            public UsuarioController()
            {
                _UsuarioRepository = new InsituicaoRepository();
            }

            [HttpGet]
            public IActionResult Get()
            {
                return Ok(_UsuarioRepository.Listar());
            }

            [HttpGet("{id}")]
            public IActionResult GetById(int id)
            {
                return StatusCode(200, _UsuarioRepository.BuscarPorId(id));
            }

            [HttpPost]
            public IActionResult Post(Usuario novoUsuario)
            {
                _UsuarioRepository.Cadastrar(novoUsuario);

                return StatusCode(201);
            }

            [HttpPut("{id}")]
            public IActionResult Put(int id, Usuario UsuarioAtualizado)
            {
                Usuario UsuarioBuscado = _UsuarioRepository.BuscarPorId(id);

                if (UsuarioBuscado != null)
                {
                    try
                    {
                        _UsuarioRepository.Atualizar(id, UsuarioAtualizado);

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
                Usuario UsuarioBuscado = _UsuarioRepository.BuscarPorId(id);

                if (UsuarioBuscado == null)
                {
                    return NotFound();
                }

                _UsuarioRepository.Deletar(id);

                return StatusCode(202);
            }
        }
}
