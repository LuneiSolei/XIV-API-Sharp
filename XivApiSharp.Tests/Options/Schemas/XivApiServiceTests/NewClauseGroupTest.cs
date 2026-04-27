using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Microsoft.Extensions.Options;

namespace XivApiSharp.Tests.Options.Schemas.XivApiServiceTests;

[UsedImplicitly]
public class NewClauseGroupTest
{
    [Required(AllowEmptyStrings = false), UsedImplicitly]
    public required string Decorator { get; set; }

    [Required, ValidateObjectMembers, UsedImplicitly]
    public required List<NewClauseTest> Clauses { get; set; }

    [Required(AllowEmptyStrings = false), UsedImplicitly]
    public required string ExpectedValue { get; set; }
}