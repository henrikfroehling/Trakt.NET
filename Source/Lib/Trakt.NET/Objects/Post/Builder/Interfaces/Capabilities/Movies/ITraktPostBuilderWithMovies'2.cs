namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using Get.Movies;
    using System.Collections.Generic;

    public interface ITraktPostBuilderWithMovies<TPostBuilder, TPostObject> where TPostBuilder : ITraktPostBuilder<TPostObject>
    {
        TPostBuilder WithMovies(IEnumerable<ITraktMovie> movies);
    }
}
