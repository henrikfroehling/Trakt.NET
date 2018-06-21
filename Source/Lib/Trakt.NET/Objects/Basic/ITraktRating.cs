namespace TraktNet.Objects.Basic
{
    using System.Collections.Generic;

    public interface ITraktRating
    {
        float? Rating { get; set; }

        int? Votes { get; set; }

        IDictionary<string, int> Distribution { get; set; }
    }
}
