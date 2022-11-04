namespace TraktNet.Parameters
{
    using System.Collections.Generic;
    using TraktNet.Utils;

    public sealed class TraktMovieRatingsFilter : TraktCommonRatingsFilter, ITraktMovieRatingsFilter
    {
        public Range<float>? RottenTomatousMeter { get; set; }

        public Range<float>? Metascores { get; set; }

        public override bool HasValues => base.HasValues || HasRottenTomatoesMeterSet() || HasMetascoresSet();

        public override IDictionary<string, object> GetParameters()
        {
            IDictionary<string, object> parameters = base.GetParameters();

            if (HasRottenTomatoesMeterSet())
            {
                Range<float> rtMeter = RottenTomatousMeter.Value;
                parameters.Add("rt_meters", $"{rtMeter.Begin}-{rtMeter.End}");
            }

            if (HasMetascoresSet())
            {
                Range<float> metascores = Metascores.Value;
                parameters.Add("metascores", $"{metascores.Begin}-{metascores.End}");
            }

            return parameters;
        }

        private bool HasRottenTomatoesMeterSet()
        {
            if (RottenTomatousMeter.HasValue)
            {
                Range<float> rtMeter = RottenTomatousMeter.Value;
                return rtMeter.Begin > 0 && rtMeter.End > 0 && rtMeter.End > rtMeter.Begin;
            }

            return false;
        }

        private bool HasMetascoresSet()
        {
            if (Metascores.HasValue)
            {
                Range<float> metascores = Metascores.Value;
                return metascores.Begin > 0 && metascores.End > 0 && metascores.End > metascores.Begin;
            }

            return false;
        }

    }
}
