#if NET6_0_OR_GREATER
using TraktNET.Utilities.Json;
#else
using System.Text.Json;
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
            value = await JsonContextSerializer.DeserializeAsync<TJsonObjectType>(Constants.Json.FactoryKey, stream, cancellationToken);
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
            values = await JsonContextSerializer.DeserializeArrayAsync<TJsonObjectType>(Constants.Json.FactoryKey, stream, cancellationToken);
#else
            values = await JsonSerializer.DeserializeAsync<IReadOnlyList<TJsonObjectType>>(stream,
                Constants.Json.JsonOptions, cancellationToken).ConfigureAwait(false);
#endif

            return values;
        }
    }
}
