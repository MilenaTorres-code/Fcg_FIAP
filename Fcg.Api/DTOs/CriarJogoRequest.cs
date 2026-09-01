namespace Fcg.Api.DTOs.Jogos;

public class CriarJogoRequest
{
    public string Titulo { get; set; } = string.Empty;

    public string Descricao { get; set; } = string.Empty;

    public decimal Preco { get; set; }
}