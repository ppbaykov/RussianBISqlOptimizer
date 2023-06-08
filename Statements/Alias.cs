using Ardalis.GuardClauses;

using RussianBISqlOptimizer.Utils;

namespace RussianBISqlOptimizer.Statements;

public sealed class Alias : Statement
{
    private readonly Statement _definition;
    private readonly string _alias;

    public Alias(Statement definition, string alias)
    {
        Guard.Against.Null(definition, nameof(definition));
        Guard.Against.NullOrWhiteSpace(alias, nameof(alias));

        _definition = definition;
        _alias = alias;
    }

    public override string ToSqlString()
    {
        var definitionStr = _definition.ToSqlString();
        return $"{definitionStr} AS {StringUtils.EscapeAndQuoteName(_alias)}";
    }
}