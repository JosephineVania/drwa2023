using UasDrwaApi.Models;
using UasDrwaApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UasDrwaApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GuruController : ControllerBase
{
    private readonly GuruService _guruService;

    public GuruController(GuruService guruService) =>
        _guruService = guruService;

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Post(Guru newGuru)
    {
        await _guruService.CreateAsync(newGuru);

        return CreatedAtAction(nameof(Get), new { id = newGuru.NIP }, newGuru);
    }

    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<List<Guru>> Get() =>
        await _guruService.GetAsync();

    [HttpGet("{nip)}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Guru>> Get(string nip)
    {
        var guru = await _guruService.GetAsync(nip);

        if (guru is null)
        {
            return NotFound();
        }

        return guru;
    }

    [HttpPut("{nip)}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Update(string nip, Guru updatedGuru)
    {
        var guru = await _guruService.GetAsync(nip);

        if (guru is null)
        {
            return NotFound();
        }

        updatedGuru.id = guru.NIP;

        await _guruService.UpdateAsync(nip, updatedGuru);

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
        var guru = await _guruService.GetAsync(nip);

        if (guru is null)
        {
            return NotFound();
        }

        await _guruService.RemoveAsync(nip);

        return NoContent();
    }
}