namespace TraktNet.Objects.Post.Builder.Capabilities
{
    using Get.Movies;
    using System.Collections.Generic;

    internal interface IPostBuilderMovieAddedCollectedAtDetail
    {
        List<PostBuilderCollectedObject<ITraktMovie>> CollectedMovies { get; }

        void SetCurrentMovie(ITraktMovie movie);
    }
}
