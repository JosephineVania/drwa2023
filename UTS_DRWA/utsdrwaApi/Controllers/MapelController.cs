using UtsDrwaApi.Models;
using UtsDrwaApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace UtsDrwaApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MapelController : ControllerBase
{
    private readonly MapelService _mapel;

    public MapelController(MapelService mapelService) =>
        _mapel = mapelService;

    [HttpPost]
    public async Task<IActionResult> Post(Guru newMapel)
    {
        await _mapel.CreateAsync(newMapel);

        return CreatedAtAction(nameof(Get), new { id = newMapel.Mapel }, newMapel);
    }

    [HttpGet]
    public async Task<List<Guru>> Get() =>
        await _mapel.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Guru>> Get(string nip)
    {
        var mapel = await _mapel.GetAsync(nip);

        if (mapel is null)
        {
            return NotFound();
        }

        return mapel;
    }
}