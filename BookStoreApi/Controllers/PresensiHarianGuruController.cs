using UasDrwaApi.Models;
using UasDrwaApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UasDrwaApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PresensiHarianGuruController : ControllerBase
{
    private readonly PresensiHarianGuruService _presensiharianguruService;

    public PresensiHarianGuruController(PresensiHarianGuruService presensiharianguruService) =>
        _presensiharianguruService = presensiharianguruService;

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Post(PresensiHarianGuru newPresensiHarianGuru)
    {
        await _presensiharianguruService.CreateAsync(newPresensiHarianGuru);

        return CreatedAtAction(nameof(Get), new { id = newPresensiHarianGuru.nip }, newPresensiHarianGuru);
    }

    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<List<PresensiHarianGuru>> Get() =>
        await _presensiharianguruService.GetAsync();

    [HttpGet("{nip)}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<PresensiHarianGuru>> Get(string nip)
    {
        var presensiharianguru = await _presensiharianguruService.GetAsync(nip);

        if (presensiharianguru is null)
        {
            return NotFound();
        }

        return presensiharianguru;
    }

    [HttpPut("{nip)}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Update(string nip, PresensiHarianGuru updatedPresensiHarianGuru)
    {
        var presensiharianguru = await _presensiharianguruService.GetAsync(nip);

        if (presensiharianguru is null)
        {
            return NotFound();
        }

        updatedPresensiHarianGuru.id = presensiharianguru.nip;

        await _presensiharianguruService.UpdateAsync(nip, updatedPresensiHarianGuru);

        return NoContent();
    }

    [HttpDelete("{nip)}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(string nip)
    {
        var presensiharianguru = await _presensiharianguruService.GetAsync(nip);

        if (presensiharianguru is null)
        {
            return NotFound();
        }

        await _presensiharianguruService.RemoveAsync(nip);

        return NoContent();
    }
    
}