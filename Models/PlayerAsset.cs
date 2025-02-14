using System.ComponentModel.DataAnnotations;

namespace Azure_test_Battlegame.Models;

public class PlayerAsset

{
    [Key]
    public Guid Id { get; set; }
    public Guid PlayerId { get; set; }
    public Guid AssetId { get; set; }
}
