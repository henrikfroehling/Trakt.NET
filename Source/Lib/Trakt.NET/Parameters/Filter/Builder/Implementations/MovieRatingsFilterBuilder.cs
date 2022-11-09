﻿namespace TraktNet.Parameters
{
    using System;
    using TraktNet.Utils;

    internal sealed class MovieRatingsFilterBuilder
        : ACommonRatingsFilterBuilder<ITraktMovieFilter, ITraktMovieFilterBuilder>, ITraktMovieRatingsFilterBuilder
    {
        internal Range<float>? RottenTomatoesMeter { get; private set; }
        
        internal Range<float>? Metascores { get; private set; }

        internal MovieRatingsFilterBuilder(ITraktMovieFilterBuilder filterBuilder) : base(filterBuilder)
        {
            RottenTomatoesMeter = null;
            Metascores = null;
        }

        public ITraktMovieFilterBuilder WithRottenTomatoesMeter(float start, float end)
        {
            if (start > 100.0)
                throw new ArgumentOutOfRangeException(nameof(start), "start should have maximum value of 100.0");

            if (end > 100.0)
                throw new ArgumentOutOfRangeException(nameof(start), "end should have maximum value of 100.0");

            if (end < start)
                throw new ArgumentOutOfRangeException(nameof(start), "start should be less than end");

            RottenTomatoesMeter = new Range<float>(start, end);
            return _filterBuilder;
        }

        public ITraktMovieFilterBuilder WithMetascores(float start, float end)
        {
            if (start > 100.0)
                throw new ArgumentOutOfRangeException(nameof(start), "start should have maximum value of 100.0");

            if (end > 100.0)
                throw new ArgumentOutOfRangeException(nameof(start), "end should have maximum value of 100.0");

            if (end < start)
                throw new ArgumentOutOfRangeException(nameof(start), "start should be less than end");

            Metascores = new Range<float>(start, end);
            return _filterBuilder;
        }
    }
}
