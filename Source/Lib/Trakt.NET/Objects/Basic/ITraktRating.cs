namespace TraktNet.Objects.Basic
{
    using System.Collections.Generic;

    /// <summary>Represents a Trakt rating.</summary>
    public interface ITraktRating
    {
        /// <summary>Gets or sets the rating value.</summary>
        float? Rating { get; set; }

        /// <summary>Gets or sets the number of votes for this rating.</summary>
        int? Votes { get; set; }

        /// <summary>Gets or sets the rating distribution.<para>Nullable</para></summary>
        IDictionary<string, int> Distribution { get; set; }
    }
}
