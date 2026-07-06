using Microsoft.AspNetCore.Mvc;
using Segfy.Application.DTOs;
using Segfy.Application.Interfaces;

namespace Segfy.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ApolicesController : ControllerBase
{
    private readonly IApoliceService _service;

    public ApolicesController(IApoliceService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> ObterTodas()
    {
        var apolices = await _service.ObterTodasAsync();

        return Ok(apolices);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> ObterPorId(Guid id)
    {
        var apolice = await _service.ObterPorIdAsync(id);

        if (apolice is null)
            return NotFound();

        return Ok(apolice);
    }

    [HttpPost]
    public async Task<IActionResult> Criar(CreateApoliceDto dto)
    {
        var apolice = await _service.CriarAsync(dto);

        return CreatedAtAction(
            nameof(ObterPorId),
            new { id = apolice.Id },
            apolice
        );
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Atualizar(
        Guid id,
        UpdateApoliceDto dto)
    {
        await _service.AtualizarAsync(id, dto);

        return NoContent();
    }
    [HttpDelete("{id:guid}")]
public async Task<IActionResult> Remover(Guid id)
{
    await _service.RemoverAsync(id);

    return NoContent();
}
[HttpGet("vencendo")]
public async Task<IActionResult> ObterVencendo()
{
    var apolices = await _service.ObterVencendoNosProximos30DiasAsync();

    return Ok(apolices);
}
}