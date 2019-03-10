namespace TraktNet.Objects.Post.Users.CustomListItems.Responses.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserCustomListItemsPostResponseObjectJsonWriter : AObjectJsonWriter<ITraktUserCustomListItemsPostResponse>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktUserCustomListItemsPostResponse obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            var userCustomListItemsPostResponseGroupObjectJsonWriter = new UserCustomListItemsPostResponseGroupObjectJsonWriter();
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Added != null)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_CUSTOM_LIST_ITEMS_POST_RESPONSE_PROPERTY_NAME_ADDED, cancellationToken).ConfigureAwait(false);
                await userCustomListItemsPostResponseGroupObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Added, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Existing != null)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_CUSTOM_LIST_ITEMS_POST_RESPONSE_PROPERTY_NAME_EXISTING, cancellationToken).ConfigureAwait(false);
                await userCustomListItemsPostResponseGroupObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Existing, cancellationToken).ConfigureAwait(false);
            }

            if (obj.NotFound != null)
            {
                var userCustomListItemsPostResponseNotFoundGroupObjectJsonWriter = new UserCustomListItemsPostResponseNotFoundGroupObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_CUSTOM_LIST_ITEMS_POST_RESPONSE_PROPERTY_NAME_NOT_FOUND, cancellationToken);
                await userCustomListItemsPostResponseNotFoundGroupObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.NotFound, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
