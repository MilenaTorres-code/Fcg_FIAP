using Fcg.Api.DTOs.Jogos;
using Fcg.Domain.Entities;
using Fcg.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fcg.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class JogosController : ControllerBase
{
    private readonly FcgDbContext _context;

    public JogosController(FcgDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetJogos()
    {
        var jogos = await _context.Jogos
            .Where(jogo => jogo.Ativo)
            .Select(jogo => new
            {
                jogo.Id,
                jogo.Titulo,
                jogo.Descricao,
                jogo.Preco,
                jogo.DataCadastro
            })
            .ToListAsync();

        return Ok(jogos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetJogo(int id)
    {
        var jogo = await _context.Jogos
            .Where(jogo => jogo.Id == id && jogo.Ativo)
            .Select(jogo => new
            {
                jogo.Id,
                jogo.Titulo,
                jogo.Descricao,
                jogo.Preco,
                jogo.DataCadastro
            })
            .FirstOrDefaultAsync();

        if (jogo is null)
        {
            return NotFound(new
            {
                Mensagem = "Jogo não encontrado."
            });
        }

        return Ok(jogo);
    }

    [HttpPost]
    [Authorize(Roles = "Administrador")]
    public async Task<IActionResult> CriarJogo(
        CriarJogoRequest request)
    {
        try
        {
            var jogo = new Jogo(
                request.Titulo,
                request.Descricao,
                request.Preco);

            _context.Jogos.Add(jogo);

            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetJogo),
                new { id = jogo.Id },
                new
                {
                    jogo.Id,
                    jogo.Titulo,
                    jogo.Descricao,
                    jogo.Preco,
                    jogo.Ativo,
                    jogo.DataCadastro
                });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new
            {
                Mensagem = ex.Message
            });
        }
    }
}