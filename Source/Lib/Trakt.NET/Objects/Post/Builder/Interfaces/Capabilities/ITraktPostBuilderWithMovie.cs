namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using Get.Movies;
    using System.Collections.Generic;

    public interface ITraktPostBuilderWithMovie<TPostBuilder, TPostObject> where TPostBuilder : ITraktPostBuilder<TPostObject>
    {
        TPostBuilder WithMovie(ITraktMovie movie);

        TPostBuilder WithMovies(IEnumerable<ITraktMovie> movies);
    }
}
