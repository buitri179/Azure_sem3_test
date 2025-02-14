using Azure_test_Battlegame.Data;
using Azure_test_Battlegame.Models;
using Microsoft.AspNetCore.Mvc;

namespace Azure_test_Battlegame.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlayerController: ControllerBase
{
    private readonly BattleGameContext _context;

    public PlayerController(BattleGameContext context)
    {
        _context = context;
    }

    [HttpPost("registerplayer")]
    public async Task<IActionResult> RegisterPlayer([FromBody] Player player)
    {
        if (player == null)
        {
            return BadRequest("Player is null.");
        }

        player.PlayerId = Guid.NewGuid();
        _context.Players.Add(player);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPlayerById), new { id = player.PlayerId }, player);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPlayerById(Guid id)
    {
        var player = await _context.Players.FindAsync(id);
        if (player == null)
        {
            return NotFound();
        }
        return Ok(player);
    }
}