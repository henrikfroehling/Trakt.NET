namespace TraktApiSharp.Objects.Post.Syncs.Ratings
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TraktSyncRatingsPost : IValidatable
    {
        [JsonProperty(PropertyName = "movies")]
        public IEnumerable<TraktSyncRatingsPostMovieItem> Movies { get; set; }

        [JsonProperty(PropertyName = "shows")]
        public IEnumerable<TraktSyncRatingsPostShowItem> Shows { get; set; }

        [JsonProperty(PropertyName = "episodes")]
        public IEnumerable<TraktSyncRatingsPostEpisodeItem> Episodes { get; set; }

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
