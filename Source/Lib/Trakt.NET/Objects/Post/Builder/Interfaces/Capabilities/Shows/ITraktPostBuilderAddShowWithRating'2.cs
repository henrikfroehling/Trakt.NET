namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using Get.Shows;

    public interface ITraktPostBuilderAddShowWithRating<TPostBuilder, TPostObject>
        : ITraktPostBuilder<TPostObject>,
          ITraktPostBuilderWithShow<ITraktPostBuilderAddShowWithRating<TPostBuilder, TPostObject>, TPostObject> where TPostBuilder : ITraktPostBuilder<TPostObject>
    {
        ITraktPostBuilderShowAddedRating<ITraktPostBuilderAddShowWithRating<TPostBuilder, TPostObject>, TPostObject> AddShow(ITraktShow show);
    }
}
