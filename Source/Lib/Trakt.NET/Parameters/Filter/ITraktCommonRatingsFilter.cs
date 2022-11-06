namespace TraktNet.Parameters
{
    using TraktNet.Utils;

    public interface ITraktCommonRatingsFilter : ITraktBasicRatingsFilter
    {
        /// <summary>Optional TMDB rating range between 0.0 and 10.0.</summary>
        Range<float>? TMDBRatings { get; }

        /// <summary>Optional TMDB vote count between 0 and 100000.</summary>
        Range<uint>? TMDBVotes { get; }

        /// <summary>Optional IMDB rating range between 0.0 and 10.0.</summary>
        Range<float>? IMDBRatings { get; }

        /// <summary>Optional IMDB vote count between 0 and 3000000.</summary>
        Range<uint>? IMDBVotes { get; }
    }
}
