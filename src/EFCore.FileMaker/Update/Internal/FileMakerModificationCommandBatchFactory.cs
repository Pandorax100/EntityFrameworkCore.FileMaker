using Microsoft.EntityFrameworkCore.Update;

namespace Pandorax.EntityFrameworkCore.FileMaker
{
    public class FileMakerModificationCommandBatchFactory : IModificationCommandBatchFactory
    {
        private readonly ModificationCommandBatchFactoryDependencies _dependencies;

        public FileMakerModificationCommandBatchFactory(
            ModificationCommandBatchFactoryDependencies dependencies)
        {
            _dependencies = dependencies ?? throw new System.ArgumentNullException(nameof(dependencies));
        }

        public ModificationCommandBatch Create()
        {
            return new SingularModificationCommandBatch(_dependencies);
        }
    }
}