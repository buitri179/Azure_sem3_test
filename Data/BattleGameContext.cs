using Azure_test_Battlegame.Models;
using Microsoft.EntityFrameworkCore;

namespace Azure_test_Battlegame.Data;

public class BattleGameContext : DbContext
{
    public BattleGameContext(DbContextOptions<BattleGameContext> options) : base(options) {}

    public DbSet<Player> Players { get; set; }
    public DbSet<Asset> Assets { get; set; }
    public DbSet<PlayerAsset> PlayerAssets { get; set; }
}