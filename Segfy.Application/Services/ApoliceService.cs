using Segfy.Application.DTOs;
using Segfy.Application.Interfaces;
using Segfy.Domain.Entities;

namespace Segfy.Application.Services;

public class ApoliceService : IApoliceService
{
    private readonly IApoliceRepository _repository;

    public ApoliceService(IApoliceRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Apolice>> ObterTodasAsync()
    {
        return await _repository.ObterTodasAsync();
    }

    public async Task<Apolice?> ObterPorIdAsync(Guid id)
    {
        return await _repository.ObterPorIdAsync(id);
    }

    public async Task<Apolice> CriarAsync(CreateApoliceDto dto)
    {
        var ano = DateTime.Now.Year;

        var proximoSequencial = await _repository.ObterProximoSequencialAsync(ano);

        var numeroApolice = $"SEG-{ano}-{proximoSequencial:D4}";

        var apolice = new Apolice(
            numeroApolice,
            dto.CpfCnpj,
            dto.Placa,
            dto.ValorPremio,
            dto.DataInicio,
            dto.DataFim,
            dto.Status
        );

        await _repository.CriarAsync(apolice);

        return apolice;
    }

    public async Task AtualizarAsync(Guid id, UpdateApoliceDto dto)
    {
        var apolice = await _repository.ObterPorIdAsync(id);

        if (apolice is null)
            throw new Exception("Apólice não encontrada.");

        apolice.Atualizar(
            dto.CpfCnpj,
            dto.Placa,
            dto.ValorPremio,
            dto.DataInicio,
            dto.DataFim,
            dto.Status
        );

        await _repository.AtualizarAsync(apolice);
    }

    public async Task RemoverAsync(Guid id)
    {
        await _repository.RemoverAsync(id);
    }

    public async Task<List<Apolice>> ObterVencendoNosProximos30DiasAsync()
    {
        return await _repository.ObterVencendoNosProximos30DiasAsync();
    }
}