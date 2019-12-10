using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Pandorax.EntityFrameworkCore.FileMaker.Infrastructure.Internal;

namespace Pandorax.EntityFrameworkCore.FileMaker.Extensions
{
    public static class FileMakerDbContextOptionsBuilderExtensions
    {
        public static DbContextOptionsBuilder UseFileMaker(
            this DbContextOptionsBuilder optionsBuilder,
            string connectionString)
        {
            var extension = (optionsBuilder.Options.FindExtension<FileMakerOptionsExtension>() ?? new FileMakerOptionsExtension())
                .WithConnectionString(connectionString);

            ((IDbContextOptionsBuilderInfrastructure)optionsBuilder).AddOrUpdateExtension(extension);

            ConfigureWarnings(optionsBuilder);

            return optionsBuilder;
        }

        private static void ConfigureWarnings(DbContextOptionsBuilder optionsBuilder)
        {
            var coreOptionsExtension
                = optionsBuilder.Options.FindExtension<CoreOptionsExtension>()
                ?? new CoreOptionsExtension();

            coreOptionsExtension = coreOptionsExtension.WithWarningsConfiguration(
                coreOptionsExtension.WarningsConfiguration.TryWithExplicit(
                    RelationalEventId.AmbientTransactionWarning, WarningBehavior.Throw));

            ((IDbContextOptionsBuilderInfrastructure)optionsBuilder).AddOrUpdateExtension(coreOptionsExtension);
        }
    }
}
