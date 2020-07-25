namespace TraktNet.Objects.Post.Checkins.Responses.Json.Writer
{
    using Get.Episodes.Json.Writer;
    using Get.Shows.Json.Writer;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class EpisodeCheckinPostResponseObjectJsonWriter : ACheckinPostResponstObjectJsonWriter<ITraktEpisodeCheckinPostResponse>
    {
        protected override async Task WriteCheckinResponseObjectAsync(JsonTextWriter jsonWriter, ITraktEpisodeCheckinPostResponse obj, CancellationToken cancellationToken = default)
        {
            if (obj.Episode != null)
            {
                var episodeObjectJsonWriter = new EpisodeObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_EPISODE, cancellationToken).ConfigureAwait(false);
                await episodeObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Episode, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Show != null)
            {
                var showObjectJsonWriter = new ShowObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_SHOW, cancellationToken).ConfigureAwait(false);
                await showObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Show, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
