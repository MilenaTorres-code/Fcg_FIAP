using Fcg.Domain.Entities;

namespace Fcg.Tests.Domain;

public class AquisicaoTests
{
    [Fact]
    public void Deve_Criar_Aquisicao_Com_Dados_Validos()
    {
        var aquisicao = new Aquisicao(
            1,
            2);

        Assert.Equal(1, aquisicao.UsuarioId);
        Assert.Equal(2, aquisicao.JogoId);
        Assert.NotEqual(default, aquisicao.DataAquisicao);
    }

    [Fact]
    public void Nao_Deve_Criar_Aquisicao_Com_Usuario_Invalido()
    {
        var excecao = Assert.Throws<ArgumentException>(() =>
            new Aquisicao(
                0,
                2));

        Assert.Equal(
            "Usuário inválido.",
            excecao.Message);
    }

    [Fact]
    public void Nao_Deve_Criar_Aquisicao_Com_Jogo_Invalido()
    {
        var excecao = Assert.Throws<ArgumentException>(() =>
            new Aquisicao(
                1,
                0));

        Assert.Equal(
            "Jogo inválido.",
            excecao.Message);
    }
}