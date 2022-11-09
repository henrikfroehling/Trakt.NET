namespace TraktNet.Objects.Post.Users.PersonalListItems.Responses.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using Objects.Post.Responses.Json.Writer;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserPersonalListItemsPostResponseObjectJsonWriter : AObjectJsonWriter<ITraktUserPersonalListItemsPostResponse>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktUserPersonalListItemsPostResponse obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            var userCustomListItemsPostResponseGroupObjectJsonWriter = new UserPersonalListItemsPostResponseGroupObjectJsonWriter();
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Added != null)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_ADDED, cancellationToken).ConfigureAwait(false);
                await userCustomListItemsPostResponseGroupObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Added, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Existing != null)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_EXISTING, cancellationToken).ConfigureAwait(false);
                await userCustomListItemsPostResponseGroupObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Existing, cancellationToken).ConfigureAwait(false);
            }

            if (obj.NotFound != null)
            {
                var userCustomListItemsPostResponseNotFoundGroupObjectJsonWriter = new UserPersonalListItemsPostResponseNotFoundGroupObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_NOT_FOUND, cancellationToken);
                await userCustomListItemsPostResponseNotFoundGroupObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.NotFound, cancellationToken).ConfigureAwait(false);
            }

            if (obj.List != null)
            {
                var postResponseListDataObjectJsonWriter = new PostResponseListDataObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_LIST, cancellationToken);
                await postResponseListDataObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.List, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
