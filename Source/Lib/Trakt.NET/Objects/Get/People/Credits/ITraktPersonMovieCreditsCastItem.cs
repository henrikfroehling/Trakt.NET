namespace TraktNet.Objects.Get.People.Credits
{
    using Movies;

    /// <summary>Contains information about a Trakt person's cast position.</summary>
    public interface ITraktPersonMovieCreditsCastItem
    {
        /// <summary>Gets or sets the character name of the cast position.<para>Nullable</para></summary>
        string Character { get; set; }

        /// <summary>
        /// Gets or sets the movie of the cast position. See also <seealso cref="ITraktMovie" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktMovie Movie { get; set; }
    }
}
