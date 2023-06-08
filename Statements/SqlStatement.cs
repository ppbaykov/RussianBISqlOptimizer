namespace RussianBISqlOptimizer.Statements;

public abstract class Statement
{
    /// <summary>
    /// Materialize SQL-tree into the string
    /// </summary>
    public abstract string ToSqlString();

// Необходимо для того, чтобы оперативно смотреть текст SQL-запроса в процессе отладки
#if DEBUG
    public override string ToString()
    {
        return ToSqlString();
    }
#endif
}