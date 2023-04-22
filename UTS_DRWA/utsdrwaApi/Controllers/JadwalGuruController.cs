using UtsDrwaApi.Models;
using UtsDrwaApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace UtsDrwaApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JadwalGuruController : ControllerBase
{
    private readonly JadwalGuruService _jadwalService;

    public JadwalGuruController(JadwalGuruService jadwalService) =>
        _jadwalService = jadwalService;

    [HttpPost]
    public async Task<IActionResult> Post(JadwalGuru newJadwal)
    {
        await _jadwalService.CreateAsync(newJadwal);

        return CreatedAtAction(nameof(Get), new { id = newJadwal.nip }, newJadwal);
    }

    [HttpGet]
    public async Task<List<JadwalGuru>> Get() =>
        await _jadwalService.GetAsync();

    [HttpGet("{nip}")]
    public async Task<ActionResult<JadwalGuru>> Get(string nip)
    {
        var jadwal = await _jadwalService.GetAsync(nip);

        if (jadwal is null)
        {
            return NotFound();
        }

        return jadwal;
        
    }

     [HttpGet("{id_mapel}")]
    public async Task<ActionResult<JadwalGuru>> get(string idMapel)
    {
        var jadwal = await _jadwalService.GetAsync(idMapel);

        if (jadwal is null)
        {
            return NotFound();
        }

        return jadwal;
        
    }
}