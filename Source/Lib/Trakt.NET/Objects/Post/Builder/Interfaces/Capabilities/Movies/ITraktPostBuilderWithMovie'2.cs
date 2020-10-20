namespace TraktNet.Objects.Post.Builder.Capabilities
{
    using Get.Movies;

    public interface ITraktPostBuilderWithMovie<TPostBuilder, TPostObject> where TPostBuilder : ITraktPostBuilder<TPostObject>
    {
        TPostBuilder WithMovie(ITraktMovie movie);
    }
}
