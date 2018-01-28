namespace TraktApiSharp.Objects.Get.Seasons.Json.Writer
{
    using Episodes.Json.Writer;
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

            await jsonWriter.WriteStartObjectAsync(cancellationToken);

            if (obj.Number.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SEASON_PROPERTY_NAME_NUMBER, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.Number, cancellationToken);
            }

            if (!string.IsNullOrEmpty(obj.Title))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SEASON_PROPERTY_NAME_TITLE, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.Title, cancellationToken);
            }

            if (obj.Ids != null)
            {
                var seasonIdsObjectJsonWriter = new SeasonIdsObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SEASON_PROPERTY_NAME_IDS, cancellationToken);
                await seasonIdsObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Ids, cancellationToken);
            }

            if (obj.Rating.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SEASON_PROPERTY_NAME_RATING, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.Rating, cancellationToken);
            }

            if (obj.Votes.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SEASON_PROPERTY_NAME_VOTES, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.Votes, cancellationToken);
            }

            if (obj.TotalEpisodesCount.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SEASON_PROPERTY_NAME_EPISODE_COUNT, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.TotalEpisodesCount, cancellationToken);
            }

            if (obj.AiredEpisodesCount.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SEASON_PROPERTY_NAME_AIRED_EPISODES, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.AiredEpisodesCount, cancellationToken);
            }

            if (!string.IsNullOrEmpty(obj.Overview))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SEASON_PROPERTY_NAME_OVERVIEW, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.Overview, cancellationToken);
            }

            if (obj.FirstAired.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SEASON_PROPERTY_NAME_FIRST_AIRED, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.FirstAired.Value.ToTraktLongDateTimeString(), cancellationToken);
            }

            if (!string.IsNullOrEmpty(obj.Network))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SEASON_PROPERTY_NAME_NETWORK, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.Network, cancellationToken);
            }

            if (obj.Episodes != null)
            {
                var episodeArrayJsonWriter = new EpisodeArrayJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SEASON_PROPERTY_NAME_EPISODES, cancellationToken);
                await episodeArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Episodes, cancellationToken);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken);
        }
    }
}
