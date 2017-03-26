namespace TraktApiSharp.Objects.Get.Syncs.Activities
{
    using System;

    public interface ITraktSyncLastActivities
    {
        DateTime? All { get; set; }

        ITraktSyncMoviesLastActivities Movies { get; set; }

        ITraktSyncShowsLastActivities Shows { get; set; }

        ITraktSyncSeasonsLastActivities Seasons { get; set; }

        ITraktSyncEpisodesLastActivities Episodes { get; set; }

        ITraktSyncCommentsLastActivities Comments { get; set; }

        ITraktSyncListsLastActivities Lists { get; set; }
    }
}
