namespace TraktNet.Objects.Basic
{
    using Enums;

    /// <summary>A Trakt genre.</summary>
    public interface ITraktGenre
    {
        /// <summary>Gets or sets the genre name.<para>Nullable</para></summary>
        string Name { get; set; }

        /// <summary>Gets or sets the Trakt slug of the genre.<para>Nullable</para></summary>
        string Slug { get; set; }

        /// <summary>Gets or sets the genre type. See also <seealso cref="TraktGenreType" />.<para>Nullable</para></summary>
        TraktGenreType Type { get; set; }
    }
}
