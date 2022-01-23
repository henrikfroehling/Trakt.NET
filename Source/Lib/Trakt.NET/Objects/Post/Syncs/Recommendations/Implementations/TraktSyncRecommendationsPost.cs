namespace TraktNet.Objects.Post.Syncs.Recommendations
{
    using Objects.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>A Trakt recommendations post, containing all movies and shows, which should be recommendated by an user.</summary>
    public class TraktSyncRecommendationsPost : ITraktSyncRecommendationsPost
    {
        /// <summary>
        /// An optional list of <see cref="ITraktSyncRecommendationsPostMovie" />s.
        /// <para>Each <see cref="ITraktSyncRecommendationsPostMovie" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public IEnumerable<ITraktSyncRecommendationsPostMovie> Movies { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktSyncRecommendationsPostShow" />s.
        /// <para>Each <see cref="ITraktSyncRecommendationsPostShow" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public IEnumerable<ITraktSyncRecommendationsPostShow> Shows { get; set; }

        public Task<string> ToJson(CancellationToken cancellationToken = default)
        {
            IObjectJsonWriter<ITraktSyncRecommendationsPost> objectJsonWriter = JsonFactoryContainer.CreateObjectWriter<ITraktSyncRecommendationsPost>();
            return objectJsonWriter.WriteObjectAsync(this, cancellationToken);
        }

        public void Validate()
        {
            foreach (ITraktSyncRecommendationsPostMovie postMovie in Movies)
            {
                if (postMovie.Notes?.Length > 255)
                    throw new ArgumentOutOfRangeException($"Movies[{Movies.ToList().IndexOf(postMovie)}].Notes", "notes cannot be longer than 255 characters");
            }

            foreach (ITraktSyncRecommendationsPostShow postShow in Shows)
            {
                if (postShow.Notes?.Length > 255)
                    throw new ArgumentOutOfRangeException($"Shows[{Shows.ToList().IndexOf(postShow)}].Notes", "notes cannot be longer than 255 characters");
            }
        }
    }
}
