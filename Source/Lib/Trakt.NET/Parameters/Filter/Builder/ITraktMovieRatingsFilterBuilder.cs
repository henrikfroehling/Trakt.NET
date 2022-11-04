namespace TraktNet.Parameters
{
    public interface ITraktMovieRatingsFilterBuilder : ITraktCommonRatingsFilterBuilder<ITraktMovieFilter, ITraktMovieFilterBuilder>
    {
        ITraktMovieFilterBuilder WithRottenTomatoesMeter(float start, float end);

        ITraktMovieFilterBuilder WithMetascores(float start, float end);
    }
}
