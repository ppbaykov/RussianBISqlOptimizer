using RussianBISqlOptimizer;
using RussianBISqlOptimizer.Statements;

Console.WriteLine("Welcome to Russian BI world");

var statement = new SelectQuery()
    .Select(new Alias(new Column("Col1"), "Attribute1"))
    .Select(new Alias(new Column("Col2"), "Attribute2"))
    .Select(new Alias(new FunctionCall("SUM", new Column("Col3")),"Attribute3"))
    .From(
        new SelectQuery()
            .Select(new[]
            {
                new Alias(new Column("Column1"), "Col1"),
                new Alias(new Column("Column2"), "Col2"),
                new Alias(new Column("Column3"), "Col3")
            })
            .From(new Table("Table"))
            .Where(new BinaryOperation(new Column("Column1"), new Value(1000), "="))
            .GroupBy(new[]
            {
                new Column("Column1"),
                new Column("Column2"),
                new Column("Column3")
            })
    )
    .GroupBy(new[]
    {
        new Column("Col1"),
        new Column("Col2")
    });

Console.WriteLine(statement.ToString());
Console.WriteLine();

// TODO Implement
var newStatement = SqlOptimizer.Optimize(statement);
Console.WriteLine(newStatement);

Console.ReadLine();