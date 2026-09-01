using Fcg.Domain.Entities;
using Fcg.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Fcg.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Usuario")]
public class AquisicoesController : ControllerBase
{
    private readonly FcgDbContext _context;

    public AquisicoesController(FcgDbContext context)
    {
        _context = context;
    }

    [HttpPost("{jogoId}")]
    public async Task<IActionResult> AdquirirJogo(int jogoId)
    {
        var usuarioIdClaim =
            User.FindFirst(ClaimTypes.NameIdentifier)?.Value
            ?? User.FindFirst("sub")?.Value;

        if (!int.TryParse(usuarioIdClaim, out var usuarioId))
        {
            return Unauthorized();
        }

        var jogo = await _context.Jogos
            .FirstOrDefaultAsync(jogo =>
                jogo.Id == jogoId &&
                jogo.Ativo);

        if (jogo is null)
        {
            return NotFound(new
            {
                Mensagem = "Jogo não encontrado."
            });
        }

        var jaAdquiriu = await _context.Aquisicoes
            .AnyAsync(aquisicao =>
                aquisicao.UsuarioId == usuarioId &&
                aquisicao.JogoId == jogoId);

        if (jaAdquiriu)
        {
            return BadRequest(new
            {
                Mensagem = "Este jogo já foi adquirido."
            });
        }

        var aquisicao = new Aquisicao(
            usuarioId,
            jogoId);

        _context.Aquisicoes.Add(aquisicao);

        await _context.SaveChangesAsync();

        return Ok(new
        {
            Mensagem = "Jogo adquirido com sucesso.",
            aquisicao.Id,
            aquisicao.JogoId,
            aquisicao.DataAquisicao
        });
    }

    [HttpGet("minhas")]
    public async Task<IActionResult> MinhasAquisicoes()
    {
        var usuarioIdClaim =
            User.FindFirst(ClaimTypes.NameIdentifier)?.Value
            ?? User.FindFirst("sub")?.Value;

        if (!int.TryParse(usuarioIdClaim, out var usuarioId))
        {
            return Unauthorized();
        }

        var aquisicoes = await _context.Aquisicoes
            .Where(aquisicao =>
                aquisicao.UsuarioId == usuarioId)
            .Include(aquisicao => aquisicao.Jogo)
            .Select(aquisicao => new
            {
                aquisicao.Id,
                Jogo = new
                {
                    aquisicao.Jogo.Id,
                    aquisicao.Jogo.Titulo,
                    aquisicao.Jogo.Descricao,
                    aquisicao.Jogo.Preco
                },
                aquisicao.DataAquisicao
            })
            .ToListAsync();

        return Ok(aquisicoes);
    }
}