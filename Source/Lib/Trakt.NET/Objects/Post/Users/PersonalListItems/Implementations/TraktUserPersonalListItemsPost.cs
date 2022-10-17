namespace TraktNet.Objects.Post.Users.PersonalListItems
{
    using Objects.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// An user personal list items post, containing all movies, shows, seasons, episodes and / or people,
    /// which should be added to an user's personal list.
    /// </summary>
    public class TraktUserPersonalListItemsPost : ITraktUserPersonalListItemsPost
    {
        /// <summary>
        /// An optional list of <see cref="ITraktUserPersonalListItemsPostMovie" />s.
        /// <para>Each <see cref="ITraktUserPersonalListItemsPostMovie" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public IEnumerable<ITraktUserPersonalListItemsPostMovie> Movies { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktUserPersonalListItemsPostShow" />s.
        /// <para>Each <see cref="ITraktUserPersonalListItemsPostShow" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public IEnumerable<ITraktUserPersonalListItemsPostShow> Shows { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktUserPersonalListItemsPostSeason" />s.
        /// <para>Each <see cref="ITraktUserPersonalListItemsPostSeason" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public IEnumerable<ITraktUserPersonalListItemsPostSeason> Seasons { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktUserPersonalListItemsPostEpisode" />s.
        /// <para>Each <see cref="ITraktUserPersonalListItemsPostEpisode" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public IEnumerable<ITraktUserPersonalListItemsPostEpisode> Episodes { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktUserPersonalListItemsPostPerson" />s.
        /// <para>Each <see cref="ITraktUserPersonalListItemsPostPerson" /> must have at least a valid Trakt id and a name.</para>
        /// </summary>
        public IEnumerable<ITraktUserPersonalListItemsPostPerson> People { get; set; }

        public Task<string> ToJson(CancellationToken cancellationToken = default)
        {
            IObjectJsonWriter<ITraktUserPersonalListItemsPost> objectJsonWriter = JsonFactoryContainer.CreateObjectWriter<ITraktUserPersonalListItemsPost>();
            return objectJsonWriter.WriteObjectAsync(this, cancellationToken);
        }

        public void Validate()
        {
            bool bHasNoMovies = Movies == null || !Movies.Any();
            bool bHasNoShows = Shows == null || !Shows.Any();
            bool bHasNoSeasons = Seasons == null || !Seasons.Any();
            bool bHasNoEpisodes = Episodes == null || !Episodes.Any();
            bool bHasNoPeople = People == null || !People.Any();

            if (bHasNoMovies && bHasNoShows && bHasNoSeasons && bHasNoEpisodes && bHasNoPeople)
                throw new ArgumentException("no personal list items set");
        }
    }
}
