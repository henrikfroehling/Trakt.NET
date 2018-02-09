namespace TraktApiSharp.Objects.Get.Shows.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class TrendingShowObjectJsonWriter : AObjectJsonWriter<ITraktTrendingShow>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktTrendingShow obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Watchers.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.TRENDING_SHOW_PROPERTY_NAME_WATCHERS, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Watchers, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Show != null)
            {
                var showObjectJsonWriter = new ShowObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.TRENDING_SHOW_PROPERTY_NAME_SHOW, cancellationToken).ConfigureAwait(false);
                await showObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Show, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
