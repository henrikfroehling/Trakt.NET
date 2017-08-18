namespace TraktApiSharp.Objects.JsonReader
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal interface IArrayJsonReader<TReturnType>
    {
        Task<IEnumerable<TReturnType>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken));

        Task<IEnumerable<TReturnType>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken));

        Task<IEnumerable<TReturnType>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken));
    }
}
