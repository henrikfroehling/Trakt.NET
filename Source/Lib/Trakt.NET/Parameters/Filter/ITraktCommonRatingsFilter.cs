namespace TraktNet.Parameters
{
    using TraktNet.Utils;

    public interface ITraktCommonRatingsFilter : ITraktBasicRatingsFilter
    {
        Range<float>? TMDBRatings { get; set; }

        Range<int>? TMDBVotes { get; set; }

        Range<float>? IMDBRatings { get; set; }

        Range<int>? IMDBVotes { get; set; }
    }
}
