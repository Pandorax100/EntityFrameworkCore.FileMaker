using System.Text;
using Microsoft.EntityFrameworkCore.Storage;

namespace Pandorax.EntityFrameworkCore.FileMaker
{
    public class FileMakerSqlGenerationHelper : RelationalSqlGenerationHelper
    {
        public FileMakerSqlGenerationHelper(RelationalSqlGenerationHelperDependencies dependencies)
            : base(dependencies)
        {
        }

        public override string GenerateParameterName(string name)
        {
            return "?";
        }
    }
}