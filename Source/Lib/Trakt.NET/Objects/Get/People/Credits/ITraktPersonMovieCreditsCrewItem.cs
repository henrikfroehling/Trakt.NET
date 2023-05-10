namespace TraktNet.Objects.Get.People.Credits
{
    using Movies;
    using System.Collections.Generic;

    /// <summary>Contains information about a Trakt person's crew position.</summary>
    public interface ITraktPersonMovieCreditsCrewItem
    {
        /// <summary>Gets or sets the jobs collection of the crew position.<para>Nullable</para></summary>
        IList<string> Jobs { get; set; }

        /// <summary>
        /// Gets or sets the movie of the crew position. See also <seealso cref="ITraktMovie" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktMovie Movie { get; set; }
    }
}
