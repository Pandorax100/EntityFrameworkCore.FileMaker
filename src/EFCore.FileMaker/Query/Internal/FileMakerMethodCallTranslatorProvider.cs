using Microsoft.EntityFrameworkCore.Query;

namespace Pandorax.EntityFrameworkCore.FileMaker
{
    public class FileMakerMethodCallTranslatorProvider : RelationalMethodCallTranslatorProvider
    {
        public FileMakerMethodCallTranslatorProvider(RelationalMethodCallTranslatorProviderDependencies dependencies)
            : base(dependencies)
        {
            var sqlExpressionFactory = dependencies.SqlExpressionFactory;

            AddTranslators(
                new IMethodCallTranslator[]
                {
                    new FileMakerStringMethodTranslator(sqlExpressionFactory),
                });
        }
    }
}