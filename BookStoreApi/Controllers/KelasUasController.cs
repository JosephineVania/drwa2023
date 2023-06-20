using System.Net;
using UasDrwaApi.Models;
using UasDrwaApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UasDrwaApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class KelasUasController : ControllerBase
{
    private readonly KelasUasService _kelasUasService;

    public KelasUasController(KelasUasService kelasUasService) =>
        _kelasUasService = kelasUasService;

    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<List<KelasUas>> Get() =>
        await _kelasUasService.GetAsync();

    [HttpGet("{id:length(24)}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<KelasUas>> Get(string id)
    {
        var kelas = await _kelasUasService.GetAsync(id);

        if (kelas is null)
        {
            return NotFound();
        }

        return kelas;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Post(KelasUas newKelas)
    {
        await _kelasUasService.CreateAsync(newKelas);

        return CreatedAtAction(nameof(Get), new { id = newKelas.id }, newKelas);
    }

    [HttpPut("{id:length(24)}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Update(string id, KelasUas updatedKelas)
    {
        var kelas = await _kelasUasService.GetAsync(id);

        if (kelas is null)
        {
            return NotFound();
        }

        updatedKelas.id = kelas.id;

        await _kelasUasService.UpdateAsync(id, updatedKelas);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(string id)
    {
        var kelas = await _kelasUasService.GetAsync(id);

        if (kelas is null)
        {
            return NotFound();
        }

        await _kelasUasService.RemoveAsync(id);

        return NoContent();
    }
    
}