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
        public class InstituicaoController : ControllerBase
        {
            private IInstituicaoRepository _InstituicaoRepository;

            public InstituicaoController()
            {
                _InstituicaoRepository = new InstituicaoRepository();
            }

            [HttpGet]
            public IActionResult Get()
            {
                return Ok(_InstituicaoRepository.Listar());
            }

            [HttpGet("{id}")]
            public IActionResult GetById(int id)
            {
                return StatusCode(200, _InstituicaoRepository.BuscarPorId(id));
            }

            [HttpPost]
            public IActionResult Post(Instituicao novoInstituicao)
            {
                _InstituicaoRepository.Cadastrar(novoInstituicao);

                return StatusCode(201);
            }

            [HttpPut("{id}")]
            public IActionResult Put(int id, Instituicao InstituicaoAtualizado)
            {
                Instituicao InstituicaoBuscado = _InstituicaoRepository.BuscarPorId(id);

                if (InstituicaoBuscado != null)
                {
                    try
                    {
                        _InstituicaoRepository.Atualizar(id, InstituicaoAtualizado);

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
                Instituicao InstituicaoBuscado = _InstituicaoRepository.BuscarPorId(id);

                if (InstituicaoBuscado == null)
                {
                    return NotFound();
                }

                _InstituicaoRepository.Deletar(id);

                return StatusCode(202);
            }
        }
    }

