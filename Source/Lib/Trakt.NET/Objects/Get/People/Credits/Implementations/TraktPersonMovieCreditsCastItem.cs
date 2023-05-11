namespace TraktNet.Objects.Get.People.Credits
{
    using Movies;
    using System.Collections.Generic;

    /// <summary>Contains information about a Trakt person's cast position.</summary>
    public class TraktPersonMovieCreditsCastItem : ITraktPersonMovieCreditsCastItem
    {
        /// <summary>Gets or sets the characters collection of the cast position.<para>Nullable</para></summary>
        public IList<string> Characters { get; set; }

        /// <summary>
        /// Gets or sets the movie of the cast position. See also <seealso cref="ITraktMovie" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktMovie Movie { get; set; }
    }
}
