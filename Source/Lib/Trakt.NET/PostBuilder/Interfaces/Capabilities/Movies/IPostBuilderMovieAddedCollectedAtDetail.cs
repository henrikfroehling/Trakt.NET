namespace TraktNet.PostBuilder
{
    using System.Collections.Generic;
    using TraktNet.Objects.Get.Movies;

    internal interface IPostBuilderMovieAddedCollectedAtDetail
    {
        List<PostBuilderCollectedObject<ITraktMovie>> CollectedMovies { get; }

        void SetCurrentMovie(ITraktMovie movie);
    }
}
