using Fcg.Domain.Entities;

namespace Fcg.Domain.Entities;

public class Jogo
{
    public int Id { get; private set; }

    public string Titulo { get; private set; } = string.Empty;

    public string Descricao { get; private set; } = string.Empty;

    public decimal Preco { get; private set; }

    public bool Ativo { get; private set; }

    public DateTime DataCadastro { get; private set; }

    public ICollection<Aquisicao> Aquisicoes { get; private set; }
        = new List<Aquisicao>();

    protected Jogo()
    {
    }

    public Jogo(
        string titulo,
        string descricao,
        decimal preco)
    {
        ValidarDados(titulo, descricao, preco);

        Titulo = titulo;
        Descricao = descricao;
        Preco = preco;
        Ativo = true;
        DataCadastro = DateTime.UtcNow;
    }

    private static void ValidarDados(
        string titulo,
        string descricao,
        decimal preco)
    {
        if (string.IsNullOrWhiteSpace(titulo))
            throw new ArgumentException("Título do jogo é obrigatório.");

        if (string.IsNullOrWhiteSpace(descricao))
            throw new ArgumentException("Descrição do jogo é obrigatória.");

        if (preco < 0)
            throw new ArgumentException("O preço do jogo não pode ser negativo.");
    }
}