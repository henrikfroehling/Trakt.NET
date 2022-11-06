namespace TraktNet.Parameters
{
    using System.Collections.Generic;
    using TraktNet.Utils;

    public interface ITraktBasicRatingsFilter
    {
        /// <summary>Optional Trakt rating range between 0 and 100.</summary>
        Range<uint>? Ratings { get; }

        /// <summary>Optional Trakt vote count between 0 and 100000.</summary>
        Range<uint>? Votes { get; }

        /// <summary>Returns whether the filter has any rating values set.</summary>
        bool HasRatingsValues { get; }

        /// <summary>Returns a list of key value pairs of set filter rating values.</summary>
        /// <returns>A list of key value pairs of set filter rating values.</returns>
        IDictionary<string, object> GetRatingsParameters();

        /// <summary>Returns a string representation of set filter rating values.</summary>
        /// <returns>A string representation of set filter rating values.</returns>
        string RatingsToString();
    }
}
