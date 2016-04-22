namespace TraktApiSharp.Objects.Get.Syncs.Activities
{
    using Newtonsoft.Json;
    using System;

    public class TraktSyncLastActivities
    {
        [JsonProperty(PropertyName = "all")]
        public DateTime? All { get; set; }

        [JsonProperty(PropertyName = "movies")]
        public TraktSyncMoviesLastActivities Movies { get; set; }

        [JsonProperty(PropertyName = "episodes")]
        public TraktSyncEpisodesLastActivities Episodes { get; set; }

        [JsonProperty(PropertyName = "shows")]
        public TraktSyncShowsLastActivities Shows { get; set; }

        [JsonProperty(PropertyName = "seasons")]
        public TraktSyncSeasonsLastActivities Seasons { get; set; }

        [JsonProperty(PropertyName = "comments")]
        public TraktSyncCommentsLastActivities Comments { get; set; }

        [JsonProperty(PropertyName = "lists")]
        public TraktSyncListsLastActivities Lists { get; set; }
    }
}
