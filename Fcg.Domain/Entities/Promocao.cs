namespace Fcg.Domain.Entities;

public class Promocao
{
    public int Id { get; private set; }

    public string Nome { get; private set; } = string.Empty;

    public decimal PercentualDesconto { get; private set; }

    public DateTime DataInicio { get; private set; }

    public DateTime DataFim { get; private set; }

    protected Promocao()
    {
    }

    public Promocao(
        string nome,
        decimal percentualDesconto,
        DateTime dataInicio,
        DateTime dataFim)
    {
        ValidarDados(
            nome,
            percentualDesconto,
            dataInicio,
            dataFim);

        Nome = nome;
        PercentualDesconto = percentualDesconto;
        DataInicio = dataInicio;
        DataFim = dataFim;
    }

    private static void ValidarDados(
        string nome,
        decimal percentualDesconto,
        DateTime dataInicio,
        DateTime dataFim)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException(
                "Nome da promoção é obrigatório.");

        if (percentualDesconto <= 0 || percentualDesconto > 70)
            throw new ArgumentException(
                "O desconto deve estar entre 0 e 70%.");

        if (dataFim <= dataInicio)
            throw new ArgumentException(
                "A data final deve ser posterior à data inicial.");
    }
}