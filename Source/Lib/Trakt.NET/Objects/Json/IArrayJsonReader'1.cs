namespace TraktNet.Objects.Json
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal interface IArrayJsonReader<TReturnType>
    {
        Task<IList<TReturnType>> ReadArrayAsync(string json, CancellationToken cancellationToken = default);

        Task<IList<TReturnType>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default);

        Task<IList<TReturnType>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default);
    }
}
