using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Storage;

namespace Pandorax.EntityFrameworkCore.FileMaker.Storage.Internal
{
    public class FileMakerTypeMappingSource : RelationalTypeMappingSource
    {
        public FileMakerTypeMappingSource(
            TypeMappingSourceDependencies dependencies,
            RelationalTypeMappingSourceDependencies relationalDependencies)
            : base(dependencies, relationalDependencies)
        {
        }

        private readonly Dictionary<Type, RelationalTypeMapping> _clrTypeMappings
            = new Dictionary<Type, RelationalTypeMapping>
            {
                [typeof(string)] = new StringTypeMapping("varchar"),
                [typeof(double)] = new DoubleTypeMapping("double"),
                [typeof(int)] = new IntTypeMapping("double"),
            };

        private readonly Dictionary<string, RelationalTypeMapping> _storeTypeMappings
            = new Dictionary<string, RelationalTypeMapping>
            {
                ["varchar"] = new StringTypeMapping("varchar"),
                ["decimal"] = new DoubleTypeMapping("decimal"),
                ["double"] = new DoubleTypeMapping("double"),
            };

        protected override RelationalTypeMapping? FindMapping(in RelationalTypeMappingInfo mappingInfo)
        {
            var clrType = mappingInfo.ClrType;
            if (clrType != null
                && _clrTypeMappings.TryGetValue(clrType, out var mapping))
            {
                return mapping;
            }

            var storeTypeName = mappingInfo.StoreTypeName;
            if (storeTypeName != null
                && _storeTypeMappings.TryGetValue(storeTypeName, out mapping))
            {
                return mapping;
            }

            mapping = base.FindMapping(mappingInfo);

            return mapping;
        }
    }
}
