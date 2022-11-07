namespace TraktNet.Objects.Post.Users.PersonalListItems.Json.Writer
{
    using Newtonsoft.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using TraktNet.Objects.Json;

    internal class AUserPersonalListItemsPostObjectJsonWriter<TUserListItemsPost> : AObjectJsonWriter<TUserListItemsPost>
        where TUserListItemsPost : ITraktUserPersonalListItemsPost
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, TUserListItemsPost obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);
            await WriteListItemsPostObjectAsync(jsonWriter, obj, cancellationToken).ConfigureAwait(false);
            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }

        protected virtual async Task WriteListItemsPostObjectAsync(JsonTextWriter jsonWriter, TUserListItemsPost obj, CancellationToken cancellationToken = default)
        {
            if (obj.Movies != null)
            {
                var customListItemsPostMovieArrayJsonWriter = new ArrayJsonWriter<ITraktUserPersonalListItemsPostMovie>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_MOVIES, cancellationToken).ConfigureAwait(false);
                await customListItemsPostMovieArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Movies, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Shows != null)
            {
                var customListItemsPostShowArrayJsonWriter = new ArrayJsonWriter<ITraktUserPersonalListItemsPostShow>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_SHOWS, cancellationToken).ConfigureAwait(false);
                await customListItemsPostShowArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Shows, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Seasons != null)
            {
                var customListItemsPostSeasonArrayJsonWriter = new ArrayJsonWriter<ITraktUserPersonalListItemsPostSeason>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_SEASONS, cancellationToken).ConfigureAwait(false);
                await customListItemsPostSeasonArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Seasons, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Episodes != null)
            {
                var customListItemsPostEpisodeArrayJsonWriter = new ArrayJsonWriter<ITraktUserPersonalListItemsPostEpisode>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_EPISODES, cancellationToken).ConfigureAwait(false);
                await customListItemsPostEpisodeArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Episodes, cancellationToken).ConfigureAwait(false);
            }

            if (obj.People != null)
            {
                var personArrayJsonWriter = new ArrayJsonWriter<ITraktUserPersonalListItemsPostPerson>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_PEOPLE, cancellationToken).ConfigureAwait(false);
                await personArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.People, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
