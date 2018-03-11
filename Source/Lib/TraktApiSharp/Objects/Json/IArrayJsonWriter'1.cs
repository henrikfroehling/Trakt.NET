namespace TraktApiSharp.Objects.Json
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal interface IArrayJsonWriter<TObjectType>
    {
        Task<string> WriteArrayAsync(IEnumerable<TObjectType> objects, CancellationToken cancellationToken = default);

        Task<string> WriteArrayAsync(StringWriter writer, IEnumerable<TObjectType> objects, CancellationToken cancellationToken = default);

        Task WriteArrayAsync(JsonTextWriter jsonWriter, IEnumerable<TObjectType> objects, CancellationToken cancellationToken = default);
    }
}
