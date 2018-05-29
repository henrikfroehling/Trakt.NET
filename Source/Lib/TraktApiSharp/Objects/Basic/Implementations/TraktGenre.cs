namespace TraktApiSharp.Objects.Basic
{
    using Enums;

    /// <summary>A Trakt genre.</summary>
    public class TraktGenre : ITraktGenre
    {
        /// <summary>Gets or sets the genre name.<para>Nullable</para></summary>
        public string Name { get; set; }

        /// <summary>Gets or sets the Trakt slug of the genre.<para>Nullable</para></summary>
        public string Slug { get; set; }

        /// <summary>Gets or sets the genre type. See also <seealso cref="TraktGenreType" />.<para>Nullable</para></summary>
        public TraktGenreType Type { get; set; }

        public override string ToString()
        {
            var name = !string.IsNullOrEmpty(Name) ? Name : "name not set";
            var slug = !string.IsNullOrEmpty(Slug) ? Slug : "slug not set";
            return $"{name}, {slug}";
        }
    }
}
