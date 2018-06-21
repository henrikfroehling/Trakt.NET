namespace TraktNet.Objects.Post.Scrobbles.Responses.Json.Writer
{
    using Get.Episodes.Json.Writer;
    using Get.Shows.Json.Writer;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class EpisodeScrobblePostResponseObjectJsonWriter : AScrobblePostResponseObjectJsonWriter<ITraktEpisodeScrobblePostResponse>
    {
        protected override async Task WriteScrobbleResponseObjectAsync(JsonTextWriter jsonWriter, ITraktEpisodeScrobblePostResponse obj, CancellationToken cancellationToken = default)
        {
            if (obj.Episode != null)
            {
                var episodeObjectJsonWriter = new EpisodeObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.EPISODE_SCROBBLE_POST_RESPONSE_PROPERTY_NAME_EPISODE, cancellationToken).ConfigureAwait(false);
                await episodeObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Episode, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Show != null)
            {
                var showObjectJsonWriter = new ShowObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.EPISODE_SCROBBLE_POST_RESPONSE_PROPERTY_NAME_SHOW, cancellationToken).ConfigureAwait(false);
                await showObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Show, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
