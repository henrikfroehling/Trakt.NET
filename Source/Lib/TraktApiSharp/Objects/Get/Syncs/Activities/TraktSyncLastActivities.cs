namespace TraktApiSharp.Objects.Get.Syncs.Activities
{
    using Attributes;
    using Newtonsoft.Json;
    using System;

    public class TraktSyncLastActivities
    {
        [JsonProperty(PropertyName = "all")]
        public DateTime? All { get; set; }

        [JsonProperty(PropertyName = "movies")]
        [Nullable]
        public TraktSyncMoviesLastActivities Movies { get; set; }

        [JsonProperty(PropertyName = "episodes")]
        [Nullable]
        public TraktSyncEpisodesLastActivities Episodes { get; set; }

        [JsonProperty(PropertyName = "shows")]
        [Nullable]
        public TraktSyncShowsLastActivities Shows { get; set; }

        [JsonProperty(PropertyName = "seasons")]
        [Nullable]
        public TraktSyncSeasonsLastActivities Seasons { get; set; }

        [JsonProperty(PropertyName = "comments")]
        [Nullable]
        public TraktSyncCommentsLastActivities Comments { get; set; }

        [JsonProperty(PropertyName = "lists")]
        [Nullable]
        public TraktSyncListsLastActivities Lists { get; set; }
    }
}
