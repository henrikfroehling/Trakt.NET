namespace TraktApiSharp.Objects.Post.Syncs.History
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TraktSyncHistoryPost : IValidatable
    {
        [JsonProperty(PropertyName = "movies")]
        public IEnumerable<TraktSyncHistoryPostMovieItem> Movies { get; set; }

        [JsonProperty(PropertyName = "shows")]
        public IEnumerable<TraktSyncHistoryPostShowItem> Shows { get; set; }

        [JsonProperty(PropertyName = "episodes")]
        public IEnumerable<TraktSyncHistoryPostEpisodeItem> Episodes { get; set; }

        public void Validate()
        {
            var bHasNoMovies = Movies == null || !Movies.Any();
            var bHasNoShows = Shows == null || !Shows.Any();
            var bHasNoEpisodes = Episodes == null || !Episodes.Any();

            if (bHasNoMovies && bHasNoShows && bHasNoEpisodes)
                throw new ArgumentException("no items to add");
        }
    }
}
