using Microsoft.EntityFrameworkCore;
using Segfy.Application.Interfaces;
using Segfy.Domain.Entities;
using Segfy.Infrastructure.Data;

namespace Segfy.Infrastructure.Repositories;

public class ApoliceRepository : IApoliceRepository
{
    private readonly AppDbContext _context;

    public ApoliceRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Apolice>> ObterTodasAsync()
    {
        return await _context.Apolices.ToListAsync();
    }

    public async Task<Apolice?> ObterPorIdAsync(Guid id)
    {
        return await _context.Apolices.FindAsync(id);
    }

    public async Task CriarAsync(Apolice apolice)
    {
        await _context.Apolices.AddAsync(apolice);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarAsync(Apolice apolice)
    {
        _context.Apolices.Update(apolice);
        await _context.SaveChangesAsync();
    }

    public async Task RemoverAsync(Guid id)
    {
        var apolice = await ObterPorIdAsync(id);

        if (apolice is null)
            return;

        _context.Apolices.Remove(apolice);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Apolice>> ObterVencendoNosProximos30DiasAsync()
    {
        var hoje = DateTime.Today;
        var limite = hoje.AddDays(30);

        return await _context.Apolices
            .Where(a => a.DataFim >= hoje && a.DataFim <= limite)
            .ToListAsync();
    }

    public async Task<int> ObterProximoSequencialAsync(int ano)
    {
        var prefixo = $"SEG-{ano}-";

        var quantidade = await _context.Apolices
            .CountAsync(a => a.NumeroApolice.StartsWith(prefixo));

        return quantidade + 1;
    }
}