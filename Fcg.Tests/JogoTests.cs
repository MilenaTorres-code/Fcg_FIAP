using Fcg.Domain.Entities;

namespace Fcg.Tests.Domain;

public class JogoTests
{
    [Fact]
    public void Deve_Criar_Jogo_Com_Dados_Validos()
    {
        var jogo = new Jogo(
            "Barbie",
            "Jogo de aventura da Barbie.",
            99.90m);

        Assert.Equal("Barbie", jogo.Titulo);
        Assert.Equal("Jogo de aventura da Barbie.", jogo.Descricao);
        Assert.Equal(99.90m, jogo.Preco);
        Assert.True(jogo.Ativo);
        Assert.NotEqual(default, jogo.DataCadastro);
    }

    [Fact]
    public void Nao_Deve_Criar_Jogo_Sem_Titulo()
    {
        var excecao = Assert.Throws<ArgumentException>(() =>
            new Jogo(
                "",
                "Jogo de teste.",
                50m));

        Assert.Equal(
            "Título do jogo é obrigatório.",
            excecao.Message);
    }

    [Fact]
    public void Nao_Deve_Criar_Jogo_Sem_Descricao()
    {
        var excecao = Assert.Throws<ArgumentException>(() =>
            new Jogo(
                "Barbie",
                "",
                50m));

        Assert.Equal(
            "Descrição do jogo é obrigatória.",
            excecao.Message);
    }

    [Fact]
    public void Nao_Deve_Criar_Jogo_Com_Preco_Negativo()
    {
        var excecao = Assert.Throws<ArgumentException>(() =>
            new Jogo(
                "Barbie",
                "Jogo de teste.",
                -10m));

        Assert.Equal(
            "O preço do jogo não pode ser negativo.",
            excecao.Message);
    }
}