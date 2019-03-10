namespace TraktNet.Objects.Post.Users.CustomListItems.Json.Writer
{
    using Get.Movies.Json.Writer;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserCustomListItemsPostMovieObjectJsonWriter : AObjectJsonWriter<ITraktUserCustomListItemsPostMovie>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktUserCustomListItemsPostMovie obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Ids != null)
            {
                var movieIdsObjectJsonWriter = new MovieIdsObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_CUSTOM_LIST_ITEMS_POST_MOVIE_PROPERTY_NAME_IDS, cancellationToken).ConfigureAwait(false);
                await movieIdsObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Ids, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
