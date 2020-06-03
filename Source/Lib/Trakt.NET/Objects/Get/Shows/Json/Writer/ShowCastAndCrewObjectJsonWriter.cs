namespace TraktNet.Objects.Get.Shows.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ShowCastAndCrewObjectJsonWriter : AObjectJsonWriter<ITraktShowCastAndCrew>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktShowCastAndCrew obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Cast != null)
            {
                var showCastMemberArrayJsonWriter = new ArrayJsonWriter<ITraktShowCastMember>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.CAST_AND_CREW_PROPERTY_NAME_CAST, cancellationToken).ConfigureAwait(false);
                await showCastMemberArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Cast, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Crew != null)
            {
                var showCrewObjectJsonWriter = new ShowCrewObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.CAST_AND_CREW_PROPERTY_NAME_CREW, cancellationToken).ConfigureAwait(false);
                await showCrewObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Crew, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
