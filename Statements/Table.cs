using Ardalis.GuardClauses;
using RussianBISqlOptimizer.Utils;

namespace RussianBISqlOptimizer.Statements;

public sealed class Table : Statement
{
    private readonly string _tableName;

    public Table(string tableName)
    {
        Guard.Against.NullOrWhiteSpace(tableName, nameof(tableName));

        _tableName = tableName;
    }

    public override string ToSqlString()
    {
        return StringUtils.QuoteName(_tableName);
    }
}