using UtsDrwaApi.Models;
using UtsDrwaApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace UtsDrwaApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GuruController : ControllerBase
{
    private readonly GuruService _guruService;

    public GuruController(GuruService guruService) =>
        _guruService = guruService;

    [HttpPost]
    public async Task<IActionResult> Post(Guru newGuru)
    {
        await _guruService.CreateAsync(newGuru);

        return CreatedAtAction(nameof(Get), new { id = newGuru.nip }, newGuru);
    }

    [HttpGet]
    public async Task<List<Guru>> Get() =>
        await _guruService.GetAsync();

    [HttpGet("{nip)}")]
    public async Task<ActionResult<Guru>> Get(string nip)
    {
        var guru = await _guruService.GetAsync(nip);

        if (guru is null)
        {
            return NotFound();
        }

        return guru;
    }
}