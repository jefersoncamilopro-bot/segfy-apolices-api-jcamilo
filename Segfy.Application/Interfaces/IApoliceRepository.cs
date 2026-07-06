using Segfy.Domain.Entities;

namespace Segfy.Application.Interfaces;

public interface IApoliceRepository
{
    Task<List<Apolice>> ObterTodasAsync();

    Task<Apolice?> ObterPorIdAsync(Guid id);

    Task CriarAsync(Apolice apolice);

    Task AtualizarAsync(Apolice apolice);

    Task RemoverAsync(Guid id);

    Task<List<Apolice>> ObterVencendoNosProximos30DiasAsync();

    Task<int> ObterProximoSequencialAsync(int ano);
}