namespace TraktApiSharp.Objects.Get.People.Credits.Implementations
{
    using System.Collections.Generic;

    /// <summary>Contains all Trakt movies where a Trakt person is in the cast or crew.</summary>
    public class TraktPersonMovieCredits : ITraktPersonMovieCredits
    {
        /// <summary>
        /// Gets or sets a list of cast positions, in which a person is.
        /// See also <seealso cref="ITraktPersonMovieCreditsCastItem" />.
        /// <para>Nullable</para>
        /// </summary>
        public IEnumerable<ITraktPersonMovieCreditsCastItem> Cast { get; set; }

        /// <summary>
        /// Gets or sets a collection of crew positions, which a person has.
        /// See also <seealso cref="ITraktPersonMovieCreditsCrew" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktPersonMovieCreditsCrew Crew { get; set; }
    }
}
