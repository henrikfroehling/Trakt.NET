namespace TraktNet.Objects.Post.Capabilities
{
    using Get.Movies;
    using System.Collections.Generic;

    internal interface IPostBuilderMovieAddedWatchedAtDetail
    {
        List<PostBuilderWatchedObject<ITraktMovie>> WatchedMovies { get; }

        void SetCurrentMovie(ITraktMovie movie);
    }
}
