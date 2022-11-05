namespace TraktNet.Parameters
{
    using System.Collections.Generic;
    using TraktNet.Utils;

    public interface ITraktBasicRatingsFilter
    {
        Range<uint>? Ratings { get; set; }

        Range<uint>? Votes { get; set; }

        bool HasRatingsValues { get; }

        IDictionary<string, object> GetRatingsParameters();

        string RatingsToString();
    }
}
