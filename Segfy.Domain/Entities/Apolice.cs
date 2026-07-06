using Segfy.Domain.Enums;

namespace Segfy.Domain.Entities;

public class Apolice
{
    public Guid Id { get; private set; }

    public string NumeroApolice { get; private set; }

    public string CpfCnpj { get; private set; }

    public string Placa { get; private set; }

    public decimal ValorPremio { get; private set; }

    public DateTime DataInicio { get; private set; }

    public DateTime DataFim { get; private set; }

    public StatusApolice Status { get; private set; }

    public Apolice(
        string numeroApolice,
        string cpfCnpj,
        string placa,
        decimal valorPremio,
        DateTime dataInicio,
        DateTime dataFim,
        StatusApolice status = StatusApolice.Ativa)
    {
        Id = Guid.NewGuid();

        NumeroApolice = numeroApolice;
        CpfCnpj = cpfCnpj;
        Placa = placa;
        ValorPremio = valorPremio;
        DataInicio = dataInicio;
        DataFim = dataFim;
        Status = status;
    }

    public void Atualizar(
        string cpfCnpj,
        string placa,
        decimal valorPremio,
        DateTime dataInicio,
        DateTime dataFim,
        StatusApolice status)
    {
        CpfCnpj = cpfCnpj;
        Placa = placa;
        ValorPremio = valorPremio;
        DataInicio = dataInicio;
        DataFim = dataFim;
        Status = status;
    }
}