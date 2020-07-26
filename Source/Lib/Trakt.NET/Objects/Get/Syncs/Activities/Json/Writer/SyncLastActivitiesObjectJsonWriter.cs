namespace TraktNet.Objects.Get.Syncs.Activities.Json.Writer
{
    using Extensions;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncLastActivitiesObjectJsonWriter : AObjectJsonWriter<ITraktSyncLastActivities>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktSyncLastActivities obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.All.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_ALL, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.All.Value.ToTraktLongDateTimeString(), cancellationToken).ConfigureAwait(false);
            }

            if (obj.Movies != null)
            {
                var syncMoviesLastActivitiesObjectJsonWriter = new SyncMoviesLastActivitiesObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_MOVIES, cancellationToken).ConfigureAwait(false);
                await syncMoviesLastActivitiesObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Movies, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Shows != null)
            {
                var syncShowsLastActivitiesObjectJsonWriter = new SyncShowsLastActivitiesObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_SHOWS, cancellationToken).ConfigureAwait(false);
                await syncShowsLastActivitiesObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Shows, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Seasons != null)
            {
                var syncSeasonsLastActivitiesObjectJsonWriter = new SyncSeasonsLastActivitiesObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_SEASONS, cancellationToken).ConfigureAwait(false);
                await syncSeasonsLastActivitiesObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Seasons, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Episodes != null)
            {
                var syncEpisodesLastActivitiesObjectJsonWriter = new SyncEpisodesLastActivitiesObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_EPISODES, cancellationToken).ConfigureAwait(false);
                await syncEpisodesLastActivitiesObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Episodes, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Comments != null)
            {
                var syncCommentsLastActivitiesObjectJsonWriter = new SyncCommentsLastActivitiesObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_COMMENTS, cancellationToken).ConfigureAwait(false);
                await syncCommentsLastActivitiesObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Comments, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Lists != null)
            {
                var syncListsLastActivitiesObjectJsonWriter = new SyncListsLastActivitiesObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_LISTS, cancellationToken).ConfigureAwait(false);
                await syncListsLastActivitiesObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Lists, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
