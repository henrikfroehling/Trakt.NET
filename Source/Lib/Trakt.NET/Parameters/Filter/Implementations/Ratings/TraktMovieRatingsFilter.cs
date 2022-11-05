namespace TraktNet.Parameters
{
    using System.Collections.Generic;
    using System.Globalization;
    using TraktNet.Utils;

    public sealed class TraktMovieRatingsFilter : TraktCommonRatingsFilter, ITraktMovieRatingsFilter
    {
        public Range<float>? RottenTomatousMeter { get; set; }

        public Range<float>? Metascores { get; set; }

        public override bool HasRatingsValues => base.HasRatingsValues || HasRottenTomatoesMeterSet() || HasMetascoresSet();

        public override IDictionary<string, object> GetRatingsParameters()
        {
            IDictionary<string, object> parameters = base.GetRatingsParameters();
            CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture("en-US");

            if (HasRottenTomatoesMeterSet())
            {
                Range<float> rtMeter = RottenTomatousMeter.Value;
                parameters.Add("rt_meters", $"{rtMeter.Begin.ToString("F1", cultureInfo)}-{rtMeter.End.ToString("F1", cultureInfo)}");
            }

            if (HasMetascoresSet())
            {
                Range<float> metascores = Metascores.Value;
                parameters.Add("metascores", $"{metascores.Begin.ToString("F1", cultureInfo)}-{metascores.End.ToString("F1", cultureInfo)}");
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
