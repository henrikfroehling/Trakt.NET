namespace TraktNet.Parameters
{
    using TraktNet.Utils;

    public interface ITraktMovieRatingsFilter : ITraktCommonRatingsFilter
    {
        /// <summary>Optional Rotten Tomatoes meter range between 0 and 100.</summary>
        Range<float>? RottenTomatousMeter { get; set; }

        /// <summary>Optional Metacritic score range between 0 and 100.</summary>
        Range<float>? Metascores { get; set; }
    }
}
