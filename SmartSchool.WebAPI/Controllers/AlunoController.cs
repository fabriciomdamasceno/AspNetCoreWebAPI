using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        public List<Aluno> Alunos = new List<Aluno>() {
            new Aluno() {
                Id = 1,
                Nome = "Fabrício",
                Sobrenome = "M. Damasceno",
                Telefone = "(21) 1234-5678"
            },
            new Aluno() {
                Id = 2,
                Nome = "Michele",
                Sobrenome = "B. de Oliveira Damasceno",
                Telefone = "(21) 9876-5432"
            },
            new Aluno() {
                Id = 3,
                Nome = "Dn. Maria",
                Sobrenome = "Barbosa de Souza",
                Telefone = "(21) 1759-6321"
            },

        };
        public AlunoController() { }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
        }

        // api/aluno/byId
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("O Aluno não Foi encontrado.");
            return Ok(aluno);
        }

        // api/aluno/nome
        [HttpGet("ByName")]
        public IActionResult GetByName(string nome, string sobrenome)
        {
            var aluno = Alunos.FirstOrDefault(a =>
            a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome)
                );
            if (aluno == null) return BadRequest("O Aluno não Foi encontrado.");
            return Ok(aluno);
        }

    }
}