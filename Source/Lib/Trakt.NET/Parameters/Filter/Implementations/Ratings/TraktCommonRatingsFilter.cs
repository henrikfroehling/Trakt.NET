namespace TraktNet.Parameters
{
    using System.Collections.Generic;
    using TraktNet.Utils;

    public class TraktCommonRatingsFilter : ATraktBasicRatingsFilter, ITraktCommonRatingsFilter
    {
        public Range<float>? TMDBRatings { get; set; }

        public Range<uint>? TMDBVotes { get; set; }

        public Range<float>? IMDBRatings { get; set; }

        public Range<uint>? IMDBVotes { get; set; }

        public override bool HasValues => base.HasValues || HasTMDBRatingsSet() || HasTMDBVotesSet() || HasIMDBRatingsSet() || HasIMDBVotesSet();

        public override IDictionary<string, object> GetParameters()
        {
            IDictionary<string, object> parameters = base.GetParameters();

            if (HasTMDBRatingsSet())
            {
                Range<float> ratings = TMDBRatings.Value;
                parameters.Add("tmdb_ratings", $"{ratings.Begin}-{ratings.End}");
            }

            if (HasTMDBVotesSet())
            {
                Range<uint> votes = TMDBVotes.Value;
                parameters.Add("tmdb_votes", $"{votes.Begin}-{votes.End}");
            }

            if (HasIMDBRatingsSet())
            {
                Range<float> ratings = IMDBRatings.Value;
                parameters.Add("imdb_ratings", $"{ratings.Begin}-{ratings.End}");
            }

            if (HasIMDBVotesSet())
            {
                Range<uint> votes = IMDBVotes.Value;
                parameters.Add("imdb_votes", $"{votes.Begin}-{votes.End}");
            }

            return parameters;
        }

        protected bool HasTMDBRatingsSet()
        {
            if (TMDBRatings.HasValue)
            {
                Range<float> ratings = TMDBRatings.Value;
                return ratings.Begin > 0 && ratings.End > 0 && ratings.End > ratings.Begin;
            }

            return false;
        }

        protected bool HasTMDBVotesSet()
        {
            if (TMDBVotes.HasValue)
            {
                Range<uint> votes = TMDBVotes.Value;
                return votes.Begin > 0 && votes.End > 0 && votes.End > votes.Begin;
            }

            return false;
        }

        protected bool HasIMDBRatingsSet()
        {
            if (IMDBRatings.HasValue)
            {
                Range<float> ratings = IMDBRatings.Value;
                return ratings.Begin > 0 && ratings.End > 0 && ratings.End > ratings.Begin;
            }

            return false;
        }

        protected bool HasIMDBVotesSet()
        {
            if (IMDBVotes.HasValue)
            {
                Range<uint> votes = IMDBVotes.Value;
                return votes.Begin > 0 && votes.End > 0 && votes.End > votes.Begin;
            }

            return false;
        }
    }
}
