namespace TraktNet.PostBuilder
{
    using TraktNet.Objects.Get.Shows;

    public interface ITraktPostBuilderShowWithSeasons<TPostBuilder, TPostObject>
        where TPostBuilder : ITraktPostBuilder<TPostObject>, ITraktPostBuilderShowWithSeasons<TPostBuilder, TPostObject>
    {
        ITraktPostBuilderShowAddedSeasons<TPostBuilder, TPostObject> WithShowAndSeasons(ITraktShow show);
    }
}
