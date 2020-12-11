namespace TraktNet.Objects.Post.Capabilities
{
    using Get.Movies;
    using System.Collections.Generic;

    internal interface IPostBuilderMovieAddedRatingDetail
    {
        List<PostBuilderRatedObject<ITraktMovie>> MoviesAndRating { get; }

        void SetCurrentMovie(ITraktMovie movie);
    }
}
