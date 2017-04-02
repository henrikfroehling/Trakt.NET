namespace TraktApiSharp.Objects.JsonReader
{
    using Newtonsoft.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal interface ITraktObjectJsonReader<TReturnType>
    {
        Task<TReturnType> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken));

        Task<TReturnType> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken));
    }
}
