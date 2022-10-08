namespace TraktNet.PostBuilder
{
    using System.Collections.Generic;
    using TraktNet.Objects.Get.Movies;

    internal interface IPostBuilderMovieAddedWatchedAtDetail
    {
        List<PostBuilderWatchedObject<ITraktMovie>> WatchedMovies { get; }

        void SetCurrentMovie(ITraktMovie movie);
    }
}
