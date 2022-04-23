namespace TraktNet.Objects.Post.Capabilities
{
    public interface ITraktPostBuilderShowAddedSeasonsCollection<TPostBuilderAddShow, out TPostObject, in TSeasonCollection>
        where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderShowWithSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>
    {
        TPostBuilderAddShow WithSeasons(TSeasonCollection seasons);
    }
}
