using Microsoft.AspNetCore.Mvc;
using TrilhaApiDesafio.Context;
using TrilhaApiDesafio.Models;

namespace TrilhaApiDesafio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly OrganizadorContext _context;

        public TarefaController(OrganizadorContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var objtarefa = _context.Tarefas.Find(id);
            if (objtarefa == null)
                return NotFound(new { Retorno = "Nenhum registro encontrado." });

            return Ok(objtarefa);
        }

        [HttpGet("ObterTodos")]
        public IActionResult ObterTodos()
        {
            var objlisttarefas = _context.Tarefas.ToList();
            if (objlisttarefas.Count == 0)
                return NotFound(new {Retorno = "Nenhum registro encontrado."});

            return Ok(objlisttarefas);
        }

        [HttpGet("ObterPorTitulo")]
        public IActionResult ObterPorTitulo(string titulo)
        {
            var tarefa = _context.Tarefas.Where(x => x.Titulo.Contains(titulo));
            if (tarefa.Any() == false)
                return NotFound(new {Retorno = "Nenhum registro encontrado."});

            return Ok(tarefa);
        }

        [HttpGet("ObterPorData")]
        public IActionResult ObterPorData(DateTime data)
        {
            var tarefa = _context.Tarefas.Where(x => x.DataInc.Date == data.Date);
            return Ok(tarefa);
        }

        [HttpGet("ObterPorStatus")]
        public IActionResult ObterPorStatus(EnumStatusTarefa status)
        {
            var objlisttarefas = _context.Tarefas.Where(x => x.Status == status).ToList();
            if (objlisttarefas.Count == 0)
                return NotFound(new {Retorno = "Nenhum registro encontrado."});

            return Ok(objlisttarefas);
        }

        [HttpPost]
        public IActionResult Criar(Tarefa tarefa)
        {
            if (tarefa.DataInc == DateTime.MinValue)
                return BadRequest(new { Erro = "A data da tarefa não pode ser vazia" });
            
            _context.Tarefas.Add(tarefa);
            _context.SaveChanges();

            return CreatedAtAction(nameof(ObterPorId), new { id = tarefa.IDTarefa }, tarefa);
        }

        [HttpPatch("{id}")]
        public IActionResult Atualizar(int id, Tarefa tarefa)
        {
            var objtarefa = _context.Tarefas.Find(id);

            if (objtarefa == null)
                return NotFound(new { Retorno = "Nenhum registro encontrado." });
            
            if (tarefa.Titulo != null)
                objtarefa.Titulo = tarefa.Titulo;
            if (tarefa.Descricao != null)
                objtarefa.Descricao = tarefa.Descricao;
            if (tarefa.DataInc != DateTime.MinValue)
                objtarefa.DataInc = tarefa.DataInc;
            if (tarefa.DataAlt != DateTime.MinValue)
                objtarefa.DataAlt = tarefa.DataAlt;
            if (tarefa.Status != null)
                objtarefa.Status = tarefa.Status;            

            _context.Tarefas.Update(objtarefa);
            _context.SaveChanges();

            return Ok(objtarefa);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var tarefaBanco = _context.Tarefas.Find(id);

            if (tarefaBanco == null)
                return NotFound(new {Retorno = "Nenhum registro encontrado."});

            _context.Tarefas.Remove(tarefaBanco);
            _context.SaveChanges();
            return Ok(new {Retorno = "Registro removido com sucesso."});
        }
    }
}
