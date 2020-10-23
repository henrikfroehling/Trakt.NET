namespace TraktNet.Objects.Get.People.Credits.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using Shows.Json.Writer;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PersonShowCreditsCrewItemObjectJsonWriter : AObjectJsonWriter<ITraktPersonShowCreditsCrewItem>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktPersonShowCreditsCrewItem obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Jobs != null)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_JOBS, cancellationToken).ConfigureAwait(false);
                await JsonWriterHelper.WriteStringArrayAsync(jsonWriter, obj.Jobs, cancellationToken).ConfigureAwait(false);
            }

            if (obj.EpisodeCount.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_EPISODE_COUNT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.EpisodeCount.Value, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Show != null)
            {
                var movieObjectJsonWriter = new ShowObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_SHOW, cancellationToken).ConfigureAwait(false);
                await movieObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Show, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
