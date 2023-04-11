using UtsDrwaApi.Models;
using UtsDrwaApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace UtsDrwaApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UtsDrwaController : ControllerBase
{
    private readonly UtsDrwaService _utsDrwaService;

    public UtsDrwaController(UtsDrwaService utsDrwaService) =>
        _utsDrwaService = utsDrwaService;

    [HttpGet]
    public async Task<List<Guru>> Get() =>
        await _utsDrwaService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Guru>> Get(string id)
    {
        var utsDrwa = await _utsDrwaService.GetAsync(id);

        if (utsDrwa is null)
        {
            return NotFound();
        }

        return utsDrwa;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Guru newGuru)
    {
        await _utsDrwaService.CreateAsync(newGuru);

        return CreatedAtAction(nameof(Get), new { id = newGuru.Id }, newGuru);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Guru updatedGuru)
    {
        var utsDrwa = await _utsDrwaService.GetAsync(id);

        if (utsDrwa is null)
        {
            return NotFound();
        }

        updatedGuru.Id = utsDrwa.Id;

        await _utsDrwaService.UpdateAsync(id, updatedGuru);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var utsDrwa = await _utsDrwaService.GetAsync(id);

        if (utsDrwa is null)
        {
            return NotFound();
        }

        await _utsDrwaService.RemoveAsync(id);

        return NoContent();
    }
}