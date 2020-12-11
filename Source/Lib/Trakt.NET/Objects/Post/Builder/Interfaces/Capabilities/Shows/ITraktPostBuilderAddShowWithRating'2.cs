namespace TraktNet.Objects.Post.Capabilities
{
    using Get.Shows;

    public interface ITraktPostBuilderAddShowWithRating<TPostBuilder, TPostObject>
        where TPostBuilder : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithRating<TPostBuilder, TPostObject>
    {
        ITraktPostBuilderShowAddedRating<TPostBuilder, TPostObject> AddRatedShow(ITraktShow show);
    }
}
