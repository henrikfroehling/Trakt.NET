namespace TraktNet.Objects.Post.Capabilities
{
    using Get.Movies;

    public interface ITraktPostBuilderWithMovie<TPostBuilder, TPostObject> where TPostBuilder : ITraktPostBuilder<TPostObject>
    {
        TPostBuilder WithMovie(ITraktMovie movie);
    }
}
