namespace TraktNet.Objects.Basic.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CastAndCrewObjectJsonWriter : AObjectJsonWriter<ITraktCastAndCrew>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktCastAndCrew obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Cast != null)
            {
                var castMemberArrayJsonWriter = new ArrayJsonWriter<ITraktCastMember>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_CAST, cancellationToken).ConfigureAwait(false);
                await castMemberArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Cast, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Crew != null)
            {
                var crewObjectJsonWriter = new CrewObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_CREW, cancellationToken).ConfigureAwait(false);
                await crewObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Crew, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
