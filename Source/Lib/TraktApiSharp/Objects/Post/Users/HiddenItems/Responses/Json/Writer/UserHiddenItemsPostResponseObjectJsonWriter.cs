namespace TraktApiSharp.Objects.Post.Users.HiddenItems.Responses.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserHiddenItemsPostResponseObjectJsonWriter : AObjectJsonWriter<ITraktUserHiddenItemsPostResponse>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktUserHiddenItemsPostResponse obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Added != null)
            {
                var userHiddenItemsPostResponseGroupObjectJsonWriter = new UserHiddenItemsPostResponseGroupObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_HIDDEN_ITEMS_POST_RESPONSE_PROPERTY_NAME_ADDED, cancellationToken).ConfigureAwait(false);
                await userHiddenItemsPostResponseGroupObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Added, cancellationToken).ConfigureAwait(false);
            }

            if (obj.NotFound != null)
            {
                var userHiddenItemsPostResponseNotFoundGroupObjectJsonWriter = new UserHiddenItemsPostResponseNotFoundGroupObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_HIDDEN_ITEMS_POST_RESPONSE_PROPERTY_NAME_NOT_FOUND, cancellationToken);
                await userHiddenItemsPostResponseNotFoundGroupObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.NotFound, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
