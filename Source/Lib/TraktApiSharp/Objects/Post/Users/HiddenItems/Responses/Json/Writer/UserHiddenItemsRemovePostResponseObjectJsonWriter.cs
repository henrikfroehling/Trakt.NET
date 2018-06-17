namespace TraktApiSharp.Objects.Post.Users.HiddenItems.Responses.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserHiddenItemsRemovePostResponseObjectJsonWriter : AObjectJsonWriter<ITraktUserHiddenItemsRemovePostResponse>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktUserHiddenItemsRemovePostResponse obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Deleted != null)
            {
                var userHiddenItemsPostResponseGroupObjectJsonWriter = new UserHiddenItemsPostResponseGroupObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_HIDDEN_ITEMS_REMOVE_POST_RESPONSE_PROPERTY_NAME_DELETED, cancellationToken).ConfigureAwait(false);
                await userHiddenItemsPostResponseGroupObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Deleted, cancellationToken).ConfigureAwait(false);
            }

            if (obj.NotFound != null)
            {
                var userHiddenItemsPostResponseNotFoundGroupObjectJsonWriter = new UserHiddenItemsPostResponseNotFoundGroupObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_HIDDEN_ITEMS_REMOVE_POST_RESPONSE_PROPERTY_NAME_NOT_FOUND, cancellationToken);
                await userHiddenItemsPostResponseNotFoundGroupObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.NotFound, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
