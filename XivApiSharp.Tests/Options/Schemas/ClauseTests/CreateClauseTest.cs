using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;

namespace XivApiSharp.Tests.Options.Schemas.ClauseTests;

public class CreateClauseTest : IBaseClauseOptions
{
    [Required(AllowEmptyStrings = false), UsedImplicitly]
    public string Decorator { get; set; }

    [Required(AllowEmptyStrings = false), UsedImplicitly]
    public string Specifier { get; set; }

    [Required(AllowEmptyStrings = false), UsedImplicitly]
    public string Language { get; set; }

    [Required(AllowEmptyStrings = false), UsedImplicitly]
    public string Operator { get; set; }

    [Required(AllowEmptyStrings = false), UsedImplicitly]
    public string Value { get; set; }

    [Required(AllowEmptyStrings = false), UsedImplicitly]
    public string ExpectedValue { get; set; }
}