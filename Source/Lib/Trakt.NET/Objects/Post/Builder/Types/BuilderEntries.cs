namespace TraktNet.Objects.Post
{
    using System;
    using TraktNet.Objects.Get.Shows;

    public abstract class WithSeasons<T>
    {
        public T Object { get; }

        public PostSeasons Seasons { get; }

        protected WithSeasons(T obj, PostSeasons seasons)
        {
            Object = obj ?? throw new ArgumentNullException(nameof(obj));
            Seasons = seasons ?? throw new ArgumentNullException(nameof(seasons));
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
    }
}
