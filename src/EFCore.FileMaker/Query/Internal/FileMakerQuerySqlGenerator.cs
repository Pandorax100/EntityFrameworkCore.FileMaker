using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Pandorax.EntityFrameworkCore.FileMaker.Query.Internal
{
    internal class FileMakerQuerySqlGenerator : QuerySqlGenerator
    {
        public FileMakerQuerySqlGenerator(QuerySqlGeneratorDependencies dependencies)
            : base(dependencies)
        {
        }

        protected override void GenerateLimitOffset(SelectExpression selectExpression)
        {
            if (selectExpression.Offset != null)
            {
                Sql.AppendLine()
                    .Append("OFFSET ");

                Visit(selectExpression.Offset);

                Sql.Append(" ROWS");

                if (selectExpression.Limit != null)
                {
                    Sql.Append(" FETCH NEXT ");

                    Visit(selectExpression.Limit);

                    Sql.Append(" ROWS ONLY");
                }
            }
            else if (selectExpression.Limit != null)
            {
                Sql.AppendLine()
                    .Append("FETCH FIRST ");

                Visit(selectExpression.Limit);

                Sql.Append(" ROWS ONLY");
            }
        }
    }
}