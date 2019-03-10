namespace TraktNet.Objects.Post.Users.CustomListItems.Json.Writer
{
    using Get.People;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserCustomListItemsPostObjectJsonWriter : AObjectJsonWriter<ITraktUserCustomListItemsPost>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktUserCustomListItemsPost obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Movies != null)
            {
                var customListItemsPostMovieArrayJsonWriter = new ArrayJsonWriter<ITraktUserCustomListItemsPostMovie>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_CUSTOM_LIST_ITEMS_POST_PROPERTY_NAME_MOVIES, cancellationToken).ConfigureAwait(false);
                await customListItemsPostMovieArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Movies, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Shows != null)
            {
                var customListItemsPostShowArrayJsonWriter = new ArrayJsonWriter<ITraktUserCustomListItemsPostShow>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_CUSTOM_LIST_ITEMS_POST_PROPERTY_NAME_SHOWS, cancellationToken).ConfigureAwait(false);
                await customListItemsPostShowArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Shows, cancellationToken).ConfigureAwait(false);
            }

            if (obj.People != null)
            {
                var personArrayJsonWriter = new ArrayJsonWriter<ITraktPerson>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_CUSTOM_LIST_ITEMS_POST_PROPERTY_NAME_PEOPLE, cancellationToken).ConfigureAwait(false);
                await personArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.People, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
