namespace TraktNet.PostBuilder
{
    using System;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Get.Shows;

    public abstract class EntryWithNotes<T>
    {
        public T Object { get; }

        public string Notes { get; }

        protected EntryWithNotes(T obj, string notes)
        {
            Object = obj ?? throw new ArgumentNullException(nameof(obj));
            Notes = notes;
        }
    }

    /// <summary>Represents a <see cref="ITraktMovie"/> with notes.</summary>
    public class MovieWithNotes : EntryWithNotes<ITraktMovie>
    {
        /// <summary>Initializes a new instance of the <see cref="MovieWithNotes" /> class.</summary>
        /// <param name="movie">A <see cref="ITraktMovie"/>.</param>
        /// <param name="notes">The notes for the <paramref name="movie"/>.</param>
        public MovieWithNotes(ITraktMovie movie, string notes)
            : base(movie, notes)
        { }
    }

    /// <summary>Represents a <see cref="ITraktMovieIds"/> with notes.</summary>
    public class MovieIdsWithNotes : EntryWithNotes<ITraktMovieIds>
    {
        /// <summary>Initializes a new instance of the <see cref="MovieIdsWithNotes" /> class.</summary>
        /// <param name="movieIds">A <see cref="ITraktMovieIds"/>.</param>
        /// <param name="notes">The notes for the <paramref name="movieIds"/>.</param>
        public MovieIdsWithNotes(ITraktMovieIds movieIds, string notes)
            : base(movieIds, notes)
        { }
    }

    /// <summary>Represents a <see cref="ITraktShow"/> with notes.</summary>
    public class ShowWithNotes : EntryWithNotes<ITraktShow>
    {
        /// <summary>Initializes a new instance of the <see cref="ShowWithNotes" /> class.</summary>
        /// <param name="show">A <see cref="ITraktShow"/>.</param>
        /// <param name="notes">The notes for the <paramref name="show"/>.</param>
        public ShowWithNotes(ITraktShow show, string notes)
            : base(show, notes)
        { }
    }

    /// <summary>Represents a <see cref="ITraktShowIds"/> with notes.</summary>
    public class ShowIdsWithNotes : EntryWithNotes<ITraktShowIds>
    {
        /// <summary>Initializes a new instance of the <see cref="ShowIdsWithNotes" /> class.</summary>
        /// <param name="showIds">A <see cref="ITraktShowIds"/>.</param>
        /// <param name="notes">The notes for the <paramref name="showIds"/>.</param>
        public ShowIdsWithNotes(ITraktShowIds showIds, string notes)
            : base(showIds, notes)
        { }
    }

    /// <summary>Represents a <see cref="ITraktSeason"/> with notes.</summary>
    public class SeasonWithNotes : EntryWithNotes<ITraktSeason>
    {
        /// <summary>Initializes a new instance of the <see cref="SeasonWithNotes" /> class.</summary>
        /// <param name="season">A <see cref="ITraktSeason"/>.</param>
        /// <param name="notes">The notes for the <paramref name="season"/>.</param>
        public SeasonWithNotes(ITraktSeason season, string notes)
            : base(season, notes)
        { }
    }

    /// <summary>Represents a <see cref="ITraktSeasonIds"/> with notes.</summary>
    public class SeasonIdsWithNotes : EntryWithNotes<ITraktSeasonIds>
    {
        /// <summary>Initializes a new instance of the <see cref="SeasonIdsWithNotes" /> class.</summary>
        /// <param name="seasonIds">A <see cref="ITraktSeasonIds"/>.</param>
        /// <param name="notes">The notes for the <paramref name="seasonIds"/>.</param>
        public SeasonIdsWithNotes(ITraktSeasonIds seasonIds, string notes)
            : base(seasonIds, notes)
        { }
    }

    /// <summary>Represents a <see cref="ITraktEpisode"/> with notes.</summary>
    public class EpisodeWithNotes : EntryWithNotes<ITraktEpisode>
    {
        /// <summary>Initializes a new instance of the <see cref="EpisodeWithNotes" /> class.</summary>
        /// <param name="episode">A <see cref="ITraktEpisode"/>.</param>
        /// <param name="notes">The notes for the <paramref name="episode"/>.</param>
        public EpisodeWithNotes(ITraktEpisode episode, string notes)
            : base(episode, notes)
        { }
    }

    /// <summary>Represents a <see cref="ITraktEpisodeIds"/> with notes.</summary>
    public class EpisodeIdsWithNotes : EntryWithNotes<ITraktEpisodeIds>
    {
        /// <summary>Initializes a new instance of the <see cref="EpisodeIdsWithNotes" /> class.</summary>
        /// <param name="episodeIds">A <see cref="ITraktEpisodeIds"/>.</param>
        /// <param name="notes">The notes for the <paramref name="episodeIds"/>.</param>
        public EpisodeIdsWithNotes(ITraktEpisodeIds episodeIds, string notes)
            : base(episodeIds, notes)
        { }
    }
}
