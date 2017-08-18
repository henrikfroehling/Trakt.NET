namespace TraktApiSharp.Objects.JsonReader
{
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal interface IObjectJsonReader<TReturnType>
    {
        Task<TReturnType> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken));

        Task<TReturnType> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken));

        Task<TReturnType> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken));
    }
}
