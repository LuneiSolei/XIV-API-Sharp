using System.ComponentModel.DataAnnotations;

namespace XivApiSharp.Tests.Options;

public class TestConfig
{
    [Required] 
    public ClauseConfig Clauses { get; set; } = null!;
}