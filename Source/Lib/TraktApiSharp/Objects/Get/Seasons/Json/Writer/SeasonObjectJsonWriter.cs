namespace TraktNet.Objects.Get.Seasons.Json.Writer
{
    using Episodes;
    using Extensions;
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SeasonObjectJsonWriter : AObjectJsonWriter<ITraktSeason>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktSeason obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Number.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SEASON_PROPERTY_NAME_NUMBER, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Number, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.Title))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SEASON_PROPERTY_NAME_TITLE, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Title, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Ids != null)
            {
                var seasonIdsObjectJsonWriter = new SeasonIdsObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SEASON_PROPERTY_NAME_IDS, cancellationToken).ConfigureAwait(false);
                await seasonIdsObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Ids, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Rating.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SEASON_PROPERTY_NAME_RATING, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Rating, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Votes.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SEASON_PROPERTY_NAME_VOTES, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Votes, cancellationToken).ConfigureAwait(false);
            }

            if (obj.TotalEpisodesCount.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SEASON_PROPERTY_NAME_EPISODE_COUNT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.TotalEpisodesCount, cancellationToken).ConfigureAwait(false);
            }

            if (obj.AiredEpisodesCount.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SEASON_PROPERTY_NAME_AIRED_EPISODES, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.AiredEpisodesCount, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.Overview))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SEASON_PROPERTY_NAME_OVERVIEW, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Overview, cancellationToken).ConfigureAwait(false);
            }

            if (obj.FirstAired.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SEASON_PROPERTY_NAME_FIRST_AIRED, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.FirstAired.Value.ToTraktLongDateTimeString(), cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.Network))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SEASON_PROPERTY_NAME_NETWORK, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Network, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Episodes != null)
            {
                var episodeArrayJsonWriter = new ArrayJsonWriter<ITraktEpisode>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SEASON_PROPERTY_NAME_EPISODES, cancellationToken).ConfigureAwait(false);
                await episodeArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Episodes, cancellationToken).ConfigureAwait(false);
            }

            if (obj.CommentCount.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SEASON_PROPERTY_NAME_COMMENT_COUNT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.CommentCount, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
