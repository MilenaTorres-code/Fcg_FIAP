using Fcg.Domain.Entities;

namespace Fcg.Tests.Domain;

public class PromocaoTests
{
    [Fact]
    public void Deve_Criar_Promocao_Com_Dados_Validos()
    {
        var inicio = DateTime.UtcNow;
        var fim = inicio.AddDays(7);

        var promocao = new Promocao(
            "Promoção de lançamento",
            20,
            inicio,
            fim);

        Assert.Equal(
            "Promoção de lançamento",
            promocao.Nome);

        Assert.Equal(
            20,
            promocao.PercentualDesconto);

        Assert.Equal(
            inicio,
            promocao.DataInicio);

        Assert.Equal(
            fim,
            promocao.DataFim);
    }

    [Fact]
    public void Nao_Deve_Criar_Promocao_Sem_Nome()
    {
        var inicio = DateTime.UtcNow;
        var fim = inicio.AddDays(7);

        var excecao = Assert.Throws<ArgumentException>(() =>
            new Promocao(
                "",
                20,
                inicio,
                fim));

        Assert.Equal(
            "Nome da promoção é obrigatório.",
            excecao.Message);
    }

    [Fact]
    public void Nao_Deve_Criar_Promocao_Com_Desconto_Zero()
    {
        var inicio = DateTime.UtcNow;
        var fim = inicio.AddDays(7);

        var excecao = Assert.Throws<ArgumentException>(() =>
            new Promocao(
                "Promoção",
                0,
                inicio,
                fim));

        Assert.Equal(
            "O desconto deve estar entre 0 e 70%.",
            excecao.Message);
    }

    [Fact]
    public void Nao_Deve_Criar_Promocao_Com_Desconto_Acima_De_70()
    {
        var inicio = DateTime.UtcNow;
        var fim = inicio.AddDays(7);

        var excecao = Assert.Throws<ArgumentException>(() =>
            new Promocao(
                "Promoção",
                71,
                inicio,
                fim));

        Assert.Equal(
            "O desconto deve estar entre 0 e 70%.",
            excecao.Message);
    }

    [Fact]
    public void Nao_Deve_Criar_Promocao_Com_Data_Final_Invalida()
    {
        var inicio = DateTime.UtcNow;
        var fim = inicio.AddDays(-1);

        var excecao = Assert.Throws<ArgumentException>(() =>
            new Promocao(
                "Promoção",
                20,
                inicio,
                fim));

        Assert.Equal(
            "A data final deve ser posterior à data inicial.",
            excecao.Message);
    }
}