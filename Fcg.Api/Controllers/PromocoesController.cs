using Fcg.Api.DTOs.Promocoes;
using Fcg.Domain.Entities;
using Fcg.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fcg.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class PromocoesController : ControllerBase
{
    private readonly FcgDbContext _context;

    public PromocoesController(FcgDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetPromocoes()
    {
        var promocoes = await _context.Promocoes
            .Select(promocao => new
            {
                promocao.Id,
                promocao.Nome,
                promocao.PercentualDesconto,
                promocao.DataInicio,
                promocao.DataFim
            })
            .ToListAsync();

        return Ok(promocoes);
    }

    [HttpPost]
    [Authorize(Roles = "Administrador")]
    public async Task<IActionResult> CriarPromocao(
        CriarPromoRequest request)
    {
        try
        {
            var promocao = new Promocao(
                request.Nome,
                request.PercentualDesconto,
                request.DataInicio,
                request.DataFim);

            _context.Promocoes.Add(promocao);

            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetPromocoes),
                new { id = promocao.Id },
                new
                {
                    promocao.Id,
                    promocao.Nome,
                    promocao.PercentualDesconto,
                    promocao.DataInicio,
                    promocao.DataFim
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