using System.Text;

namespace RussianBISqlOptimizer.Statements;

public class SelectQuery : Statement
{
    private const string SelectKeyword = "SELECT";
    private const string FromKeyword = "FROM";
    private const string WhereKeyword = "WHERE";
    private const string GroupByKeyword = "GROUP BY";
    
    private readonly List<Statement> _selectStatements = new();
    private readonly List<Statement> _fromStatements = new();
    private readonly List<Statement> _groupByStatements = new();
    
    private Statement? _whereCondition;

    #region SELECT

    public SelectQuery Select(Statement selectStatement)
    {
        _selectStatements.Add(selectStatement);
        return this;
    }

    public SelectQuery Select(IEnumerable<Statement> selectStatements)
    {
        _selectStatements.AddRange(selectStatements);
        return this;
    }

    #endregion

    #region FROM

    public SelectQuery From(Statement fromStatement)
    {
        _fromStatements.Add(fromStatement);
        return this;
    }

    #endregion

    #region WHERE

    public SelectQuery Where(Statement whereStatement, string operation = "AND")
    {
        if (_whereCondition == null)
        {
            _whereCondition = whereStatement;
        }
        else
        {
            _whereCondition = new BinaryOperation(
                _whereCondition,
                whereStatement,
                operation);
        }

        return this;
    }

    #endregion

    #region GROUP BY

    public SelectQuery GroupBy(IEnumerable<Statement> groupByStatements)
    {
        _groupByStatements.AddRange(groupByStatements);
        return this;
    }

    #endregion

    public override string ToSqlString()
    {
        var selectClause = _selectStatements.Any()
            ? string.Join(", ", _selectStatements.Select(x => x.ToSqlString()))
            : "*";
        var queryBuilder = new StringBuilder($"{SelectKeyword} ");
        
        queryBuilder.Append(selectClause);
        queryBuilder.Append(BuildFromClause());
        if (_whereCondition != null)
            queryBuilder.Append($"\n{WhereKeyword} {_whereCondition.ToSqlString()}");

        if (_groupByStatements.Any())
        {
            var groupByClause = string.Join(", ", _groupByStatements.Select(x => x.ToSqlString()));
            queryBuilder.Append($"\n{GroupByKeyword} {groupByClause}");
        }

        return queryBuilder.ToString();
    }

    private string BuildFromClause()
    {
        var fromClause = string.Empty;

        if (_fromStatements.Any())
        {
            var statements = new List<string>();
            foreach (var fromStatement in _fromStatements)
            {
                statements.Add($"({fromStatement.ToSqlString()})");
            }

            fromClause = $"\n{FromKeyword} {string.Join(", ", statements)}";
        }

        return fromClause;
    }
}