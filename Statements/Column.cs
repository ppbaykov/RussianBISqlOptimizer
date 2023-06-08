using Ardalis.GuardClauses;
using RussianBISqlOptimizer.Utils;

namespace RussianBISqlOptimizer.Statements;

public sealed class Column : Statement
{
    private readonly string _column;

    public Column(string column, string? tableName = null)
    {
        Guard.Against.NullOrWhiteSpace(column, nameof(column));

        _column = column;
    }

    public override string ToSqlString()
    {
        return StringUtils.EscapeAndQuoteName(_column);
    }
}