namespace TraktApiSharp.Objects.Json
{
    using Newtonsoft.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal interface IObjectJsonWriter<TObjectType>
    {
        Task<string> WriteObjectAsync(TObjectType obj, CancellationToken cancellationToken = default(CancellationToken));

        Task WriteObjectAsync(JsonTextWriter jsonTextWriter, TObjectType obj, CancellationToken cancellationToken = default(CancellationToken));
    }
}
