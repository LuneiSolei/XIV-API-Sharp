using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Microsoft.Extensions.Options;
using XivApiSharp.Tests.Options.Schemas.ClauseTests;

namespace XivApiSharp.Tests.Options;

public class TopLevelOptions
{
    [Required, ValidateObjectMembers, UsedImplicitly]
    public required ClauseTestsSchema ClauseTests { get; set; }
}