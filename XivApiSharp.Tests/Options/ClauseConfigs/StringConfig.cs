using System.ComponentModel.DataAnnotations;
using XivApiSharp.Tests.Options.ClauseConfigs.ClauseTestTypes;

namespace XivApiSharp.Tests.Options.ClauseConfigs;

public class StringConfig
{
    [Required(AllowEmptyStrings = false)]
    public StringClauseTestType StringTest { get; set; } = null!;
}