namespace TraktNet.Parameters
{
    using TraktNet.Utils;

    public interface ITraktCommonRatingsFilter : ITraktBasicRatingsFilter
    {
        Range<float>? TMDBRatings { get; set; }

        Range<uint>? TMDBVotes { get; set; }

        Range<float>? IMDBRatings { get; set; }

        Range<uint>? IMDBVotes { get; set; }
    }
}
