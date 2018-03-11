namespace TraktApiSharp.Objects.Post.Users.CustomListItems.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserCustomListItemsPostShowSeasonObjectJsonWriter : AObjectJsonWriter<ITraktUserCustomListItemsPostShowSeason>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktUserCustomListItemsPostShowSeason obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_CUSTOM_LIST_ITEMS_POST_SHOW_SEASON_PROPERTY_NAME_NUMBER, cancellationToken).ConfigureAwait(false);
            await jsonWriter.WriteValueAsync(obj.Number, cancellationToken).ConfigureAwait(false);

            if (obj.Episodes != null)
            {
                var customListItemsPostShowEpisodeArrayJsonWriter = new ArrayJsonWriter<ITraktUserCustomListItemsPostShowEpisode>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_CUSTOM_LIST_ITEMS_POST_SHOW_SEASON_PROPERTY_NAME_EPISODES, cancellationToken).ConfigureAwait(false);
                await customListItemsPostShowEpisodeArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Episodes, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
