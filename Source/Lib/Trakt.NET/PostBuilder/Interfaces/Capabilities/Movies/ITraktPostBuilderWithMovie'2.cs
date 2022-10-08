namespace TraktNet.PostBuilder
{
    using TraktNet.Objects.Get.Movies;

    public interface ITraktPostBuilderWithMovie<TPostBuilder, TPostObject> where TPostBuilder : ITraktPostBuilder<TPostObject>
    {
        TPostBuilder WithMovie(ITraktMovie movie);
    }
}
