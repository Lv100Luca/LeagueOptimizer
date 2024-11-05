using Vogen;

namespace LeagueOptimizer.Models.Champions;

[ValueObject<int>]
[Instance(name: "Default", value: 1)]
public readonly partial struct Level
{
    private const int MinValue = 1;
    private const int MaxValue = 18;

    private static Validation Validate(int value) =>
        value is >= MinValue and <= MaxValue
            ? Validation.Ok
            : Validation.Invalid("Value must be between 1 and 18");
}