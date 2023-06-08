using Ardalis.GuardClauses;

namespace RussianBISqlOptimizer.Statements;

public sealed class FunctionCall : Statement
{
    private readonly string _function;
    private readonly IReadOnlyList<Statement> _arguments;

    public FunctionCall(string function, IReadOnlyList<Statement> arguments)
    {
        Guard.Against.NullOrWhiteSpace(function, nameof(function));
        Guard.Against.Null(arguments, nameof(arguments));

        _function = function;
        _arguments = arguments;
    }

    public FunctionCall(string function, Statement argument) :
        this(function, new List<Statement> { argument })
    {
    }

    public override string ToSqlString()
    {
        var argumentsList = string.Join(", ", _arguments.Select(arg => arg.ToSqlString()));

        return $"{_function}({argumentsList})";
    }
}