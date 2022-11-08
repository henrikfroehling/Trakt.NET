namespace TraktNet.Objects.Post.Syncs.Recommendations.Json.Writer
{
    using Newtonsoft.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using TraktNet.Objects.Json;

    internal abstract class ASyncRecommendationsPostObjectJsonWriter<TSyncRecommendationsPost> : AObjectJsonWriter<TSyncRecommendationsPost>
        where TSyncRecommendationsPost : ITraktSyncRecommendationsPost
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, TSyncRecommendationsPost obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);
            await WriteRecommendationsPostObjectAsync(jsonWriter, obj, cancellationToken).ConfigureAwait(false);
            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }

        protected virtual async Task WriteRecommendationsPostObjectAsync(JsonTextWriter jsonWriter, TSyncRecommendationsPost obj, CancellationToken cancellationToken = default)
        {
            if (obj.Movies != null)
            {
                var syncRecommendationsPostMovieArrayJsonWriter = new ArrayJsonWriter<ITraktSyncRecommendationsPostMovie>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_MOVIES, cancellationToken).ConfigureAwait(false);
                await syncRecommendationsPostMovieArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Movies, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Shows != null)
            {
                var syncRecommendationsPostShowArrayJsonWriter = new ArrayJsonWriter<ITraktSyncRecommendationsPostShow>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_SHOWS, cancellationToken).ConfigureAwait(false);
                await syncRecommendationsPostShowArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Shows, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
