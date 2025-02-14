using Azure_test_Battlegame.Data;
using Azure_test_Battlegame.Models;
using Microsoft.AspNetCore.Mvc;

namespace Azure_test_Battlegame.Controllers;
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private readonly BattleGameContext _context;

        public AssetController(BattleGameContext context)
        {
            _context = context;
        }

        [HttpPost("createasset")]
        public async Task<IActionResult> CreateAsset([FromBody] Asset asset)
        {
            if (asset == null)
            {
                return BadRequest("Asset is null.");
            }

            asset.AssetId = Guid.NewGuid();
            _context.Assets.Add(asset);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAssetById), new { id = asset.AssetId }, asset);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAssetById(Guid id)
        {
            var asset = await _context.Assets.FindAsync(id);
            if (asset == null)
            {
                return NotFound();
            }
            return Ok(asset);
        }
    }