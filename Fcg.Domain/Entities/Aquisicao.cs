namespace Fcg.Domain.Entities;

public class Aquisicao
{
    public int Id { get; private set; }

    public int UsuarioId { get; private set; }

    public int JogoId { get; private set; }

    public DateTime DataAquisicao { get; private set; }

    public Jogo Jogo { get; private set; } = null!;

    protected Aquisicao()
    {
    }

    public Aquisicao(int usuarioId, int jogoId)
    {
        if (usuarioId <= 0)
            throw new ArgumentException("Usuário inválido.");

        if (jogoId <= 0)
            throw new ArgumentException("Jogo inválido.");

        UsuarioId = usuarioId;
        JogoId = jogoId;
        DataAquisicao = DateTime.UtcNow;
    }
}