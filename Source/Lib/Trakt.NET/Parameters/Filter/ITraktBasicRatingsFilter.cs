namespace TraktNet.Parameters
{
    using System.Collections.Generic;
    using TraktNet.Utils;

    public interface ITraktBasicRatingsFilter
    {
        Range<int>? Ratings { get; set; }

        Range<int>? Votes { get; set; }

        bool HasValues { get; }

        IDictionary<string, object> GetParameters();

        string ToString();
    }
}
