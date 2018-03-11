namespace TraktApiSharp.Objects.Get.Ratings.Json.Writer
{
    using Episodes.Json.Writer;
    using Extensions;
    using Movies.Json.Writer;
    using Newtonsoft.Json;
    using Objects.Json;
    using Seasons.Json.Writer;
    using Shows.Json.Writer;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class RatingsItemObjectJsonWriter : AObjectJsonWriter<ITraktRatingsItem>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktRatingsItem obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.RatedAt.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.RATINGS_ITEM_PROPERTY_NAME_RATED_AT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.RatedAt.Value.ToTraktLongDateTimeString(), cancellationToken).ConfigureAwait(false);
            }

            if (obj.Rating.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.RATINGS_ITEM_PROPERTY_NAME_RATING, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Rating, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Type != null)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.RATINGS_ITEM_PROPERTY_NAME_TYPE, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Type.ObjectName, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Movie != null)
            {
                var movieObjectJsonWriter = new MovieObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.RATINGS_ITEM_PROPERTY_NAME_MOVIE, cancellationToken).ConfigureAwait(false);
                await movieObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Movie, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Show != null)
            {
                var showObjectJsonWriter = new ShowObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.RATINGS_ITEM_PROPERTY_NAME_SHOW, cancellationToken).ConfigureAwait(false);
                await showObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Show, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Season != null)
            {
                var seasonObjectJsonWriter = new SeasonObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.RATINGS_ITEM_PROPERTY_NAME_SEASON, cancellationToken).ConfigureAwait(false);
                await seasonObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Season, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Episode != null)
            {
                var episodeObjectJsonWriter = new EpisodeObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.RATINGS_ITEM_PROPERTY_NAME_EPISODE, cancellationToken).ConfigureAwait(false);
                await episodeObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Episode, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
