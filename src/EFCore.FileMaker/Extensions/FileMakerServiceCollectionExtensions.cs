using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Update;
using Microsoft.Extensions.DependencyInjection;
using Pandorax.EntityFrameworkCore.FileMaker.Diagnostics.Internal;
using Pandorax.EntityFrameworkCore.FileMaker.Infrastructure.Internal;
using Pandorax.EntityFrameworkCore.FileMaker.Metadata.Conventions;
using Pandorax.EntityFrameworkCore.FileMaker.Storage.Internal;

namespace Pandorax.EntityFrameworkCore.FileMaker.Extensions
{
    public static class FileMakerServiceCollectionExtensions
    {
        public static IServiceCollection AddEntityFrameworkFileMaker(this IServiceCollection services)
        {
            if (services is null)
            {
                throw new System.ArgumentNullException(nameof(services));
            }

            var builder = new EntityFrameworkRelationalServicesBuilder(services)
                .TryAdd<LoggingDefinitions, FileMakerLoggingDefinitions>()
                .TryAdd<IDatabaseProvider, DatabaseProvider<FileMakerOptionsExtension>>()
                .TryAdd<IRelationalTypeMappingSource, FileMakerTypeMappingSource>()
                .TryAdd<ISqlGenerationHelper, FileMakerSqlGenerationHelper>()
                .TryAdd<IModificationCommandBatchFactory, FileMakerModificationCommandBatchFactory>()
                .TryAdd<IUpdateSqlGenerator, FileMakerUpdateSqlGenerator>()
                .TryAdd<IProviderConventionSetBuilder, FileMakerConventionSetBuilder>()
                .TryAdd<IMethodCallTranslatorProvider, FileMakerMethodCallTranslatorProvider>()
                .TryAdd<IRelationalConnection, FileMakerConnection>();

            builder.TryAddCoreServices();

            return services;
        }
    }
}
