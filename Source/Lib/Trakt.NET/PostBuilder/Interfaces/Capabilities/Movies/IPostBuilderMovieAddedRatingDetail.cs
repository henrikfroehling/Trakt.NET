namespace TraktNet.PostBuilder
{
    using System.Collections.Generic;
    using TraktNet.Objects.Get.Movies;

    internal interface IPostBuilderMovieAddedRatingDetail
    {
        List<PostBuilderRatedObject<ITraktMovie>> MoviesAndRating { get; }

        void SetCurrentMovie(ITraktMovie movie);
    }
}
