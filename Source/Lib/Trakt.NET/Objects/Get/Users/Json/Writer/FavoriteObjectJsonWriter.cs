namespace TraktNet.Objects.Get.Users.Json.Writer
{
    using Enums;
    using Extensions;
    using Movies.Json.Writer;
    using Newtonsoft.Json;
    using Objects.Json;
    using Shows.Json.Writer;
    using System.Threading;
    using System.Threading.Tasks;

    internal class FavoriteObjectJsonWriter : AObjectJsonWriter<ITraktFavorite>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktFavorite obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Id.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_ID, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Id.Value, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Rank.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_RANK, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Rank.Value, cancellationToken).ConfigureAwait(false);
            }

            if (obj.ListedAt.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_LISTED_AT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.ListedAt.Value.ToTraktLongDateTimeString(), cancellationToken).ConfigureAwait(false);
            }

            if (obj.Type != null && obj.Type != TraktFavoriteObjectType.Unspecified)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_TYPE, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Type.ObjectName, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.Notes))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_NOTES, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Notes, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Movie != null)
            {
                var movieObjectJsonWriter = new MovieObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_MOVIE, cancellationToken).ConfigureAwait(false);
                await movieObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Movie, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Show != null)
            {
                var showObjectJsonWriter = new ShowObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_SHOW, cancellationToken).ConfigureAwait(false);
                await showObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Show, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
