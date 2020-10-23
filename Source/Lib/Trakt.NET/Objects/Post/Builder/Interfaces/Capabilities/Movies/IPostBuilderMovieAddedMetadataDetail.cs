namespace TraktNet.Objects.Post.Builder.Capabilities
{
    using Get.Movies;
    using System.Collections.Generic;

    internal interface IPostBuilderMovieAddedMetadataDetail
    {
        List<PostBuilderObjectWithMetadata<ITraktMovie>> MoviesAndMetadata { get; }

        void SetCurrentMovie(ITraktMovie movie);
    }
}
