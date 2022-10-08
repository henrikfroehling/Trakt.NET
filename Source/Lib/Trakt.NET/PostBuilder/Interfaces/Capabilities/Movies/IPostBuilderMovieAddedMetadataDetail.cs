namespace TraktNet.PostBuilder
{
    using System.Collections.Generic;
    using TraktNet.Objects.Get.Movies;

    internal interface IPostBuilderMovieAddedMetadataDetail
    {
        List<PostBuilderObjectWithMetadata<ITraktMovie>> MoviesAndMetadata { get; }

        void SetCurrentMovie(ITraktMovie movie);
    }
}
