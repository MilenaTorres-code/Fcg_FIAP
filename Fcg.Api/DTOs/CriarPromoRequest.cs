namespace Fcg.Api.DTOs.Promocoes;

public class CriarPromoRequest
{
    public string Nome { get; set; } = string.Empty;

    public decimal PercentualDesconto { get; set; }

    public DateTime DataInicio { get; set; }

    public DateTime DataFim { get; set; }
}