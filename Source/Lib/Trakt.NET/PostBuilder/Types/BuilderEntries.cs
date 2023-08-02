namespace TraktNet.PostBuilder
{
    using Objects.Get.Episodes;
    using Objects.Get.Movies;
    using Objects.Get.People;
    using Objects.Get.Seasons;
    using Objects.Get.Shows;
    using System;
    using System.Collections.Generic;

    public abstract class WithSeasons<T>
    {
        public T Object { get; }

        public PostSeasons Seasons { get; }

        protected WithSeasons(T obj, PostSeasons seasons)
        {
            Object = obj ?? throw new ArgumentNullException(nameof(obj));
            Seasons = seasons ?? throw new ArgumentNullException(nameof(seasons));
        }

        protected WithSeasons(T obj, IEnumerable<int> seasons)
        {
            Object = obj ?? throw new ArgumentNullException(nameof(obj));

            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            Seasons = new PostSeasons { seasons };
        }

        protected WithSeasons(T obj, int season, params int[] seasons)
        {
            Object = obj ?? throw new ArgumentNullException(nameof(obj));

            Seasons = new PostSeasons { season, seasons };
        }
    }

    /// <summary>
    /// Represents a <see cref="ITraktShow"/> with a collection of seasons and episodes.
    /// See also <seealso cref="PostSeasons"/>.
    /// </summary>
    public sealed class ShowAndSeasons : WithSeasons<ITraktShow>
    {
        /// <summary>Initializes a new instance of the <see cref="ShowAndSeasons" /> class.</summary>
        /// <param name="show">A <see cref="ITraktShow"/>.</param>
        /// <param name="seasons">
        /// A collection of seasons and episodes for the <paramref name="show"/>.
        /// See also <seealso cref="PostSeasons"/>.
        /// </param>
        public ShowAndSeasons(ITraktShow show, PostSeasons seasons)
            : base(show, seasons)
        { }

        /// <summary>Initializes a new instance of the <see cref="ShowAndSeasons" /> class.</summary>
        /// <param name="show">A <see cref="ITraktShow"/>.</param>
        /// <param name="seasons">A collection of season numbers for the <paramref name="show"/>.</param>
        public ShowAndSeasons(ITraktShow show, IEnumerable<int> seasons)
            : base(show, seasons)
        { }

        /// <summary>Initializes a new instance of the <see cref="ShowAndSeasons" /> class.</summary>
        /// <param name="show">A <see cref="ITraktShow"/>.</param>
        /// <param name="season">An season number for the <paramref name="show"/>.</param>
        /// <param name="seasons">An optional array of season numbers for the <paramref name="show"/>.</param>
        public ShowAndSeasons(ITraktShow show, int season, params int[] seasons)
            : base(show, season, seasons)
        { }
    }

    /// <summary>
    /// Represents a <see cref="ITraktShowIds"/> with a collection of seasons and episodes.
    /// See also <seealso cref="PostSeasons"/>.
    /// </summary>
    public sealed class ShowIdsAndSeasons : WithSeasons<ITraktShowIds>
    {
        /// <summary>Initializes a new instance of the <see cref="ShowIdsAndSeasons" /> class.</summary>
        /// <param name="showIds">A <see cref="ITraktShowIds"/>.</param>
        /// <param name="seasons">
        /// A collection of seasons and episodes for the <paramref name="showIds"/>.
        /// See also <seealso cref="PostSeasons"/>.
        /// </param>
        public ShowIdsAndSeasons(ITraktShowIds showIds, PostSeasons seasons)
            : base(showIds, seasons)
        { }

        /// <summary>Initializes a new instance of the <see cref="ShowIdsAndSeasons" /> class.</summary>
        /// <param name="show">A <see cref="ITraktShow"/>.</param>
        /// <param name="seasons">A collection of season numbers for the <paramref name="showIds"/>.</param>
        public ShowIdsAndSeasons(ITraktShowIds showIds, IEnumerable<int> seasons)
            : base(showIds, seasons)
        { }

        /// <summary>Initializes a new instance of the <see cref="ShowIdsAndSeasons" /> class.</summary>
        /// <param name="show">A <see cref="ITraktShow"/>.</param>
        /// <param name="season">An season number for the <paramref name="showIds"/>.</param>
        /// <param name="seasons">An optional array of season numbers for the <paramref name="showIds"/>.</param>
        public ShowIdsAndSeasons(ITraktShowIds showIds, int season, params int[] seasons)
            : base(showIds, season, seasons)
        { }
    }

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

    /// <summary>Represents a <see cref="ITraktPerson"/> with notes.</summary>
    public class PersonWithNotes : EntryWithNotes<ITraktPerson>
    {
        /// <summary>Initializes a new instance of the <see cref="PersonWithNotes" /> class.</summary>
        /// <param name="person">A <see cref="ITraktPerson"/>.</param>
        /// <param name="notes">The notes for the <paramref name="person"/>.</param>
        public PersonWithNotes(ITraktPerson person, string notes)
            : base(person, notes)
        { }
    }

    /// <summary>Represents a <see cref="ITraktPersonIds"/> with notes.</summary>
    public class PersonIdsWithNotes : EntryWithNotes<ITraktPersonIds>
    {
        /// <summary>Initializes a new instance of the <see cref="PersonIdsWithNotes" /> class.</summary>
        /// <param name="personIds">A <see cref="ITraktPersonIds"/>.</param>
        /// <param name="notes">The notes for the <paramref name="personIds"/>.</param>
        public PersonIdsWithNotes(ITraktPersonIds personIds, string notes)
            : base(personIds, notes)
        { }
    }

    public abstract class EntryWithNotesAndSeasons<T>
    {
        public T Object { get; }

        public PostSeasons Seasons { get; }

        protected EntryWithNotesAndSeasons(T obj, PostSeasons seasons)
        {
            Object = obj ?? throw new ArgumentNullException(nameof(obj));
            Seasons = seasons ?? throw new ArgumentNullException(nameof(seasons));
        }
    }

    /// <summary>
    /// Represents a <see cref="ShowWithNotes"/> with a collection of seasons and episodes.
    /// See also <seealso cref="PostSeasons"/>.
    /// </summary>
    public sealed class ShowWithNotesAndSeasons : EntryWithNotesAndSeasons<ShowWithNotes>
    {
        /// <summary>Initializes a new instance of the <see cref="ShowWithNotesAndSeasons" /> class.</summary>
        /// <param name="showWithNotes">A <see cref="ShowWithNotes"/>.</param>
        /// <param name="seasons">
        /// A collection of seasons and episodes for the <paramref name="showWithNotes"/>.
        /// See also <seealso cref="PostSeasons"/>.
        /// </param>
        public ShowWithNotesAndSeasons(ShowWithNotes showWithNotes, PostSeasons seasons)
            : base(showWithNotes, seasons)
        { }
    }

    /// <summary>
    /// Represents a <see cref="ShowIdsWithNotes"/> with a collection of seasons and episodes.
    /// See also <seealso cref="PostSeasons"/>.
    /// </summary>
    public sealed class ShowIdsWithNotesAndSeasons : EntryWithNotesAndSeasons<ShowIdsWithNotes>
    {
        /// <summary>Initializes a new instance of the <see cref="ShowIdsWithNotesAndSeasons" /> class.</summary>
        /// <param name="showIdsWithNotes">A <see cref="ShowIdsWithNotes"/>.</param>
        /// <param name="seasons">
        /// A collection of seasons and episodes for the <paramref name="showIdsWithNotes"/>.
        /// See also <seealso cref="PostSeasons"/>.
        /// </param>
        public ShowIdsWithNotesAndSeasons(ShowIdsWithNotes showIdsWithNotes, PostSeasons seasons)
            : base(showIdsWithNotes, seasons)
        { }
    }
}
