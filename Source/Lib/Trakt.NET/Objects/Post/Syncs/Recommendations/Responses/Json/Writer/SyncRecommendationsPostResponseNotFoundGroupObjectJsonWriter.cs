namespace TraktNet.Objects.Post.Syncs.Recommendations.Responses.Json.Writer
{
    using Get.Movies;
    using Get.Shows;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncRecommendationsPostResponseNotFoundGroupObjectJsonWriter : AObjectJsonWriter<ITraktSyncRecommendationsPostResponseNotFoundGroup>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktSyncRecommendationsPostResponseNotFoundGroup obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Movies != null)
            {
                var movieIdsArrayJsonWriter = new ArrayJsonWriter<ITraktMovieIds>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_MOVIES, cancellationToken).ConfigureAwait(false);
                await movieIdsArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Movies, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Shows != null)
            {
                var showIdsArrayJsonWriter = new ArrayJsonWriter<ITraktShowIds>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_SHOWS, cancellationToken).ConfigureAwait(false);
                await showIdsArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Shows, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
