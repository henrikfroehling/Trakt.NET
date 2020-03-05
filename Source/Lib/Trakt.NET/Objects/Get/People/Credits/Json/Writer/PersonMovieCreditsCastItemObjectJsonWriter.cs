namespace TraktNet.Objects.Get.People.Credits.Json.Writer
{
    using Movies.Json.Writer;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PersonMovieCreditsCastItemObjectJsonWriter : AObjectJsonWriter<ITraktPersonMovieCreditsCastItem>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktPersonMovieCreditsCastItem obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (!string.IsNullOrEmpty(obj.Character))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PERSON_MOVIE_CREDITS_CAST_ITEM_PROPERTY_NAME_CHARACTER, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Character, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Characters != null)
                await JsonWriterHelper.WriteStringArrayAsync(jsonWriter, obj.Characters, cancellationToken).ConfigureAwait(false);

            if (obj.Movie != null)
            {
                var movieObjectJsonWriter = new MovieObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PERSON_MOVIE_CREDITS_CAST_ITEM_PROPERTY_NAME_MOVIE, cancellationToken).ConfigureAwait(false);
                await movieObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Movie, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
