namespace TraktNet.Parameters
{
    using System.Collections.Generic;
    using System.Globalization;
    using TraktNet.Utils;

    internal class TraktCommonRatingsFilter : ATraktBasicRatingsFilter, ITraktCommonRatingsFilter
    {
        public Range<float>? TMDBRatings { get; internal set; }

        public Range<uint>? TMDBVotes { get; internal set; }

        public Range<float>? IMDBRatings { get; internal set; }

        public Range<uint>? IMDBVotes { get; internal set; }

        public override bool HasRatingsValues => base.HasRatingsValues || HasTMDBRatingsSet() || HasTMDBVotesSet() || HasIMDBRatingsSet() || HasIMDBVotesSet();

        public override IDictionary<string, object> GetRatingsParameters()
        {
            IDictionary<string, object> parameters = base.GetRatingsParameters();
            CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture("en-US");

            if (HasTMDBRatingsSet())
            {
                Range<float> ratings = TMDBRatings.Value;
                parameters.Add("tmdb_ratings", $"{ratings.Begin.ToString("F1", cultureInfo)}-{ratings.End.ToString("F1", cultureInfo)}");
            }

            if (HasTMDBVotesSet())
            {
                Range<uint> votes = TMDBVotes.Value;
                parameters.Add("tmdb_votes", $"{votes.Begin}-{votes.End}");
            }

            if (HasIMDBRatingsSet())
            {
                Range<float> ratings = IMDBRatings.Value;
                parameters.Add("imdb_ratings", $"{ratings.Begin.ToString("F1", cultureInfo)}-{ratings.End.ToString("F1", cultureInfo)}");
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
