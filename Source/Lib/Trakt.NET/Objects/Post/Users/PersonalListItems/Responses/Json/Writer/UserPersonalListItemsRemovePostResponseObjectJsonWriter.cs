namespace TraktNet.Objects.Post.Users.PersonalListItems.Responses.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using Objects.Post.Responses.Json.Writer;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserPersonalListItemsRemovePostResponseObjectJsonWriter : AObjectJsonWriter<ITraktUserPersonalListItemsRemovePostResponse>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktUserPersonalListItemsRemovePostResponse obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Deleted != null)
            {
                var userCustomListItemsPostResponseGroupObjectJsonWriter = new UserPersonalListItemsPostResponseGroupObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_ADDED, cancellationToken).ConfigureAwait(false);
                await userCustomListItemsPostResponseGroupObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Deleted, cancellationToken).ConfigureAwait(false);
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
