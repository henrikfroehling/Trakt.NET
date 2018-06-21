namespace TraktNet.Objects.Get.People.Credits
{
    using Movies;

    /// <summary>Contains information about a Trakt person's cast position.</summary>
    public class TraktPersonMovieCreditsCastItem : ITraktPersonMovieCreditsCastItem
    {
        /// <summary>Gets or sets the character name of the cast position.<para>Nullable</para></summary>
        public string Character { get; set; }

        /// <summary>
        /// Gets or sets the movie of the cast position. See also <seealso cref="ITraktMovie" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktMovie Movie { get; set; }
    }
}
