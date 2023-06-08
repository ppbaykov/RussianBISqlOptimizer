namespace RussianBISqlOptimizer.Statements;

public class BinaryOperation : Statement
{
    private readonly Statement _leftOperand;
    private readonly Statement _rightOperand;
    private readonly string _operator;

    public BinaryOperation(Statement leftOperand, Statement rightOperand, string operation)
    {
       
        _leftOperand = leftOperand;
        _rightOperand = rightOperand;
        _operator = operation;
    }

    public override string ToSqlString()
    {
        return $"{_leftOperand.ToSqlString()} {_operator} {_rightOperand.ToSqlString()}";
    }
}