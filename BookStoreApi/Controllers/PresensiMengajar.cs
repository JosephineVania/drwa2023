using UasDrwaApi.Models;
using UasDrwaApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UasDrwaApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PresensiMengajarController : ControllerBase
{
    private readonly PresensiMengajarService _presensimengajarService;

    public PresensiMengajarController(PresensiMengajarService presensimengajarService) =>
        _presensimengajarService = presensimengajarService;

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Post(PresensiMengajar newPresensiMengajar)
    {
        await _presensimengajarService.CreateAsync(newPresensiMengajar);

        return CreatedAtAction(nameof(Get), new { id = newPresensiMengajar.nip }, newPresensiMengajar);
    }

    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<List<PresensiMengajar>> Get() =>
        await _presensimengajarService.GetAsync();

    [HttpGet("{nip)}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<PresensiMengajar>> Get(string nip)
    {
        var presensimengajar = await _presensimengajarService.GetAsync(nip);

        if (presensimengajar is null)
        {
            return NotFound();
        }

        return presensimengajar;
    }

    [HttpPut("{nip)}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Update(string nip, PresensiMengajar updatedPresensiMengajar)
    {
        var presensimengajar = await _presensimengajarService.GetAsync(nip);

        if (presensimengajar is null)
        {
            return NotFound();
        }

        updatedPresensiMengajar.id = presensimengajar.nip;

        await _presensimengajarService.UpdateAsync(nip, updatedPresensiMengajar);

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
        var presensiharianguru = await _presensimengajarService.GetAsync(nip);

        if (presensiharianguru is null)
        {
            return NotFound();
        }

        await _presensimengajarService.RemoveAsync(nip);

        return NoContent();
    }
}