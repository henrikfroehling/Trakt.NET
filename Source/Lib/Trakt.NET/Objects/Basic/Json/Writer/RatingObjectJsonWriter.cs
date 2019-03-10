namespace TraktNet.Objects.Basic.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class RatingObjectJsonWriter : AObjectJsonWriter<ITraktRating>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktRating obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Rating.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.RATING_PROPERTY_NAME_RATING, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Rating, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Votes.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.RATING_PROPERTY_NAME_VOTES, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Votes, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Distribution?.Count > 0)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.RATING_PROPERTY_NAME_DISTRIBUTION, cancellationToken).ConfigureAwait(false);
                await JsonWriterHelper.WriteDistributionAsync(jsonWriter, obj.Distribution, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
