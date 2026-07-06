using Segfy.Application.DTOs;
using Segfy.Domain.Entities;

namespace Segfy.Application.Interfaces;

public interface IApoliceService
{
    Task<List<Apolice>> ObterTodasAsync();

    Task<Apolice?> ObterPorIdAsync(Guid id);

    Task<Apolice> CriarAsync(CreateApoliceDto dto);

    Task AtualizarAsync(Guid id, UpdateApoliceDto dto);

    Task RemoverAsync(Guid id);

    Task<List<Apolice>> ObterVencendoNosProximos30DiasAsync();
}