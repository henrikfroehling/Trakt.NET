namespace TraktNet.PostBuilder
{
    using System;
    using System.Collections.Generic;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Get.Movies;

    public interface ITraktPostBuilderWithMoviesWithMetadata<TPostBuilder, TPostObject> where TPostBuilder : ITraktPostBuilder<TPostObject>
    {
        TPostBuilder WithMoviesAndMetadata(IEnumerable<Tuple<ITraktMovie, ITraktMetadata>> movies);

        TPostBuilder WithMoviesAndMetadata(IEnumerable<Tuple<ITraktMovie, ITraktMetadata, DateTime?>> movies);

        TPostBuilder WithCollectedMovies(IEnumerable<Tuple<ITraktMovie, DateTime?>> movies);
    }
}
