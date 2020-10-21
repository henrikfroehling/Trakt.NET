namespace TraktNet.Objects.Post.Builder.Capabilities
{
    public interface ITraktPostBuilderShowAddedSeasonsCollection<TPostBuilderAddShow, out TPostObject, TSeasonCollection>
        where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>
    {
        TPostBuilderAddShow WithSeasons(TSeasonCollection seasons);
    }
}
