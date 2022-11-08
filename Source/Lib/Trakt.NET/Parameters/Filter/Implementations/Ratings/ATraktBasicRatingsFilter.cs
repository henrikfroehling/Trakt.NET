﻿namespace TraktNet.Parameters
{
    using System.Collections.Generic;
    using TraktNet.Utils;

    internal abstract class ATraktBasicRatingsFilter : ITraktBasicRatingsFilter
    {
        public Range<uint>? Ratings { get; internal set; }

        public Range<uint>? Votes { get; internal set; }

        public virtual bool HasRatingsValues => HasRatingsSet() || HasVotesSet();

        public virtual IDictionary<string, object> GetRatingsParameters()
        {
            var parameters = new Dictionary<string, object>();

            if (HasRatingsSet())
            {
                Range<uint> ratings = Ratings.Value;
                parameters.Add("ratings", $"{ratings.Begin}-{ratings.End}");
            }

            if (HasVotesSet())
            {
                Range<uint> votes = Votes.Value;
                parameters.Add("votes", $"{votes.Begin}-{votes.End}");
            }

            return parameters;
        }

        public string RatingsToString()
        {
            IDictionary<string, object> parameters = GetRatingsParameters();

            if (parameters.Count == 0)
                return string.Empty;

            var keyValues = new List<string>();

            foreach (KeyValuePair<string, object> param in parameters)
                keyValues.Add($"{param.Key}={param.Value}");

            return string.Join("&", keyValues);
        }

        protected bool HasRatingsSet()
        {
            if (Ratings.HasValue)
            {
                Range<uint> ratings = Ratings.Value;
                return ratings.Begin > 0 && ratings.End > 0 && ratings.End > ratings.Begin;
            }

            return false;
        }

        protected bool HasVotesSet()
        {
            if (Votes.HasValue)
            {
                Range<uint> votes = Votes.Value;
                return votes.Begin > 0 && votes.End > 0 && votes.End > votes.Begin;
            }

            return false;
        }
    }
}
