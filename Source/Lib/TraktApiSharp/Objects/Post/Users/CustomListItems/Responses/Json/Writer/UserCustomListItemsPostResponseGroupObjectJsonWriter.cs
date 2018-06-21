namespace TraktNet.Objects.Post.Users.CustomListItems.Responses.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserCustomListItemsPostResponseGroupObjectJsonWriter : AObjectJsonWriter<ITraktUserCustomListItemsPostResponseGroup>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktUserCustomListItemsPostResponseGroup obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Movies.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_CUSTOM_LIST_ITEMS_POST_RESPONSE_GROUP_PROPERTY_NAME_MOVIES, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Movies, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Shows.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_CUSTOM_LIST_ITEMS_POST_RESPONSE_GROUP_PROPERTY_NAME_SHOWS, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Shows, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Seasons.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_CUSTOM_LIST_ITEMS_POST_RESPONSE_GROUP_PROPERTY_NAME_SEASONS, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Seasons, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Episodes.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_CUSTOM_LIST_ITEMS_POST_RESPONSE_GROUP_PROPERTY_NAME_EPISODES, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Episodes, cancellationToken).ConfigureAwait(false);
            }

            if (obj.People.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_CUSTOM_LIST_ITEMS_POST_RESPONSE_GROUP_PROPERTY_NAME_PEOPLE, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.People, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
