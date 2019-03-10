namespace TraktNet.Objects.Get.People.Credits.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PersonShowCreditsObjectJsonWriter : AObjectJsonWriter<ITraktPersonShowCredits>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktPersonShowCredits obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Cast != null)
            {
                var personShowCreditsCastItemArrayJsonWriter = new ArrayJsonWriter<ITraktPersonShowCreditsCastItem>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PERSON_SHOW_CREDITS_PROPERTY_NAME_CAST, cancellationToken).ConfigureAwait(false);
                await personShowCreditsCastItemArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Cast, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Crew != null)
            {
                var personShowCreditsCrewObjectJsonWriter = new PersonShowCreditsCrewObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PERSON_SHOW_CREDITS_PROPERTY_NAME_CREW, cancellationToken).ConfigureAwait(false);
                await personShowCreditsCrewObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Crew, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
