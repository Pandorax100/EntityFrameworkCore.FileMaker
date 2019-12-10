using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;

namespace Pandorax.EntityFrameworkCore.FileMaker.Metadata.Conventions
{
    public class FileMakerConventionSetBuilder : RelationalConventionSetBuilder
    {
        public FileMakerConventionSetBuilder(
            ProviderConventionSetBuilderDependencies dependencies,
            RelationalConventionSetBuilderDependencies relationalDependencies)
            : base(dependencies, relationalDependencies)
        {
        }
    }
}