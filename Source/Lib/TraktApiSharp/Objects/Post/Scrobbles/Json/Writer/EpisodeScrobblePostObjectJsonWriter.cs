namespace TraktNet.Objects.Post.Scrobbles.Json.Writer
{
    using Get.Episodes.Json.Writer;
    using Get.Shows.Json.Writer;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class EpisodeScrobblePostObjectJsonWriter : AScrobblePostObjectJsonWriter<ITraktEpisodeScrobblePost>
    {
        protected override async Task WriteScrobbleObjectAsync(JsonTextWriter jsonWriter, ITraktEpisodeScrobblePost obj, CancellationToken cancellationToken = default)
        {
            if (obj.Episode != null)
            {
                var episodeObjectJsonWriter = new EpisodeObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.EPISODE_SCROBBLE_POST_PROPERTY_NAME_EPISODE, cancellationToken).ConfigureAwait(false);
                await episodeObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Episode, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Show != null)
            {
                var showObjectJsonWriter = new ShowObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.EPISODE_SCROBBLE_POST_PROPERTY_NAME_SHOW, cancellationToken).ConfigureAwait(false);
                await showObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Show, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
