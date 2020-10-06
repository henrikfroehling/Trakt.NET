namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using Get.Shows;

    public interface ITraktPostBuilderAddShowWithCollectedAtWithSeasons<TPostBuilder, TPostObject>
        : ITraktPostBuilder<TPostObject>,
          ITraktPostBuilderWithShow<ITraktPostBuilderAddShowWithCollectedAtWithSeasons<TPostBuilder, TPostObject>, TPostObject> where TPostBuilder : ITraktPostBuilder<TPostObject>
    {
        ITraktPostBuilderShowAddedCollectedAtWithSeasons<ITraktPostBuilderAddShowWithCollectedAtWithSeasons<TPostBuilder, TPostObject>, TPostObject> AddShow(ITraktShow show);
    }
}
