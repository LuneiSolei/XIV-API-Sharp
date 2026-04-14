using System.ComponentModel.DataAnnotations;
using XivApiSharp.Tests.Options.ClauseConfigs.ClauseTestTypes;

namespace XivApiSharp.Tests.Options.ClauseConfigs;

public class NumberConfig
{
    [Required(AllowEmptyStrings = false)]
    public IntClauseTestType IntTest { get; set; } = null!;
    
    [Required(AllowEmptyStrings = false)]
    public DoubleClauseTestType DoubleTest { get; set; } = null!;
    
    [Required(AllowEmptyStrings = false)]
    public DecimalClauseTestType DecimalTest { get; set; } = null!;
}