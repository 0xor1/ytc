using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dnsk.Db.Util;

public class UlidConverter : ValueConverter<Ulid, byte[]>
{
    public UlidConverter()
        : base(
                convertToProviderExpression: x => x.ToByteArray(),
                convertFromProviderExpression: x => new Ulid(x),
                mappingHints: new ConverterMappingHints(size: 16)){}
}