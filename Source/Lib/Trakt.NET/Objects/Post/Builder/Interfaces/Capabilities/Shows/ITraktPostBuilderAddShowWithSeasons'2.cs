namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using Get.Shows;

    public interface ITraktPostBuilderAddShowWithSeasons<TPostBuilder, TPostObject>
        : ITraktPostBuilder<TPostObject>,
          ITraktPostBuilderWithShow<ITraktPostBuilderAddShowWithSeasons<TPostBuilder, TPostObject>, TPostObject>
          where TPostBuilder : ITraktPostBuilder<TPostObject>
    {
        ITraktPostBuilderShowAddedSeasons<ITraktPostBuilderAddShowWithSeasons<TPostBuilder, TPostObject>, TPostObject> AddShow(ITraktShow show);
    }
}
