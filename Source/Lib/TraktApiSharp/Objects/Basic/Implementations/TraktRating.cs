namespace TraktApiSharp.Objects.Basic.Implementations
{
    using System.Collections.Generic;

    /// <summary>Represents a Trakt rating.</summary>
    public class TraktRating : ITraktRating
    {
        /// <summary>Gets or sets the rating value.</summary>
        public float? Rating { get; set; }

        /// <summary>Gets or sets the number of votes for this rating.</summary>
        public int? Votes { get; set; }

        /// <summary>Gets or sets the rating distribution.<para>Nullable</para></summary>
        public IDictionary<string, int> Distribution { get; set; }

        public override string ToString()
        {
            var rating = Rating.HasValue ? Rating.Value.ToString() : default(float).ToString();
            var votes = Votes.HasValue ? Votes.Value.ToString() : default(int).ToString();
            return $"{rating}, {votes}";
        }
    }
}
