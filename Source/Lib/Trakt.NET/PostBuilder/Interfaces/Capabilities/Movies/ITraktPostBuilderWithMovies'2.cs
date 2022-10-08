namespace TraktNet.PostBuilder
{
    using System.Collections.Generic;
    using TraktNet.Objects.Get.Movies;

    public interface ITraktPostBuilderWithMovies<TPostBuilder, TPostObject> where TPostBuilder : ITraktPostBuilder<TPostObject>
    {
        TPostBuilder WithMovies(IEnumerable<ITraktMovie> movies);
    }
}
