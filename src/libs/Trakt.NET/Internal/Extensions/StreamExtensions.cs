using System.Text.Json;

#if NET6_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace TraktNET
{
    internal static class StreamExtensions
    {
        internal static async Task<TJsonObjectType?> ReadAsJsonAsync<TJsonObjectType>(this Stream stream,
            CancellationToken cancellationToken = default) where TJsonObjectType : class
        {
            TJsonObjectType? value;

#if NET6_0_OR_GREATER
            JsonSerializerContext jsonSerializerContext = JsonSerializerContextFactoryRegistry.GetContext<TJsonObjectType>(Constants.Json.FactoryKey);

            value = await JsonSerializer.DeserializeAsync(stream, typeof(TJsonObjectType),
                jsonSerializerContext, cancellationToken).ConfigureAwait(false) as TJsonObjectType;
#else
            value = await JsonSerializer.DeserializeAsync<TJsonObjectType>(stream,
                Constants.Json.JsonOptions, cancellationToken).ConfigureAwait(false);
#endif

            return value;
        }

        internal static async Task<IReadOnlyList<TJsonObjectType>?> ReadAsJsonArrayAsync<TJsonObjectType>(this Stream stream,
            CancellationToken cancellationToken = default)
        {
            IReadOnlyList<TJsonObjectType>? values;

#if NET6_0_OR_GREATER
            JsonSerializerContext jsonSerializerContext = JsonSerializerContextFactoryRegistry.GetContext<TJsonObjectType>(Constants.Json.FactoryKey);

            values = await JsonSerializer.DeserializeAsync(stream, typeof(IReadOnlyList<TJsonObjectType>),
                jsonSerializerContext, cancellationToken).ConfigureAwait(false) as IReadOnlyList<TJsonObjectType>;
#else
            values = await JsonSerializer.DeserializeAsync<IReadOnlyList<TJsonObjectType>>(stream,
                Constants.Json.JsonOptions, cancellationToken).ConfigureAwait(false);
#endif

            return values;
        }
    }
}
