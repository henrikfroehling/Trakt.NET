namespace TraktApiSharp.Objects.Json
{
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal interface IObjectJsonWriter<TObjectType>
    {
        Task<string> WriteObjectAsync(TObjectType obj, CancellationToken cancellationToken = default);

        Task<string> WriteObjectAsync(StringWriter writer, TObjectType obj, CancellationToken cancellationToken = default);

        Task WriteObjectAsync(JsonTextWriter jsonWriter, TObjectType obj, CancellationToken cancellationToken = default);
    }
}
