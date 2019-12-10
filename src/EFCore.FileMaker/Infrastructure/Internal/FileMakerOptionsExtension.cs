using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Pandorax.EntityFrameworkCore.FileMaker.Extensions;

namespace Pandorax.EntityFrameworkCore.FileMaker.Infrastructure.Internal
{
    public class FileMakerOptionsExtension : RelationalOptionsExtension
    {
        private ExtensionInfo? _info;

        public FileMakerOptionsExtension()
        {
        }

        public FileMakerOptionsExtension(FileMakerOptionsExtension copyFrom)
            : base(copyFrom)
        {
        }

        public override DbContextOptionsExtensionInfo Info => _info ??= new ExtensionInfo(this);

        public override void ApplyServices(IServiceCollection services)
        {
            services.AddEntityFrameworkFileMaker();
        }

        protected override RelationalOptionsExtension Clone()
        {
            return new FileMakerOptionsExtension(this);
        }

        private sealed class ExtensionInfo : RelationalExtensionInfo
        {
            public ExtensionInfo(IDbContextOptionsExtension extension)
                : base(extension)
            {
            }

            public override bool IsDatabaseProvider => true;

            public override void PopulateDebugInfo(IDictionary<string, string> debugInfo)
                => debugInfo["FileMaker"] = "1";
        }
    }
}
