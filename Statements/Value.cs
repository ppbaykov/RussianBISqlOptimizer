namespace RussianBISqlOptimizer.Statements;

public class Value : Statement
{
    private readonly int _value;

    public Value(int value)
    {
        _value = value;
    }

    public override string ToSqlString()
    {
        return _value.ToString();
    }
}