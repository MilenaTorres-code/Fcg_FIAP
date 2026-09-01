using Fcg.Domain.Enums;
using Fcg.Domain.ValueObjects;

namespace Fcg.Domain.Entities;

public class Usuario
{
    public int Id { get; private set; }

    public string Nome { get; private set; } = string.Empty;

    public string Email { get; private set; } = string.Empty;

    public PerfilUsuario Perfil { get; private set; }

    public ICollection<Aquisicao> Aquisicoes { get; private set; }
        = new List<Aquisicao>();

    protected Usuario()
    {
    }

    public Usuario(
        string nome,
        string email,
        PerfilUsuario perfil = PerfilUsuario.Usuario)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Nome não pode ser vazio.");

        var emailValidado = new Email(email);

        Nome = nome;
        Email = emailValidado.Endereco;
        Perfil = perfil;
    }
}