namespace TraktApiSharp.Objects.Get.People.Credits.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PersonMovieCreditsObjectJsonWriter : AObjectJsonWriter<ITraktPersonMovieCredits>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktPersonMovieCredits obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Cast != null)
            {
                var personMovieCreditsCastItemArrayJsonWriter = new PersonMovieCreditsCastItemArrayJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PERSON_MOVIE_CREDITS_PROPERTY_NAME_CAST, cancellationToken).ConfigureAwait(false);
                await personMovieCreditsCastItemArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Cast, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Crew != null)
            {
                var personMovieCreditsCrewObjectJsonWriter = new PersonMovieCreditsCrewObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PERSON_MOVIE_CREDITS_PROPERTY_NAME_CREW, cancellationToken).ConfigureAwait(false);
                await personMovieCreditsCrewObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Crew, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
