namespace TraktApiSharp.Objects.Get.People.Credits.Implementations
{
    using System.Collections.Generic;

    /// <summary>A collection of crew positions in different categories, which a Trakt person has.</summary>
    public class TraktPersonMovieCreditsCrew : ITraktPersonMovieCreditsCrew
    {
        /// <summary>
        /// Gets or sets a list of crew positions in the production category. See also <seealso cref="ITraktPersonMovieCreditsCrewItem" />.
        /// <para>Nullable</para>
        /// </summary>
        public IEnumerable<ITraktPersonMovieCreditsCrewItem> Production { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the art category. See also <seealso cref="ITraktPersonMovieCreditsCrewItem" />.
        /// <para>Nullable</para>
        /// </summary>
        public IEnumerable<ITraktPersonMovieCreditsCrewItem> Art { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions. See also <seealso cref="ITraktPersonMovieCreditsCrewItem" />.
        /// <para>Nullable</para>
        /// </summary>
        public IEnumerable<ITraktPersonMovieCreditsCrewItem> Crew { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the costume and make-up category. See also <seealso cref="ITraktPersonMovieCreditsCrewItem" />.
        /// <para>Nullable</para>
        /// </summary>
        public IEnumerable<ITraktPersonMovieCreditsCrewItem> CostumeAndMakeup { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the directing category. See also <seealso cref="ITraktPersonMovieCreditsCrewItem" />.
        /// <para>Nullable</para>
        /// </summary>
        public IEnumerable<ITraktPersonMovieCreditsCrewItem> Directing { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the writing category. See also <seealso cref="ITraktPersonMovieCreditsCrewItem" />.
        /// <para>Nullable</para>
        /// </summary>
        public IEnumerable<ITraktPersonMovieCreditsCrewItem> Writing { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the sound category. See also <seealso cref="ITraktPersonMovieCreditsCrewItem" />.
        /// <para>Nullable</para>
        /// </summary>
        public IEnumerable<ITraktPersonMovieCreditsCrewItem> Sound { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the camera category. See also <seealso cref="ITraktPersonMovieCreditsCrewItem" />.
        /// <para>Nullable</para>
        /// </summary>
        public IEnumerable<ITraktPersonMovieCreditsCrewItem> Camera { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the lighting category. See also <seealso cref="ITraktPersonMovieCreditsCrewItem" />.
        /// <para>Nullable</para>
        /// </summary>
        public IEnumerable<ITraktPersonMovieCreditsCrewItem> Lighting { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the visual effects category. See also <seealso cref="ITraktPersonMovieCreditsCrewItem" />.
        /// <para>Nullable</para>
        /// </summary>
        public IEnumerable<ITraktPersonMovieCreditsCrewItem> VisualEffects { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the editing category. See also <seealso cref="ITraktPersonMovieCreditsCrewItem" />.
        /// <para>Nullable</para>
        /// </summary>
        public IEnumerable<ITraktPersonMovieCreditsCrewItem> Editing { get; set; }
    }
}
