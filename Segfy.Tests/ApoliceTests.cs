using Segfy.Domain.Entities;
using Segfy.Domain.Enums;

namespace Segfy.Tests;

public class ApoliceTests
{
    [Fact]
    public void Deve_Criar_Apolice_Com_Status_Ativa()
    {
        var apolice = new Apolice(
            "SEG-2026-0001",
            "52998224725",
            "ABC1234",
            199.90m,
            DateTime.Today,
            DateTime.Today.AddDays(30),
            StatusApolice.Ativa
        );

        Assert.Equal(StatusApolice.Ativa, apolice.Status);
    }

    [Fact]
    public void Deve_Atualizar_Status_Para_Cancelada()
    {
        var apolice = new Apolice(
            "SEG-2026-0001",
            "52998224725",
            "ABC1234",
            199.90m,
            DateTime.Today,
            DateTime.Today.AddDays(30),
            StatusApolice.Ativa
        );

        apolice.Atualizar(
            "52998224725",
            "ABC1234",
            199.90m,
            DateTime.Today,
            DateTime.Today.AddDays(30),
            StatusApolice.Cancelada
        );

        Assert.Equal(StatusApolice.Cancelada, apolice.Status);
    }

    [Fact]
    public void Deve_Manter_Numero_Apolice()
    {
        var apolice = new Apolice(
            "SEG-2026-0001",
            "52998224725",
            "ABC1234",
            199.90m,
            DateTime.Today,
            DateTime.Today.AddDays(30),
            StatusApolice.Ativa
        );

        Assert.Equal("SEG-2026-0001", apolice.NumeroApolice);
    }
}