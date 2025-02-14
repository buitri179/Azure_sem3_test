using System.ComponentModel.DataAnnotations;

namespace Azure_test_Battlegame.Models;

public class Asset
{
    [Key]
    public Guid AssetId { get; set; }
    public string AssetName { get; set; }
    public int LevelRequire { get; set; }
}