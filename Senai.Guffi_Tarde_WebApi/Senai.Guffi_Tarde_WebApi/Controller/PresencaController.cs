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
    //Fazer os EndPoints Extras
        [Produces("application/json")]
        [Route("api/[controller]")]
        [ApiController]
        public class PresencaController : ControllerBase
        {
            private IPresencaRepository _PresencaRepository;

            public PresencaController()
            {
                _PresencaRepository = new PresencaRepository();
            }

            [HttpGet]
            public IActionResult Get()
            {
                return Ok(_PresencaRepository.Listar());
            }

            [HttpGet("{id}")]
            public IActionResult GetById(int id)
            {
                return StatusCode(200, _PresencaRepository.BuscarPorId(id));
            }

            [HttpPost]
            public IActionResult Post(Presenca novoPresenca)
            {
                _PresencaRepository.Cadastrar(novoPresenca);

                return StatusCode(201);
            }

            [HttpPut("{id}")]
            public IActionResult Put(int id, Presenca PresencaAtualizado)
            {
                Presenca PresencaBuscado = _PresencaRepository.BuscarPorId(id);

                if (PresencaBuscado != null)
                {
                    try
                    {
                        _PresencaRepository.Atualizar(id, PresencaAtualizado);

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
                Presenca PresencaBuscado = _PresencaRepository.BuscarPorId(id);

                if (PresencaBuscado == null)
                {
                    return NotFound();
                }

                _PresencaRepository.Deletar(id);

                return StatusCode(202);
            }

            [HttpPost("{id}")]
            public IActionResult Convidar (Presenca presenca, int id)
        {
            Presenca conviteBuscado = new Presenca();
            
            if(conviteBuscado == null)
            {
                try
                {
                    _PresencaRepository.Convidar(presenca, id);
                    return StatusCode(200);
;                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }

            }
            return StatusCode(404);
        }
        [HttpGet("{presenca}/{id}")]
        public IActionResult ListarMinhas (Presenca presenca, int id)
        {
            Presenca ListaBuscada = new Presenca();
            if (ListaBuscada == null)
            {
                try
                {
                    _PresencaRepository.ListarMinhas(presenca, id);
                    return StatusCode(200);
                    ;
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }

            }
            return Ok(_PresencaRepository.ListarMinhas(presenca,id));
        }

        [HttpDelete("Reprovar/{id}")]
        public IActionResult Reprovar (Presenca presenca,int id)
        {
            Presenca BuscarPresencaASerReprovada = _PresencaRepository.BuscarPorId(id);
            if (BuscarPresencaASerReprovada == null)
            {
                try
                {
                    _PresencaRepository.ListarMinhas(presenca, id);
                    return StatusCode(200);
                    
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }

            }
            return StatusCode(404);
           
        }
        
        [HttpPost("{id}")]
        public IActionResult Aprovar (int id)
        {
            Presenca BuscarPresencaASerAprovada = _PresencaRepository.BuscarPorId(id);
            if (BuscarPresencaASerAprovada == null)
            {
                try
                {
                    _PresencaRepository.Aprovar(id);
                    return StatusCode(200);

                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }

            }
            return StatusCode(404);
        }
        }
    }

