namespace TraktApiSharp.Objects.Basic
{
    using Enums;

    public interface ITraktGenre
    {
        string Name { get; set; }

        string Slug { get; set; }

        TraktGenreType Type { get; set; }
    }
}
