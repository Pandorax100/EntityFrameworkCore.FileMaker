using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Query;

namespace Pandorax.EntityFrameworkCore.FileMaker.Query.Internal
{
    public class FileMakerQuerySqlGeneratorFactory : IQuerySqlGeneratorFactory
    {
        private readonly QuerySqlGeneratorDependencies _dependencies;

        public FileMakerQuerySqlGeneratorFactory(QuerySqlGeneratorDependencies dependencies)
        {
            _dependencies = dependencies;
        }

        public QuerySqlGenerator Create()
            => new FileMakerQuerySqlGenerator(_dependencies);
    }
}
