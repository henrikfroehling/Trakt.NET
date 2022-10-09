namespace TraktNet.PostBuilder
{
    using System;

    public abstract class WatchlistItemWithNotesAndSeasons<T>
    {
        public T Object { get; }

        public PostSeasons Seasons { get; }

        protected WatchlistItemWithNotesAndSeasons(T obj, PostSeasons seasons)
        {
            Object = obj ?? throw new ArgumentNullException(nameof(obj));
            Seasons = seasons ?? throw new ArgumentNullException(nameof(seasons));
        }
    }

    /// <summary>
    /// Represents a <see cref="ShowWithNotes"/> with a collection of seasons and episodes.
    /// See also <seealso cref="PostSeasons"/>.
    /// </summary>
    public sealed class ShowWithNotesAndSeasons : WatchlistItemWithNotesAndSeasons<ShowWithNotes>
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
    public sealed class ShowIdsWithNotesAndSeasons : WatchlistItemWithNotesAndSeasons<ShowIdsWithNotes>
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
