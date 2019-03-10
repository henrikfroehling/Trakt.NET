namespace TraktNet.Objects.Get.People.Credits.Json.Writer
{
    using Movies.Json.Writer;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PersonMovieCreditsCrewItemObjectJsonWriter : AObjectJsonWriter<ITraktPersonMovieCreditsCrewItem>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktPersonMovieCreditsCrewItem obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (!string.IsNullOrEmpty(obj.Job))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PERSON_MOVIE_CREDITS_CREW_ITEM_PROPERTY_NAME_JOB, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Job, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Movie != null)
            {
                var movieObjectJsonWriter = new MovieObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PERSON_MOVIE_CREDITS_CREW_ITEM_PROPERTY_NAME_MOVIE, cancellationToken).ConfigureAwait(false);
                await movieObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Movie, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
