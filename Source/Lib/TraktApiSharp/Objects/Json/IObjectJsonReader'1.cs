namespace TraktApiSharp.Objects.Json
{
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal interface IObjectJsonReader<TReturnType>
    {
        Task<TReturnType> ReadObjectAsync(string json, CancellationToken cancellationToken = default);

        Task<TReturnType> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default);

        Task<TReturnType> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default);
    }
}
