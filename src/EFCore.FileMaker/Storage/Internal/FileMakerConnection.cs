using System.Data.Common;
using System.Data.Odbc;
using Microsoft.EntityFrameworkCore.Storage;

namespace Pandorax.EntityFrameworkCore.FileMaker.Storage.Internal
{
    public class FileMakerConnection : RelationalConnection, IRelationalConnection
    {
        public FileMakerConnection(RelationalConnectionDependencies dependencies)
            : base(dependencies)
        {
        }

        protected override DbConnection CreateDbConnection()
        {
            return new OdbcConnection(ConnectionString);
        }
    }
}
