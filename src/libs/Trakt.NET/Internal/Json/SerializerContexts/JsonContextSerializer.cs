#if NET6_0_OR_GREATER
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TraktNET
{
    internal static class JsonContextSerializer
    {
        internal static async Task<TJsonObjectType?> DeserializeAsync<TJsonObjectType>(string factoryKey, Stream stream,
            CancellationToken cancellationToken = default) where TJsonObjectType : class
        {
            JsonSerializerContext jsonSerializerContext = JsonSerializerContextFactoryRegistry.Get(factoryKey).GetContext<TJsonObjectType>();

            return await JsonSerializer.DeserializeAsync(stream, typeof(TJsonObjectType),
                jsonSerializerContext, cancellationToken).ConfigureAwait(false) as TJsonObjectType;
        }

        internal static async Task<IReadOnlyList<TJsonObjectType>?> DeserializeArrayAsync<TJsonObjectType>(string factoryKey, Stream stream,
            CancellationToken cancellationToken = default)
        {
            JsonSerializerContext jsonSerializerContext = JsonSerializerContextFactoryRegistry.Get(factoryKey).GetContext<TJsonObjectType>();

            return await JsonSerializer.DeserializeAsync(stream, typeof(IReadOnlyList<TJsonObjectType>),
                jsonSerializerContext, cancellationToken).ConfigureAwait(false) as IReadOnlyList<TJsonObjectType>;
        }
    }
}
#endif
