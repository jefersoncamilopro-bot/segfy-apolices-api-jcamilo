using Segfy.Domain.Enums;

namespace Segfy.Application.DTOs;

public class ApoliceDto
{
    public Guid Id { get; set; }

    public string NumeroApolice { get; set; } = string.Empty;

    public string CpfCnpj { get; set; } = string.Empty;

    public string Placa { get; set; } = string.Empty;

    public decimal ValorPremio { get; set; }

    public DateTime DataInicio { get; set; }

    public DateTime DataFim { get; set; }

    public StatusApolice Status { get; set; }
}