using System.Text;
using Microsoft.EntityFrameworkCore.Update;

namespace Pandorax.EntityFrameworkCore.FileMaker
{
    public class FileMakerUpdateSqlGenerator : UpdateSqlGenerator
    {
        public FileMakerUpdateSqlGenerator(UpdateSqlGeneratorDependencies dependencies)
            : base(dependencies)
        {
        }

        protected override void AppendIdentityWhereCondition(StringBuilder commandStringBuilder, ColumnModification columnModification)
        {
        }

        protected override void AppendRowsAffectedWhereCondition(StringBuilder commandStringBuilder, int expectedRowsAffected)
        {
        }
    }
}