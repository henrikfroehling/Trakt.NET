namespace TraktApiSharp.Objects.Post.Users.HiddenItems.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserHiddenItemsPostObjectJsonWriter : AObjectJsonWriter<ITraktUserHiddenItemsPost>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktUserHiddenItemsPost obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Movies != null)
            {
                var hiddenItemsPostMovieArrayJsonWriter = new ArrayJsonWriter<ITraktUserHiddenItemsPostMovie>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_HIDDEN_ITEMS_POST_PROPERTY_NAME_MOVIES, cancellationToken).ConfigureAwait(false);
                await hiddenItemsPostMovieArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Movies, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Shows != null)
            {
                var hiddenItemsPostShowArrayJsonWriter = new ArrayJsonWriter<ITraktUserHiddenItemsPostShow>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_HIDDEN_ITEMS_POST_PROPERTY_NAME_SHOWS, cancellationToken).ConfigureAwait(false);
                await hiddenItemsPostShowArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Shows, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Seasons != null)
            {
                var hiddenItemsPostSeasonArrayJsonWriter = new ArrayJsonWriter<ITraktUserHiddenItemsPostSeason>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_HIDDEN_ITEMS_POST_PROPERTY_NAME_SEASONS, cancellationToken).ConfigureAwait(false);
                await hiddenItemsPostSeasonArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Seasons, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
