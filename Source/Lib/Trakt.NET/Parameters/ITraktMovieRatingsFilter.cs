namespace TraktNet.Parameters
{
    using TraktNet.Utils;

    public interface ITraktMovieRatingsFilter : ITraktCommonRatingsFilter
    {
        Range<float>? RottenTomatousMeter { get; set; }

        Range<float>? Metascores { get; set; }
    }
}
